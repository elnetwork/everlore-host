// ReSharper disable MemberHidesStaticFromOuterClass
namespace Everlore.Hero.Features.AddItem.Common;

public static class Feature
{
    public static readonly string Name = "AddItem";
}

public static class AddItemButton
{
    public static readonly string Label = "Add Item";
    public static readonly string ToolTip = "Add Item";

    public static class AddHeroAction
    {
        public static readonly string Label = "Add Hero";
        public static readonly string ToolTip = "Add Hero";
    }
    
    public static class AddSuperHeroAction
    {
        public static readonly string Label = "Add Superhero";
        public static readonly string ToolTip = "Add Superhero";
    }
}
