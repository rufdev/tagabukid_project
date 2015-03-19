namespace WpfHelpers
{
    public static class RegionNames
    {
        public const string BackStageNav = "BackStageNav";
        public const string RibbonDefaultPageCategoryRegion = "RibbonDefaultPageCategoryRegion";
        public const string NavVarControlRegion = "NavVarControlRegion";
        public const string DocumentRegion = "DocumentRegion";
    }

    public interface IPanelInfo
    {
        string GetPanelCaption();
    }
}
