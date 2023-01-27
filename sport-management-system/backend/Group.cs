namespace sport_management_system;

public class Group
{
    private const int GROUP_START_TIME = 43200; // 12:00:00
    private const int PARTICIPANTS_START_INTERVAL = 60;    // 00:01:00
    
    public string Name;
    public string Route;
    
    public List<int> ParticipantsIds;
    
    public StartProtocol? GroupStartProtocol;    
    public List<CheckpointProtocol> CheckpointsProtocols;
    public ResultProtocol? GroupResultProtocol;
    
    private static Random rng = new();

    public Group(string name, string route)
    {
        Name = name;
        Route = route;

        ParticipantsIds = new List<int>();
        CheckpointsProtocols = new List<CheckpointProtocol>();
    }
    
    public bool ConfirmParticipant(Participant participant)
    {
        if (participant.Group != Name) return false;
        ParticipantsIds.Add(participant.Id);
        return true;
    }

    public void FormStartProtocol()
    {
        GroupStartProtocol = new StartProtocol(Name);
        
        ParticipantsIds = ParticipantsIds.OrderBy(_ => rng.Next()).ToList();

        var currentStartTime = GROUP_START_TIME;
        var currentNumber = 1;
        
        foreach (var participantId in ParticipantsIds)
        {
            var participantStartProtocol = new ParticipantStartProtocol(Name, participantId, currentStartTime);
            currentStartTime += PARTICIPANTS_START_INTERVAL;
            
            GroupStartProtocol.AddParticipantProtocol(participantStartProtocol);
            
            Event.Participants[participantId].Number = currentNumber;
            Event.Participants[participantId].EventStartProtocol = participantStartProtocol;
            
            currentNumber++;
        }
    }

    public void OutputStartProtocol(string file)
    {
        GroupStartProtocol.Output(file);
    }

    public void AddCheckpointProtocol(CheckpointProtocol protocol)
    {
        CheckpointsProtocols.Add(protocol);
    }
    
    private Dictionary<int, int> CalculateResultTimes()
    {
        var resultTimes = new Dictionary<int, int>();

        foreach (var participantId in ParticipantsIds)
        {
            var participant = Event.Participants[participantId];
            
            var checkpointsProtocols = participant.CheckpointsProtocols;

            var resultTime = int.MinValue;
            foreach (var checkpointProtocol in checkpointsProtocols)
            {
                var startTime = participant.EventStartProtocol.StartTime;
                resultTime = Math.Max(resultTime, checkpointProtocol.PassTime - startTime);
            }

            resultTimes[participantId] = resultTime;
        }

        return resultTimes;

    }

    public void FormResultsProtocol()
    {
        GroupResultProtocol = new ResultProtocol(Name);

        if (ParticipantsIds.Count == 0)
        {
            return;
        }

        var participantsRating = ParticipantsIds;
        var resultTime = CalculateResultTimes();
        
        participantsRating.Sort(delegate(int x, int y)
        {
            if (resultTime[x] < resultTime[y]) return -1;
            return 1;
        });

        var leaderResultTime = resultTime[participantsRating[0]];
        var place = 1;

        foreach (var participantId in participantsRating)
        {
            var timeToLeader = resultTime[participantId] - leaderResultTime;
            
            var participantResultProtocol = new ParticipantResultProtocol(
                Name,
                participantId,
                place,
                resultTime[participantId], 
                timeToLeader);
            
            GroupResultProtocol.AddParticipantProtocol(participantResultProtocol);
            Event.Participants[participantId].EventResultProtocol = participantResultProtocol;

            ++place;
        }
    }
    
    public void OutputResultsProtocol(string file)
    {
        GroupResultProtocol.Output(file);
    }
}