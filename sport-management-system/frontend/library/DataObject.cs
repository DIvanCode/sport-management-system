namespace sport_management_system.frontend.library;

public class DataObject
{
    private string ObjectName;
    private Point ObjectLocation;
    
    public Label Header = new();
    public Label Data = new();

    public DataObject(string objectName, Point objectLocation, string headerText, string dataText)
    {
        ObjectName = objectName;
        ObjectLocation = objectLocation;

        Header.Text = headerText;
        Data.Text = dataText;
    }

    public Label InitializeHeader()
    {
        Header.Name = ObjectName + "HeaderLabel";

        Header.Location = ObjectLocation;
        Header.Size = new Size(PageHandler.GetDIP(250), PageHandler.GetDIP(PageHandler.MediumHeight));
        Header.TabIndex = 0;

        Header.AutoSize = false;
        Header.TextAlign = ContentAlignment.MiddleRight;
        Header.Dock = DockStyle.None;

        Header.Font = PageHandler.SmallFont;

        return Header;
    }
    
    public Label InitializeData()
    {
        Data.Name = ObjectName + "DataLabel";

        Data.Location = new Point(Header.Location.X + Header.Size.Width, Header.Location.Y);
        Data.Size = new Size(PageHandler.GetDIP(1000), PageHandler.GetDIP(PageHandler.MediumHeight));
        Data.TabIndex = 0;

        Data.AutoSize = false;
        Data.TextAlign = ContentAlignment.MiddleLeft;
        Data.Dock = DockStyle.None;

        Data.Font = PageHandler.MediumFont;

        return Data;
    }
}