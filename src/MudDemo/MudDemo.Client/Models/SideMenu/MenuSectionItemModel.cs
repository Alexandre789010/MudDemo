namespace MudDemo.Client.Models.SideMenu;

public class MenuSectionItemModel
{
    public string Title { get; set; }
    public string Icon { get; set; }
    public string Href { get; set; }
    public bool IsParent { get; set; }
    public List<MenuSectionSubItemModel> MenuItems { get; set; }
}