namespace sport_management_system.frontend.library;

public class DataLoadObject
{
    private string ObjectName;
    private string ObjectTextName;
    private Point ObjectLocation;
    private bool Loaded;

    public Label HeaderLabel;
    public List<Button> Buttons;

    public DataLoadObject(string objectName, string objectTextName, Point objectLocation)
    {
        ObjectName = objectName;
        ObjectTextName = objectTextName;
        ObjectLocation = objectLocation;
        Loaded = false;

        HeaderLabel = new Label();
        Buttons = new List<Button>();
    }

    public Label InitializeHeaderLabel()
    {
        var label = new Label();
        
        label.Name = ObjectName + "HeaderLabel";

        label.Location = ObjectLocation;
        label.Size = new Size(PageHandler.GetDIP(750), PageHandler.GetDIP(PageHandler.SmallHeight));
        label.TabIndex = 0;

        label.AutoSize = false;
        label.TextAlign = ContentAlignment.MiddleLeft;
        label.Dock = DockStyle.None;

        label.Font = PageHandler.SmallFont;

        label.Text = ObjectTextName + " отсутствуют";

        return HeaderLabel = label;
    }

    public Button InitializeLoadButton(EventHandler clickAction)
    {
        var button = new Button();
        
        button.Name = ObjectName + "LoadButton";

        if (Buttons.Count == 0)
        {
            button.Location = new Point(HeaderLabel.Location.X + HeaderLabel.Size.Width, HeaderLabel.Location.Y);
        }
        else
        {
            button.Location = new Point(Buttons.Last().Location.X + Buttons.Last().Size.Width + 40, Buttons.Last().Location.Y);
        }
        
        button.Size = new Size(PageHandler.GetDIP(400), PageHandler.GetDIP(PageHandler.SmallHeight));
        button.TabIndex = 0;

        button.AutoSize = false;
        button.TextAlign = ContentAlignment.MiddleCenter;
        button.Dock = DockStyle.None;
        
        button.Font = PageHandler.SmallFont;

        button.Text = "Загрузить";
        button.BackColor = ColorTranslator.FromHtml("#ECE8E8");
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;

        button.Click += clickAction;
        
        Buttons.Add(button);

        return button;
    }
    
    public Button InitializeFormButton(EventHandler clickAction)
    {
        var button = new Button();
        
        button.Name = ObjectName + "FormButton";

        if (Buttons.Count == 0)
        {
            button.Location = new Point(HeaderLabel.Location.X + HeaderLabel.Size.Width, HeaderLabel.Location.Y);
        }
        else
        {
            button.Location = new Point(Buttons.Last().Location.X + Buttons.Last().Size.Width + 40, Buttons.Last().Location.Y);
        }
        
        button.Size = new Size(PageHandler.GetDIP(400), PageHandler.GetDIP(PageHandler.SmallHeight));
        button.TabIndex = 0;

        button.AutoSize = false;
        button.TextAlign = ContentAlignment.MiddleCenter;
        button.Dock = DockStyle.None;
        
        button.Font = PageHandler.SmallFont;

        button.Text = "Сформировать";
        button.BackColor = ColorTranslator.FromHtml("#ECE8E8");
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;

        button.Click += clickAction;
        
        Buttons.Add(button);

        return button;
    }
    
    public Button InitializeShowButton(EventHandler clickAction)
    {
        var button = new Button();
        
        button.Name = ObjectName + "ShowButton";

        if (Buttons.Count == 0)
        {
            button.Location = new Point(HeaderLabel.Location.X + HeaderLabel.Size.Width, HeaderLabel.Location.Y);
        }
        else
        {
            button.Location = new Point(Buttons.Last().Location.X + Buttons.Last().Size.Width + 40, Buttons.Last().Location.Y);
        }
        
        button.Size = new Size(PageHandler.GetDIP(400), PageHandler.GetDIP(PageHandler.SmallHeight));
        button.TabIndex = 0;

        button.AutoSize = false;
        button.TextAlign = ContentAlignment.MiddleCenter;
        button.Dock = DockStyle.None;
        
        button.Font = PageHandler.SmallFont;

        button.Text = "Показать";
        button.BackColor = ColorTranslator.FromHtml("#ECE8E8");
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;

        button.Click += clickAction;
        
        Buttons.Add(button);

        return button;
    }
    
    public Button InitializeOutputButton(EventHandler clickAction)
    {
        var button = new Button();
        
        button.Name = ObjectName + "OutputButton";

        if (Buttons.Count == 0)
        {
            button.Location = new Point(HeaderLabel.Location.X + HeaderLabel.Size.Width, HeaderLabel.Location.Y);
        }
        else
        {
            button.Location = new Point(Buttons.Last().Location.X + Buttons.Last().Size.Width + 40, Buttons.Last().Location.Y);
        }
        
        button.Size = new Size(PageHandler.GetDIP(400), PageHandler.GetDIP(PageHandler.SmallHeight));
        button.TabIndex = 0;

        button.AutoSize = false;
        button.TextAlign = ContentAlignment.MiddleCenter;
        button.Dock = DockStyle.None;
        
        button.Font = PageHandler.SmallFont;

        button.Text = "Сохранить в папку";
        button.BackColor = ColorTranslator.FromHtml("#ECE8E8");
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;

        button.Click += clickAction;
        
        Buttons.Add(button);

        return button;
    }

    public void Load()
    {
        while (Buttons.Count != 0)
        {
            Buttons.Last().Hide();
            Buttons.Remove(Buttons.Last());
        }

        HeaderLabel.Text = ObjectTextName + " загружены";
    }
    
    public void Output()
    {
        while (Buttons.Count != 0)
        {
            Buttons.Last().Hide();
            Buttons.Remove(Buttons.Last());
        }

        HeaderLabel.Text = ObjectTextName + " сохранены";
    }
}