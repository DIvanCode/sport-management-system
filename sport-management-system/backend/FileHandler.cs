namespace sport_management_system;

public static class FileHandler
{
    private static string lastFilePath = "";

    public static string SelectPath()
    {
        var folderBrowserDialog = new FolderBrowserDialog();
        folderBrowserDialog.ShowDialog();
        return folderBrowserDialog.SelectedPath;
    }
    
    public static string SelectFile()
    {
        var openFileDialog = new OpenFileDialog();
        openFileDialog.ShowDialog();
        return openFileDialog.FileName;
    }

    public static List<string> GetDirFilesNames(string dirPath)
    {
        return Directory.GetFiles(dirPath).ToList();
    }

    public static void RunException()
    {
        throw new Exception("Wrong data in " + lastFilePath);
    }

    private static List<string> ParseLine(string line)
    {
        var stringIsOpened = 0;
        var data = new List<string>();
        var currentData = "";
        
        foreach (var x in line)
        {
            if (x == '"')
            {
                stringIsOpened ^= 1; 
                continue;
            }

            if (x == ',' && stringIsOpened == 0)
            {
                data.Add(currentData);
                currentData = "";
                continue;
            }

            currentData += x;
        }
        
        data.Add(currentData);
        
        return data;
    }

    public static List<List<string>> ReadAllLines(string filePath)
    {
        lastFilePath = filePath;
        
        var lines = File.ReadAllLines(filePath).ToList();
        
        return lines.Select(ParseLine).ToList();    
    }
    
    public static string CreateLine(List<string> data)
    {
        var line = "";
        var isFirst = true;

        foreach (var x in data)
        {
            if (!isFirst)
            {
                line += ",";
            }

            if (x.Contains(',')) line += "\"";
            line += x;
            if (x.Contains(',')) line += "\"";

            isFirst = false;
        }

        return line;
    }

    public static void Append(string filePath, string data, bool isFirstColumn = false)
    {
        if (!isFirstColumn)
        {
            data = "," + data;
        }
        
        File.AppendAllText(filePath, data);
    }
    
    public static void AppendLine(string filePath, string line)
    {
        File.AppendAllLines(filePath, new []{line});
    }

    public static void AppendData(string filePath, List<string> data)
    {
        AppendLine(filePath, CreateLine(data));
    }

    public static void ClearFile(string filePath)
    {   
        File.WriteAllText(filePath, "");
    }

    public static string CreateTimeString(int t)
    {
        var s = "";

        // hours
        if (t / 3600 < 10) s += "0";
        s += Convert.ToString(t / 3600);
        
        s += ":";
        
        //minutes
        if (t % 3600 / 60 < 10) s += "0";
        s += Convert.ToString(t % 3600 / 60);
        
        s += ":";
        
        // seconds
        if (t % 60 < 10) s += "0";
        s += Convert.ToString(t % 60);
        
        return s;
    }
}