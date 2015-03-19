using System.Windows.Input;

namespace WpfHelpers.MenuBar
{
    public class MenuItem
    {
        public string Parent { get; set; }
        public string Title { get; set; }
        public ICommand Command { get; set; }
    }

    public interface IMenuService
    {
        void Add(MenuItem item);
    }
}
