namespace sport_management_system;

public class ParticipantCheckpointProtocol
{
    public string GroupName;
    public int ParticipantId;
    public string CheckpointName;
    public int PassTime;

    public ParticipantCheckpointProtocol(string groupName, int participantId, string checkpointName, int passTime)
    {
        GroupName = groupName;
        ParticipantId = participantId;
        CheckpointName = checkpointName;
        PassTime = passTime;
    }
}