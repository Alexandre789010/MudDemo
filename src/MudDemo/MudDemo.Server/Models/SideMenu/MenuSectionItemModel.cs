namespace MudDemo.Server.Models.SideMenu;

public class MenuSectionItemModel
{
    public string Title { get; set; }
    public string Icon { get; set; }
    public string Href { get; set; }
    public PageStatus PageStatus { get; set; } = PageStatus.Completed;
    public bool IsParent { get; set; }
    public List<MenuSectionSubItemModel> MenuItems { get; set; }
}