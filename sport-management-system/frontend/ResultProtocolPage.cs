using sport_management_system.frontend.library;
using DataObject = sport_management_system.frontend.library.DataObject;

namespace sport_management_system.frontend;

public class ResultProtocolPage : Page
{
    private string GroupName;

    private DataObject eventNameObject;
    private DataObject eventDateObject;
    private DataObject groupNameObject;
    private DataObject groupRouteObject;

    private Table resultProtocolTable;
    
    public ResultProtocolPage(string groupName)
    {
        GroupName = groupName;
        
        InitializeMethods.Add(InitializeEventNameObject);
        InitializeMethods.Add(InitializeEventDateObject);
        
        InitializeMethods.Add(InitializeGroupNameObject);
        InitializeMethods.Add(InitializeGroupRouteObject);
        
        InitializeMethods.Add(InitializeResultProtocolTable);
        
        InitializeMethods.Add(InitializeReturnButton);
        
        InitializeForm("ResultProtocolPage" + groupName, "Результаты " + groupName);
    }
    
    private void InitializeEventNameObject()
    {
        eventNameObject = new DataObject("EventName", 
            new Point(PageHandler.GetDIP(20), PageHandler.GetDIP(20)),
            "Турнир: ", Event.Name);
        
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

    private void InitializeResultProtocolTable()
    {
        var resultProtocol = Event.Groups[GroupName].GroupResultProtocol;
        
        var rowsCount = resultProtocol.ParticipantsProtocols.Count;
        var columnsCount = 7;
        
        resultProtocolTable = new Table("ResultProtocol",
            new Point(80, 380), rowsCount + 1, columnsCount);
        
        for (var rowIndex = 0; rowIndex <= rowsCount; ++rowIndex)
        {
            resultProtocolTable.SetRowHeight(rowIndex, PageHandler.SmallHeight);
        }
        
        resultProtocolTable.SetColumnWidth(0, 200);
        resultProtocolTable.SetColumnWidth(1, 75);
        resultProtocolTable.SetColumnWidth(2, 300);
        resultProtocolTable.SetColumnWidth(3, 300);
        resultProtocolTable.SetColumnWidth(4, 350);
        resultProtocolTable.SetColumnWidth(5, 250);
        resultProtocolTable.SetColumnWidth(6, 300);
        
        var firstRowData = new List<string> {
            "Место", "№", "Фамилия", "Имя", "Результат", "Время", "Отставание"
        };
        
        for (var columnIndex = 0; columnIndex < columnsCount; ++columnIndex)
        {
            Controls.Add(resultProtocolTable.InitializeCell(0, columnIndex, firstRowData[columnIndex]));
        }
        
        for (var rowIndex = 1; rowIndex <= rowsCount; ++rowIndex)
        {
            var rowData = resultProtocol.ParticipantsProtocols[rowIndex - 1].FormData();
            for (var columnIndex = 0; columnIndex < columnsCount; ++columnIndex)
            {
                Controls.Add(resultProtocolTable.InitializeCell(rowIndex, columnIndex, rowData[columnIndex]));                
            }
        }
        
    }
    
    private void InitializeReturnButton()
    {
        Controls.Add(new ReturnButton("ResultProtocolPage", "Назад"));
    }
}