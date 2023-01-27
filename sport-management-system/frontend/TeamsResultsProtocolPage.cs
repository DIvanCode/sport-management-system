using System.Globalization;
using sport_management_system.frontend.library;
using DataObject = sport_management_system.frontend.library.DataObject;

namespace sport_management_system.frontend;

public class TeamsResultsProtocolPage : Page
{
    private DataObject eventNameObject;
    private DataObject eventDateObject;

    private Table teamsResultsProtocolTable;
    
    public TeamsResultsProtocolPage()
    {
        InitializeMethods.Add(InitializeEventNameObject);
        InitializeMethods.Add(InitializeEventDateObject);
        
        InitializeMethods.Add(InitializeTeamsResultsProtocolTable);
        
        InitializeMethods.Add(InitializeReturnButton);
        
        InitializeForm("TeamsResultsProtocolPage", "Командные результаты " + Event.Name);
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
    
    private void InitializeTeamsResultsProtocolTable()
    {
        var teamsResultsProtocol = Event.EventTeamsResultsProtocol; 
        var rowsCount = teamsResultsProtocol!.TeamsRating.Count;
        
        var columnsCount = 3;

        teamsResultsProtocolTable = new Table("TeamsResultsProtocolTable",
            new Point(80, 200), rowsCount + 1, columnsCount);

        for (var rowIndex = 0; rowIndex <= rowsCount; ++rowIndex)
        {
            teamsResultsProtocolTable.SetRowHeight(rowIndex, PageHandler.SmallHeight);
        }
        
        teamsResultsProtocolTable.SetColumnWidth(0, 300);
        teamsResultsProtocolTable.SetColumnWidth(1, 400);
        teamsResultsProtocolTable.SetColumnWidth(2, 300);

        var firstRowData = new List<string> {
            "Место", "Команда", "Очки"
        };

        for (var columnIndex = 0; columnIndex < columnsCount; ++columnIndex)
        {
            Controls.Add(teamsResultsProtocolTable.InitializeCell(0, columnIndex, firstRowData[columnIndex]));
        }
        
        for (var rowIndex = 1; rowIndex <= rowsCount; ++rowIndex)
        {
            var teamName = teamsResultsProtocol.TeamsRating[rowIndex - 1]; 
            
            var rowData = new List<string>
            {
                rowIndex.ToString(),
                teamName,
                ((int)Event.Teams[teamName].Points).ToString(CultureInfo.InvariantCulture)
            };
            
            for (var columnIndex = 0; columnIndex < columnsCount; ++columnIndex)
            {
                Controls.Add(teamsResultsProtocolTable.InitializeCell(rowIndex, columnIndex, rowData[columnIndex]));                
            }
        }
    }
    
    private void InitializeReturnButton()
    {
        Controls.Add(new ReturnButton("TeamsResultsProtocolPage", "Назад"));
    }
}