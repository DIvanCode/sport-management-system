namespace sport_management_system;

public class ResultProtocol
{
    public string GroupName;
    public List<ParticipantResultProtocol> ParticipantsProtocols;
    
    public ResultProtocol(string groupName)
    {
        GroupName = groupName;

        ParticipantsProtocols = new List<ParticipantResultProtocol>();
    }
    
    public void AddParticipantProtocol(ParticipantResultProtocol protocol)
    {
        ParticipantsProtocols.Add(protocol);
    }

    public void Output(string file)
    {
        FileHandler.AppendData(file, new List<string>{GroupName, "", "", "", "", "", "", ""});
        FileHandler.AppendData(file, new List<string>{"Место", "Номер", "Имя", "Фамилия", "Дата рождения", "Команда", "Время", "Отставание"});
        foreach (var item in ParticipantsProtocols)
        {
            FileHandler.AppendLine(file, item.ToString());
        }
    }
}