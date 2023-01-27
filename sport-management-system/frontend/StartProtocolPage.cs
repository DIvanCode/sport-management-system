using sport_management_system.frontend.library;
using DataObject = sport_management_system.frontend.library.DataObject;

namespace sport_management_system.frontend;

public class StartProtocolPage : Page
{
    private string GroupName;
    
    private DataObject eventNameObject;
    private DataObject eventDateObject;
    private DataObject groupNameObject;
    private DataObject groupRouteObject;

    private Table startProtocolTable;
    
    public StartProtocolPage(string groupName)
    {
        GroupName = groupName;
        
        InitializeMethods.Add(InitializeEventNameObject);
        InitializeMethods.Add(InitializeEventDateObject);
        
        InitializeMethods.Add(InitializeGroupNameObject);
        InitializeMethods.Add(InitializeGroupRouteObject);
        
        InitializeMethods.Add(InitializeStartProtocolTable);
        
        InitializeMethods.Add(InitializeReturnButton);
        
        InitializeForm("StartProtocolPage" + groupName, "Стартовый протокол " + groupName);
    }
    
    private void InitializeEventNameObject()
    {
        eventNameObject = new DataObject("EventName", 
            new Point(PageHandler.GetDIP(20), PageHandler.GetDIP(20)),
            "Название: ", Event.Name);
        
        Controls.Add(eventNameObject.InitializeHeader());
        Controls.Add(eventNameObject.InitializeData());
    }
    
    private void InitializeEventDateObject()
    {
        eventDateObject = new DataObject("EventDate", 
            new Point(PageHandler.GetDIP(20), PageHandler.GetDIP(100)),
            "Дата: ", Event.Date);
        
        Controls.Add(eventDateObject.InitializeHeader());
        Controls.Add(eventDateObject.InitializeData());
    }
    
    private void InitializeGroupNameObject()
    {
        groupNameObject = new DataObject("GroupName", 
            new Point(PageHandler.GetDIP(20), PageHandler.GetDIP(180)),
            "Название: ", GroupName);
        
        Controls.Add(groupNameObject.InitializeHeader());
        Controls.Add(groupNameObject.InitializeData());
    }
    
    private void InitializeGroupRouteObject()
    {
        groupRouteObject = new DataObject("GroupRoute", 
            new Point(PageHandler.GetDIP(20), PageHandler.GetDIP(260)),
            "Маршрут: ", Event.Groups[GroupName].Route);
        
        Controls.Add(groupRouteObject.InitializeHeader());
        Controls.Add(groupRouteObject.InitializeData());
    }
    
    private void InitializeStartProtocolTable()
    {
        var startProtocol = Event.Groups[GroupName].GroupStartProtocol;

        var rowsCount = startProtocol.ParticipantsProtocols.Count;
        var columnsCount = 6;

        startProtocolTable = new Table("StartProtocol",
            new Point(80, 380), rowsCount + 1, columnsCount);

        for (var rowIndex = 0; rowIndex <= rowsCount; ++rowIndex)
        {
            startProtocolTable.SetRowHeight(rowIndex, PageHandler.SmallHeight);
        }
        
        startProtocolTable.SetColumnWidth(0, 75);
        startProtocolTable.SetColumnWidth(1, 400);
        startProtocolTable.SetColumnWidth(2, 300);
        startProtocolTable.SetColumnWidth(3, 350);
        startProtocolTable.SetColumnWidth(4, 300);
        startProtocolTable.SetColumnWidth(5, 300);

        var firstRowData = new List<string> {
            "№", "Фамилия", "Имя", "Год рождения", "Команда", "Время старта"
        };

        for (var columnIndex = 0; columnIndex < columnsCount; ++columnIndex)
        {
            Controls.Add(startProtocolTable.InitializeCell(0, columnIndex, firstRowData[columnIndex]));
        }
        
        for (var rowIndex = 1; rowIndex <= rowsCount; ++rowIndex)
        {
            var rowData = startProtocol.ParticipantsProtocols[rowIndex - 1].FormData();
            for (var columnIndex = 0; columnIndex < columnsCount; ++columnIndex)
            {
                Controls.Add(startProtocolTable.InitializeCell(rowIndex, columnIndex, rowData[columnIndex]));                
            }
        }
    }
    
    private void InitializeReturnButton()
    {
        Controls.Add(new ReturnButton("StartProtocolPage", "Назад"));
    }
}