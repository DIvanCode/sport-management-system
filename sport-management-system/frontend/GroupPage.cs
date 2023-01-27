using sport_management_system.frontend.library;
using DataObject = sport_management_system.frontend.library.DataObject;

namespace sport_management_system.frontend;

public class GroupPage : Page
{
    private string GroupName;
    private DataObject EventName;
    private DataObject EventDate;
    private DataObject GroupNaming;
    private DataObject GroupRoute;

    private DataLoadObject StartProtocol;
    private DataLoadObject CheckpointsProtocol;
    private DataLoadObject ResultProtocol;

    public GroupPage(string groupName)
    {
        GroupName = groupName;
        
        InitializeMethods.Add(InitializeEventName);
        InitializeMethods.Add(InitializeEventDate);
        
        InitializeMethods.Add(InitializeGroupNaming);
        InitializeMethods.Add(InitializeGroupRoute);
        
        InitializeMethods.Add(InitializeStartProtocol);
        InitializeMethods.Add(InitializeResultProtocol);
        
        InitializeMethods.Add(InitializeReturnButton);
        
        InitializeForm("GroupPage" + groupName, groupName);
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
    private void InitializeGroupNaming()
    {
        GroupNaming = new DataObject("GroupNaming", 
            new Point(PageHandler.GetDIP(20), PageHandler.GetDIP(180)),
            "Название: ", GroupName);
        
        Controls.Add(GroupNaming.InitializeHeader());
        Controls.Add(GroupNaming.InitializeData());
    }
    private void InitializeGroupRoute()
    {
        GroupRoute = new DataObject("GroupRoute", 
            new Point(PageHandler.GetDIP(20), PageHandler.GetDIP(260)),
            "Маршрут: ", Event.Groups[GroupName].Route);
        
        Controls.Add(GroupRoute.InitializeHeader());
        Controls.Add(GroupRoute.InitializeData());
    }
    
    private void InitializeStartProtocol()
    {
        StartProtocol = new DataLoadObject("StartProtocol", 
            "Стартовый протокол", new Point(PageHandler.GetDIP(20), PageHandler.GetDIP(400)));
        
        Controls.Add(StartProtocol.InitializeHeaderLabel());

        if (Event.Groups[GroupName].GroupStartProtocol == null) return;
        
        StartProtocol.Load();
        Controls.Add(StartProtocol.InitializeShowButton(StartProtocolShowButton_Click));
    }

    private void StartProtocolShowButton_Click(object? sender, EventArgs e)
    {
        Hide();
        PageHandler.PagesHistory.Push(new StartProtocolPage(GroupName));
        PageHandler.PagesHistory.Peek().Show();
    }
    
    private void InitializeResultProtocol()
    {
        ResultProtocol = new DataLoadObject("ResultProtocol", 
            "Протокол результатов", new Point(PageHandler.GetDIP(20), PageHandler.GetDIP(500)));
        
        Controls.Add(ResultProtocol.InitializeHeaderLabel());

        if (Event.Groups[GroupName].GroupResultProtocol == null) return;
        
        ResultProtocol.Load();
        Controls.Add(ResultProtocol.InitializeShowButton(ResultProtocolShowButton_Click));
    }

    private void ResultProtocolShowButton_Click(object? sender, EventArgs e)
    {
        Hide();
        PageHandler.PagesHistory.Push(new ResultProtocolPage(GroupName));
        PageHandler.PagesHistory.Peek().Show();
    }

    private void InitializeReturnButton()
    {
        Controls.Add(new ReturnButton("GroupPage" + GroupName, "Назад"));
    }
}