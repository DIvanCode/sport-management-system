using System.Globalization;

namespace sport_management_system;

public class TeamsResultsProtocol
{
    public List<string> TeamsRating;

    public TeamsResultsProtocol()
    {
        TeamsRating = new List<string>();
    }

    public void CreateProtocol()
    {
        foreach (var (teamName, team) in Event.Teams)
        {
            team.CalculatePoints();
            
            TeamsRating.Add(teamName);
        }

        TeamsRating.Sort(delegate(string x, string y)
        {
            if (Event.Teams[x].Points > Event.Teams[y].Points)
            {
                return -1;
            }

            return 1;
        });
    }

    public void OutputProtocol(string file)
    {
        FileHandler.ClearFile(file);
        
        FileHandler.AppendData(file, new List<string> {"Место", "Команда", "Очки"});

        var place = 1;
        
        foreach (var teamName in TeamsRating)
        {
            FileHandler.AppendData(file, new List<string>
            {
                place.ToString(),
                teamName,
                ((int)Event.Teams[teamName].Points).ToString(CultureInfo.InvariantCulture)
            });

            place++;
        }
    }
}