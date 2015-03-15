using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Docking;
using Mangtas.Wall.Adapters;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System.IO;

namespace Mangtas.Wall
{
    class Bootstrapper : UnityBootstrapper
    {
        #region manual bootstrapping
        //protected override DependencyObject CreateShell()
        //{
        //    return this.Container.Resolve<Shell>();
        //}

        //protected override void InitializeShell()
        //{
        //    base.InitializeShell();

        //    App.Current.MainWindow = (Window)this.Shell;
        //    App.Current.MainWindow.Show();
        //}

        //protected override void ConfigureModuleCatalog()
        //{
        //    base.ConfigureModuleCatalog();

        //    var plugins = Directory.GetDirectories(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modules")).ToList();
        //    ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
        //    plugins.ForEach(s =>
        //    {
        //        var module = new DirectoryInfo(s);
        //        var di = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, s, "bin"));
        //        var pluginAssemblyFiles = di.GetFiles(module.Name + ".dll", SearchOption.AllDirectories);
        //        foreach (var pluginAssemblyFile in pluginAssemblyFiles)
        //        {
        //            //var asm = Assembly.LoadFrom(pluginAssemblyFile.FullName);
        //            moduleCatalog.AddModule(pluginAssemblyFile.FullName);
        //            //BuildManager.AddReferencedAssembly(asm);
        //        }
        //    });
        //    //
        //    //
        //}
        #endregion

        #region Quickie
        public Bootstrapper()
        {
            // we need to watch our folder for newly added modules
            //FileSystemWatcher fileWatcher = new FileSystemWatcher(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Modules"), "*.dll");
            //fileWatcher.Created += fileWatcher_Created;
            //fileWatcher.EnableRaisingEvents = true;
        }

        void fileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Created)
            {
                //get the Prism assembly that IModule is defined in
                Assembly moduleAssembly = AppDomain.CurrentDomain.GetAssemblies().First(asm => asm.FullName == typeof(IModule).Assembly.FullName);
                Type IModuleType = moduleAssembly.GetType(typeof(IModule).FullName);

                //load our newly added assembly
                Assembly assembly = Assembly.LoadFile(e.FullPath);

                //look for all the classes that implement IModule in our assembly and create a ModuleInfo class from it
                var moduleInfos = assembly.GetExportedTypes()
                    .Where(IModuleType.IsAssignableFrom)
                    .Where(t => t != IModuleType)
                    .Where(t => !t.IsAbstract).Select(t => CreateModuleInfo(t));


                //create an instance of our module manager
                var moduleManager = Container.Resolve<IModuleManager>();

                foreach (var moduleInfo in moduleInfos)
                {
                    //add the ModuleInfo to the catalog so it can be loaded
                    ModuleCatalog.AddModule(moduleInfo);

                    //now load the module using the Dispatcher because the FileSystemWatcher.Created even occurs on a separate thread
                    //and we need to load our module into the main thread.
                    var d = Application.Current.Dispatcher;
                    if (d.CheckAccess())
                        moduleManager.LoadModule(moduleInfo.ModuleName);
                    else
                        d.BeginInvoke((Action)delegate { moduleManager.LoadModule(moduleInfo.ModuleName); });
                }
            }
        }

        private static ModuleInfo CreateModuleInfo(Type type)
        {
            string moduleName = type.Name;

            var moduleAttribute = CustomAttributeData.GetCustomAttributes(type).FirstOrDefault(cad => cad.Constructor.DeclaringType.FullName == typeof(ModuleAttribute).FullName);

            if (moduleAttribute != null)
            {
                foreach (CustomAttributeNamedArgument argument in moduleAttribute.NamedArguments)
                {
                    string argumentName = argument.MemberInfo.Name;
                    if (argumentName == "ModuleName")
                    {
                        moduleName = (string)argument.TypedValue.Value;
                        break;
                    }
                }
            }

            ModuleInfo moduleInfo = new ModuleInfo(moduleName, type.AssemblyQualifiedName)
            {
                InitializationMode = InitializationMode.OnDemand,
                Ref = type.Assembly.CodeBase,
            };

            return moduleInfo;
        }

        #endregion //Quick and Dirty

        protected override System.Windows.DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell(); 

            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            //var basedir = AppDomain.CurrentDomain.BaseDirectory;
            string modulesdir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName;
            DynamicDirectoryModuleCatalog catalog = new DynamicDirectoryModuleCatalog(Path.Combine(modulesdir, "modules"));
            return catalog;
        }

       

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            if (mappings != null)
            {
                //mappings.RegisterMapping(typeof(DockLayoutManager), ServiceLocator.Current.GetInstance<DockManagerAdapter>());
                mappings.RegisterMapping(typeof(DocumentGroup), ServiceLocator.Current.GetInstance<DocumentGroupAdapter>());

            }
            return mappings;
        }

    }

   
}
