using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Xpf.Ribbon;

namespace Mangtas.Main
{
    public class MyBackstageViewControl : RibbonControl
    {
        //bool showBackButton, backButtonEnabled;
        //public MyBackstageViewControl()
        //{
        //    this.showBackButton = this.backButtonEnabled = true;
        //}
        //public bool ShowBackButton
        //{
        //    get { return showBackButton; }
        //    set
        //    {
        //        showBackButton = value;
        //    }
        //}
        //public bool BackButtonEnabled
        //{
        //    get { return backButtonEnabled; }
        //    set
        //    {
        //        backButtonEnabled = value;
        //    }
        //}

        //protected override BackstageViewControlPainter CreatePainter()
        //{
        //    if (ShouldUseOffice2010ControlStyle)
        //        return new MyOffice2010BackstageViewPainter();
        //    return base.CreatePainter();
        //}
        //protected override BackstageViewInfo CreateViewInfo()
        //{
        //    if (ShouldUseOffice2013ControlStyle)
        //        return new MyOffice2013BackstageViewInfo(this);
        //    return base.CreateViewInfo();
        //}
        //protected override void CloseBackStageView()
        //{
        //        MessageBox.Show("TEST");
        //        base.CloseBackStageView();
        //}
        //{
        //    MyOffice2013BackstageViewInfo vi = ViewInfo as MyOffice2013BackstageViewInfo;
        //    if (!ShouldClose(vi))
        //        return;
        //    base.OnBackButtonClick();
        //}
        //protected virtual bool ShouldClose()
        //{
        //    return false;

        //}
    }

    //public class MyOffice2013BackstageViewInfo : Office2013BackstageViewInfo
    //{
    //    public MyOffice2013BackstageViewInfo(BackstageViewControl control)
    //        : base(control)
    //    {
    //    }
    //    protected internal ObjectState BackButtonStateCore { get { return BackButtonInfo.State; } }
    //    protected override ObjectState GetBackButtonState()
    //    {
    //        MyBackstageViewControl control = Control as MyBackstageViewControl;
    //        ObjectState state = base.GetBackButtonState();
    //        if (!control.BackButtonEnabled)
    //            state |= ObjectState.Disabled;
    //        return state;
    //    }
    //    protected override BackstageViewBackButtonInfo CreateBackButtonInfo()
    //    {
    //        return new MyBackstageViewBackButtonInfo(this);
    //    }
    //}

    //public class MyBackstageViewBackButtonInfo : BackstageViewBackButtonInfo
    //{
    //    public MyBackstageViewBackButtonInfo(MyOffice2013BackstageViewInfo viewInfo)
    //        : base(viewInfo)
    //    {
    //    }
    //    protected override int CalcImageIndex(ObjectState state)
    //    {
    //        if ((state & ObjectState.Disabled) > 0)
    //        {
    //            return 2;
    //        }
    //        return base.CalcImageIndex(state);
    //    }
    //}

    //public class MyOffice2013BackstageViewPainter : Office2013BackstageViewPainter
    //{
    //    protected override void DrawBackButton(GraphicsCache cache, Office2013BackstageViewInfo viewInfo)
    //    {
    //        MyBackstageViewControl control = viewInfo.Control as MyBackstageViewControl;
    //        if (!control.ShowBackButton)
    //            return;
    //        base.DrawBackButton(cache, viewInfo);
    //    }
    //}
}
