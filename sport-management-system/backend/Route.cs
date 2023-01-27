namespace sport_management_system;

public class Route
{
    public string Name;
    public List<string> Checkpoints;

    public Route(string name)
    {
        Name = name;

        Checkpoints = new List<string>();
    }

    public void AddCheckpoint(string checkpointName)
    {
        Checkpoints.Add(checkpointName);
    }
}