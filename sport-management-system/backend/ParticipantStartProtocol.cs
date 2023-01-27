namespace sport_management_system;

public class ParticipantStartProtocol
{
    public string GroupName;
    public int ParticipantId;
    public int StartTime;

    public ParticipantStartProtocol(string groupName, int participantId, int startTime)
    {
        GroupName = groupName;
        ParticipantId = participantId;
        StartTime = startTime;
    }

    public List<string> FormData()
    {
        return new List<string>
        {
            Event.Participants[ParticipantId].Number.ToString(),
            Event.Participants[ParticipantId].FirstName,
            Event.Participants[ParticipantId].LastName,
            Event.Participants[ParticipantId].BirthDate,
            Event.Participants[ParticipantId].TeamName,
            FileHandler.CreateTimeString(StartTime)
        };
    }

    public override string ToString()
    {
        return FileHandler.CreateLine(FormData());
    }
}