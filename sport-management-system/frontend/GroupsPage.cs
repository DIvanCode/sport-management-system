using sport_management_system.frontend.library;
using DataObject = sport_management_system.frontend.library.DataObject;

namespace sport_management_system.frontend;

public class GroupsPage : Page
{
    private DataObject EventName;
    private DataObject EventDate;
    private Table GroupTable;
    
    public GroupsPage()
    {
        InitializeMethods.Add(InitializeEventName);
        InitializeMethods.Add(InitializeEventDate);
        InitializeMethods.Add(InitializeGroupTable);
        InitializeMethods.Add(InitializeReturnButton);
        
        InitializeForm("GroupsPage", "Группы " + Event.Name);
    }
    
    private void InitializeEventName()
    {
        EventName = new DataObject("Name", 
            new Point(PageHandler.GetDIP(20), PageHandler.GetDIP(20)),
            "Турнир: ", Event.Name);
        
        Controls.Add(EventName.InitializeHeader());
        Controls.Add(EventName.InitializeData());
    }
    private void InitializeEventDate()
    {
        EventDate = new DataObject("Date", 
            new Point(PageHandler.GetDIP(20), PageHandler.GetDIP(100)),
            "Дата: ", Event.Date);
        
        Controls.Add(EventDate.InitializeHeader());
        Controls.Add(EventDate.InitializeData());
    }

    private void InitializeGroupTable()
    {
        GroupTable = new Table("GroupTable", new Point(20, 270), Event.Groups.Count + 1, 2);
        GroupTable.SetColumnWidth(1, 800);
        GroupTable.SetColumnWidth(0, 800);
        for (int i = 0; i < Event.Groups.Count + 1; i++)
        {
            GroupTable.SetRowHeight(i, 100);
        }

        var FirstRowData = new List<string> { "Группа", "Маршрут" };
        for (int i = 0; i < 2; i++)
        {
            Controls.Add(GroupTable.InitializeCell(0, i, FirstRowData[i]));
        }

        int uk = 1;
        foreach (var it in Event.Groups)
        {
            Controls.Add(GroupTable.InitializeCell(uk, 0, it.Key));
            Controls.Add(GroupTable.InitializeCell(uk, 1, it.Value.Route));
            
            GroupTable.AddClickAction(uk, 0, ViewGroup_Click);
            
            uk++;
        }
    }

    private void InitializeReturnButton()
    {
        Controls.Add(new ReturnButton("GroupsPage", "Назад"));
    }

    private void ViewGroup_Click(object? sender, EventArgs eventArgs)
    {
        var groupLabel = (Label)sender!;
        var groupName = groupLabel.Text;
        
        Hide();
        PageHandler.PagesHistory.Push(new GroupPage(groupName));
        PageHandler.PagesHistory.Peek().Show();
    }
}