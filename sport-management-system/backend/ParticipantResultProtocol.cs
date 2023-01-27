namespace sport_management_system;

public class ParticipantResultProtocol
{
    public string GroupName;
    public int ParticipantId;
    public int ResultsPlace;
    public int ResultTime;
    public int TimeToLeader;

    public ParticipantResultProtocol(string groupName, int participantId, int resultsPlace, int resultTime, int timeToLeader)
    {
        GroupName = groupName;
        ParticipantId = participantId;
        ResultsPlace = resultsPlace;
        ResultTime = resultTime;
        TimeToLeader = timeToLeader;
    }

    public List<string> FormData()
    {
        return new List<string>
        {
            ResultsPlace.ToString(),
            Event.Participants[ParticipantId].Number.ToString(),
            Event.Participants[ParticipantId].FirstName,
            Event.Participants[ParticipantId].LastName,
            Event.Participants[ParticipantId].TeamName,
            FileHandler.CreateTimeString(ResultTime),
            FileHandler.CreateTimeString(TimeToLeader)
        };
    }
    
    public override string ToString()
    {
        return FileHandler.CreateLine(FormData());
    }
}