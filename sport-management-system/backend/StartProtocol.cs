namespace sport_management_system;

public class StartProtocol
{
    public string GroupName;
    public List<ParticipantStartProtocol> ParticipantsProtocols;

    public StartProtocol(string groupName)
    {
        GroupName = groupName;

        ParticipantsProtocols = new List<ParticipantStartProtocol>();
    }

    public void AddParticipantProtocol(ParticipantStartProtocol protocol)
    {
        ParticipantsProtocols.Add(protocol);
    }

    public void Output(string file)
    {
        FileHandler.AppendData(file, new List<string>{GroupName, "", "", "", "", ""});
        FileHandler.AppendData(file, new List<string>{"Номер", "Имя", "Фамилия", "Дата рождения", "Команда", "Время старта"});
        foreach (var item in ParticipantsProtocols)
        {
            FileHandler.AppendLine(file, item.ToString());
        }
    }
}