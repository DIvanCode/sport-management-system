namespace sport_management_system;

public class Team
{
    public string Name;
    public double Points;
    
    public List<int> Participants;

    public Team(string name)
    {
        Name = name;
        Points = 0;

        Participants = new List<int>();
    }
    
    public void AddParticipant(int participantId)
    {
        Participants.Add(participantId);
    }

    public void CalculatePoints()
    {
        Points = 0.0;
        foreach (var item in Participants)
        {
            Event.Participants[item].CalculatePoints();
            Points += Event.Participants[item].Points;
        }
    }
}