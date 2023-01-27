namespace sport_management_system;

public class Participant
{
    public int Id;
    public string FirstName;
    public string LastName;
    public string BirthDate;
    public string Category;
    
    public int Number;
    public string TeamName;
    public string Group;
    public double Points;
    
    public ParticipantStartProtocol EventStartProtocol;
    public List<ParticipantCheckpointProtocol> CheckpointsProtocols;
    public ParticipantResultProtocol EventResultProtocol;
    
    public Participant(int id,
        string firstName,
        string lastName,
        string birthDate,
        string category,
        string desiredGroup,
        string teamName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Category = category;
        Group = desiredGroup;
        TeamName = teamName;

        CheckpointsProtocols = new List<ParticipantCheckpointProtocol>();
    }

    public void AddCheckpointProtocol(ParticipantCheckpointProtocol protocol)
    {
        CheckpointsProtocols.Add(protocol);
    }

    public void CalculatePoints()
    {
        var num = EventResultProtocol.ResultTime;
        var denum = EventResultProtocol.ResultTime - EventResultProtocol.TimeToLeader;
        
        Points = 100.0 * (2.0 - (Convert.ToDouble(num) / Convert.ToDouble(denum)));
        
        if (Points < 0)
        {
            Points = 0.0;
        }
    }
}