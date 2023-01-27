using sport_management_system.frontend.library;
using DataObject = sport_management_system.frontend.library.DataObject;

namespace sport_management_system.frontend;

public class EventPage : Page
{
    private DataObject nameObject;
    private DataObject dateObject;
    
    private DataLoadObject routesLoadObject;
    private DataLoadObject groupsLoadObject;
    private DataLoadObject checkpointsLoadObject;
    private DataLoadObject applicationsLoadObject;
    
    private DataLoadObject startProtocolLoadObject;
    private DataLoadObject checkpointsProtocolsLoadObject;
    private DataLoadObject resultProtocolLoadObject;
    
    private DataLoadObject teamsResultsProtocolLoadObject;
    
    public EventPage()
    {
        InitializeMethods.Add(InitializeNameObject);
        InitializeMethods.Add(InitializeDateObject);
        
        InitializeMethods.Add(InitializeRoutesDataLoadObject);
        InitializeMethods.Add(InitializeGroupsDataLoadObject);
        InitializeMethods.Add(InitializeCheckpointsDataLoadObject);
        InitializeMethods.Add(InitializeApplicationsDataLoadObject);
        
        InitializeMethods.Add(InitializeStartProtocolsDataLoadObject);
        InitializeMethods.Add(InitializeCheckpointsProtocolsDataLoadObject);
        InitializeMethods.Add(InitializeResultProtocolsDataLoadObject);
        
        InitializeMethods.Add(InitializeTeamsResultsProtocolDataLoadObject);

        InitializeMethods.Add(InitializeReturnButton);
        
        InitializeForm("EventPage", Event.Name);
    }

    private void InitializeNameObject()
    {
        nameObject = new DataObject("Name", 
            new Point(PageHandler.GetDIP(20), PageHandler.GetDIP(20)),
            "Название: ", Event.Name);
        
        Controls.Add(nameObject.InitializeHeader());
        Controls.Add(nameObject.InitializeData());
    }
    
    private void InitializeDateObject()
    {
        dateObject = new DataObject("Name", 
            new Point(PageHandler.GetDIP(20), PageHandler.GetDIP(100)),
            "Дата: ", Event.Date);
        
        Controls.Add(dateObject.InitializeHeader());
        Controls.Add(dateObject.InitializeData());
    }

    private void InitializeRoutesDataLoadObject()
    {
        routesLoadObject = new DataLoadObject("Routes", "Маршруты", new Point(20, 150));
        
        Controls.Add(routesLoadObject.InitializeHeaderLabel());
        Controls.Add(routesLoadObject.InitializeLoadButton(RoutesLoadButton_Click));
    }

    private void RoutesLoadButton_Click(object? sender, EventArgs e)
    {
        Event.LoadRoutes(FileHandler.SelectFile());
        routesLoadObject.Load();
        
        Controls.Add(groupsLoadObject.InitializeLoadButton(GroupsLoadButton_Click));
    }
    
    private void InitializeGroupsDataLoadObject()
    {
        groupsLoadObject = new DataLoadObject("Groups", "Группы", new Point(20, 220));
        
        Controls.Add(groupsLoadObject.InitializeHeaderLabel());
    }

    private void GroupsLoadButton_Click(object? sender, EventArgs e)
    {
        Event.LoadGroups(FileHandler.SelectFile());
        groupsLoadObject.Load();
        
        Controls.Add(groupsLoadObject.InitializeShowButton(GroupsShowButton_Click));
        
        Controls.Add(checkpointsLoadObject.InitializeLoadButton(CheckpointsLoadButton_Click));
    }
    
    private void GroupsShowButton_Click(object? sender, EventArgs e)
    {
        Hide();
        PageHandler.PagesHistory.Push(new GroupsPage());
        PageHandler.PagesHistory.Peek().Show();
    }
    
    private void InitializeCheckpointsDataLoadObject()
    {
        checkpointsLoadObject = new DataLoadObject("Checkpoints", "Чекпоинты", new Point(20, 290));
        
        Controls.Add(checkpointsLoadObject.InitializeHeaderLabel());
    }

    private void CheckpointsLoadButton_Click(object? sender, EventArgs e)
    {
        Event.LoadCheckpoints(FileHandler.SelectFile());
        checkpointsLoadObject.Load();
        
        Controls.Add(applicationsLoadObject.InitializeLoadButton(ApplicationsLoadButton_Click));
    }
    
    private void InitializeApplicationsDataLoadObject()
    {
        applicationsLoadObject = new DataLoadObject("Applications", "Заявки", new Point(20, 360));
        
        Controls.Add(applicationsLoadObject.InitializeHeaderLabel());
    }

    private void ApplicationsLoadButton_Click(object? sender, EventArgs e)
    {
        Event.LoadApplications(FileHandler.SelectPath());
        applicationsLoadObject.Load();
        
        Controls.Add(startProtocolLoadObject.InitializeFormButton(StartProtocolsFormButton_Click));
    }
    
    private void InitializeStartProtocolsDataLoadObject()
    {
        startProtocolLoadObject = new DataLoadObject("StartProtocols", "Стартовые протоколы", new Point(20, 430));
        
        Controls.Add(startProtocolLoadObject.InitializeHeaderLabel());
    }

    private void StartProtocolsFormButton_Click(object? sender, EventArgs e)
    {
        Event.FormStartProtocols();
        startProtocolLoadObject.Load();
        
        Controls.Add(startProtocolLoadObject.InitializeOutputButton(StartProtocolsOutputButton_Click));
        
        Controls.Add(checkpointsProtocolsLoadObject.InitializeLoadButton(CheckpointsProtocolsLoadButton_Click));
    }
    
    private void StartProtocolsOutputButton_Click(object? sender, EventArgs e)
    {
        Event.OutputStartProtocols(FileHandler.SelectPath());
        startProtocolLoadObject.Output();
    }
    
    private void InitializeCheckpointsProtocolsDataLoadObject()
    {
        checkpointsProtocolsLoadObject = new DataLoadObject("Checkpoints", "Протоколы чекпоинтов", new Point(20, 500));
        
        Controls.Add(checkpointsProtocolsLoadObject.InitializeHeaderLabel());
    }
    
    private void CheckpointsProtocolsLoadButton_Click(object? sender, EventArgs e)
    {
        Event.LoadCheckpointsProtocols(FileHandler.SelectPath());
        checkpointsProtocolsLoadObject.Load();
        
        Controls.Add(resultProtocolLoadObject.InitializeFormButton(ResultProtocolsFormButton_Click));
    }
    
    private void InitializeResultProtocolsDataLoadObject()
    {
        resultProtocolLoadObject = new DataLoadObject("ResultProtocols", "Протоколы результатов", new Point(20, 570));
        
        Controls.Add(resultProtocolLoadObject.InitializeHeaderLabel());
    }

    private void ResultProtocolsFormButton_Click(object? sender, EventArgs e)
    {
        Event.FormResultProtocols();
        resultProtocolLoadObject.Load();
        
        Controls.Add(resultProtocolLoadObject.InitializeOutputButton(ResultProtocolsOutputButton_Click));
        
        Controls.Add(teamsResultsProtocolLoadObject.InitializeFormButton(TeamsResultsProtocolFormButton_Click));
    }
    
    private void ResultProtocolsOutputButton_Click(object? sender, EventArgs e)
    {
        Event.OutputResultProtocols(FileHandler.SelectPath());
        resultProtocolLoadObject.Output();
    }
    
    private void InitializeTeamsResultsProtocolDataLoadObject()
    {
        teamsResultsProtocolLoadObject = new DataLoadObject("TeamsResultsProtocols", "Командные результаты", new Point(20, 640));
        
        Controls.Add(teamsResultsProtocolLoadObject.InitializeHeaderLabel());
    }

    private void TeamsResultsProtocolFormButton_Click(object? sender, EventArgs e)
    {
        Event.FormTeamsResultsProtocol();
        teamsResultsProtocolLoadObject.Load();
        
        Controls.Add(teamsResultsProtocolLoadObject.InitializeOutputButton(TeamsResultsProtocolOutputButton_Click));
    }
    
    private void TeamsResultsProtocolOutputButton_Click(object? sender, EventArgs e)
    {
        Event.OutputTeamsResultsProtocol(FileHandler.SelectPath());
        teamsResultsProtocolLoadObject.Output();
        
        Controls.Add(teamsResultsProtocolLoadObject.InitializeShowButton(TeamsResultsProtocolShowButton_Click));
    }

    private void TeamsResultsProtocolShowButton_Click(object? sender, EventArgs e)
    {
        Hide();
        PageHandler.PagesHistory.Push(new TeamsResultsProtocolPage());
        PageHandler.PagesHistory.Peek().Show();
    }

    private void InitializeReturnButton()
    {
        Controls.Add(new ReturnButton("EventPage", "Закончить"));
    }
}