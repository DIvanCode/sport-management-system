namespace sport_management_system;

public class CheckpointProtocol
{
    public string GroupName;
    public string CheckpointName;
    
    public List<ParticipantCheckpointProtocol> ParticipantsProtocols;

    public CheckpointProtocol(string groupName, string checkpointName)
    {
        GroupName = groupName;
        CheckpointName = checkpointName;

        ParticipantsProtocols = new List<ParticipantCheckpointProtocol>();
    }

    public void AddParticipantCheckpointProtocol(ParticipantCheckpointProtocol protocol)
    {
        ParticipantsProtocols.Add(protocol);
    }
}