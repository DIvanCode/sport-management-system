namespace sport_management_system;

public static class Event
{
    public static string Name;
    public static string Date;
    
    public static Dictionary<string, Checkpoint> Checkpoints;
    public static Dictionary<string, Route> Routes;
    public static Dictionary<string, Group> Groups;
    public static Dictionary<string, Team> Teams;
    
    public static List<Participant> Participants;

    public static TeamsResultsProtocol? EventTeamsResultsProtocol;

    public static void Load(string eventFilePath)
    {
        var eventFile = FileHandler.ReadAllLines(eventFilePath);
        if (eventFile.Count != 2)
        {
            FileHandler.RunException();
        }

        Name = eventFile[1][0];
        Date = eventFile[1][1];
        
        ClearData();
    }

    private static void ClearData()
    {
        Checkpoints = new Dictionary<string, Checkpoint>();
        Routes = new Dictionary<string, Route>();
        Groups = new Dictionary<string, Group>();
        Teams = new Dictionary<string, Team>();
        
        Participants = new List<Participant>();
        
        EventTeamsResultsProtocol = null;
    }

    public static void LoadRoutes(string routesFilePath)
    {
        var routes = FileHandler.ReadAllLines(routesFilePath);

        foreach (var routeLine in routes)
        {
            if (routeLine.Count < 3)
            {
                FileHandler.RunException();
            }

            var routeName = routeLine[0];

            var route = new Route(routeName);

            foreach (var checkpointName in routeLine.Skip(1))
            {
                route.AddCheckpoint(checkpointName);
            }

            Routes[routeName] = route;
        }
    }

    public static void LoadGroups(string groupsFilePath)
    {
        var groups = FileHandler.ReadAllLines(groupsFilePath);

        if (groups.Count == 0)
        {
            FileHandler.RunException();
        }

        foreach (var groupLine in groups.Skip(1))
        {
            if (groupLine.Count != 2)
            {
                FileHandler.RunException();
            }

            var groupName = groupLine[0];
            var groupRoute = groupLine[1];

            Groups[groupName] = new Group(groupName, groupRoute);
        }
    }

    public static void LoadCheckpoints(string checkpointsFilePath)
    {
        var checkpoints = FileHandler.ReadAllLines(checkpointsFilePath);
        
        foreach (var checkpointLine in checkpoints.Skip(1))
        {
            if (checkpointLine.Count != 2)
            {
                FileHandler.RunException();
            }

            var checkpointName = checkpointLine[0];
            
            if (!int.TryParse(checkpointLine[1], out var checkpointDistance))
            {
                FileHandler.RunException();
            }
            
            Checkpoints[checkpointName] = new Checkpoint(checkpointName, checkpointDistance);
        }
    }

    public static void LoadApplications(string applicationsDirPath)
    {
        var applicationsFiles = FileHandler.GetDirFilesNames(applicationsDirPath);

        foreach (var applicationFile in applicationsFiles)
        {
            var lastGo = applicationFile.LastIndexOf('/');
            var application = FileHandler.ReadAllLines(applicationFile[(lastGo+1)..]);

            if (application.Count < 1)
            {
                FileHandler.RunException();
            }

            var teamName = application[0][0];

            var team = new Team(teamName);

            foreach (var applicationLine in application.Skip(2))
            {
                if (applicationLine.Count != 5)
                {
                    FileHandler.RunException();
                }

                var desiredGroupName = applicationLine[0];
                var lastName = applicationLine[1];
                var firstName = applicationLine[2];
                var birthDate = applicationLine[3];
                var category = applicationLine[4];

                var participantId = Participants.Count;

                var participant = new Participant(participantId, firstName, lastName, birthDate, category, desiredGroupName, teamName);

                if (!Groups[desiredGroupName].ConfirmParticipant(participant)) continue;
                
                Participants.Add(participant);
                team.AddParticipant(participantId);
            }

            Teams[teamName] = team;
        }
    }

    public static void LoadCheckpointsProtocols(string checkpointsProtocolsFilePath)
    {
        var protocolsFiles = FileHandler.GetDirFilesNames(checkpointsProtocolsFilePath);
        
        foreach (var protocolFile in protocolsFiles)
        {
            var lastGo = protocolFile.LastIndexOf('/');
            var protocol = FileHandler.ReadAllLines(protocolFile[(lastGo+1)..]);

            if (protocol.Count < 1)
            {
                FileHandler.RunException();
            }

            var groupName = protocol[0][0];
            var order = new List<int>();

            foreach (var number in protocol[1].Skip(1))
            {
                order.Add(int.Parse(number));
            }

            foreach (var row in protocol.Skip(2))
            {
                var checkpointName = row[0];

                var checkpointProtocol = new CheckpointProtocol(groupName, checkpointName);

                for (var i = 0; i + 1 < row.Count; ++i)
                {
                    var passTimeString = row[i + 1];
                    var participantId = Groups[groupName].ParticipantsIds[order[i] - 1];

                    var hours = int.Parse(passTimeString[..2]);
                    var minutes = int.Parse(passTimeString[3..5]);
                    var seconds = int.Parse(passTimeString[6..8]);

                    var passTime = hours * 3600 + minutes * 60 + seconds;

                    var participantCheckpointProtocol = new ParticipantCheckpointProtocol(
                        groupName, participantId, checkpointName, passTime);
                    
                    checkpointProtocol.AddParticipantCheckpointProtocol(participantCheckpointProtocol);
                    
                    Participants[participantId].AddCheckpointProtocol(participantCheckpointProtocol);
                }
                
                AddCheckpointProtocol(groupName, checkpointProtocol);
            }
        }
    }

    public static void FormStartProtocols()
    {
        foreach (var item in Groups)
        {
            Groups[item.Key].FormStartProtocol();
        };
    }

    public static void OutputStartProtocols(string startProtocolsDirPath)
    {   
        foreach (var (groupName, group) in Groups)
        {
            var filePath = startProtocolsDirPath + "/" + groupName + ".csv";
            
            FileHandler.ClearFile(filePath);
            
            group.OutputStartProtocol(filePath);
        }
    }

    public static void AddCheckpointProtocol(string groupName, CheckpointProtocol protocol)
    {
        Groups[groupName].AddCheckpointProtocol(protocol);
    }
    
    public static void FormResultProtocols()
    {
        foreach (var item in Groups)
        {
            Groups[item.Key].FormResultsProtocol();
        }
    }

    public static void OutputResultProtocols(string resultProtocolsDirPath)
    {
        foreach (var (groupName, group) in Groups)
        {
            var filePath = resultProtocolsDirPath + "/" + groupName + ".csv";
            
            FileHandler.ClearFile(filePath);
            
            group.OutputResultsProtocol(filePath);
        }
    }
    
    public static void FormTeamsResultsProtocol()
    {
        EventTeamsResultsProtocol = new TeamsResultsProtocol();
        EventTeamsResultsProtocol.CreateProtocol();
    }
    
    public static void OutputTeamsResultsProtocol(string teamsResultsProtocolDirPath)
    {
        if (EventTeamsResultsProtocol == null)
        {
            FormTeamsResultsProtocol();
        }
        
        EventTeamsResultsProtocol!.OutputProtocol(teamsResultsProtocolDirPath + "/teams-results.csv");
    }
}

