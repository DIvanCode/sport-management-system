using sport_management_system.frontend.library;

namespace sport_management_system.frontend;

public class EventLoadPage : Page
{
    public EventLoadPage()
    {
        InitializeMethods.Add(InitializeEventIsNotLoadedLabel);
        InitializeMethods.Add(InitializeEventLoadButton);
        
        InitializeMethods.Add(InitializeExitButton);
        
        InitializeForm("EventLoadPage", "Загрузка события");
    }
    
        private void InitializeEventIsNotLoadedLabel()
    {
        var label = new Label();
        
        label.Name = "EventIsNotLoadedLabel";

        label.Location = new Point(PageHandler.GetDIP(460), PageHandler.GetDIP(280));
        label.Size = new Size(PageHandler.GetDIP(1000), PageHandler.GetDIP(150));
        label.TabIndex = 0;

        label.AutoSize = false;
        label.TextAlign = ContentAlignment.MiddleCenter;
        label.Dock = DockStyle.None;
        
        label.Font = PageHandler.MediumFont;

        label.Text = "Событие не загружено";
        
        Controls.Add(label);
    }
    
    private void InitializeEventLoadButton()
    {
        var button = new Button();
        
        button.Name = "EventLoadButton";

        button.Location = new Point(PageHandler.GetDIP(710), PageHandler.GetDIP(430));
        button.Size = new Size(PageHandler.GetDIP(500), PageHandler.GetDIP(100));
        button.TabIndex = 0;

        button.AutoSize = false;
        button.TextAlign = ContentAlignment.MiddleCenter;
        button.Dock = DockStyle.None;
        
        button.Font = PageHandler.MediumFont;

        button.Text = "Выбрать";
        button.BackColor = ColorTranslator.FromHtml("#ECE8E8");
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;

        button.Click += EventLoadButton_Click;
        
        Controls.Add(button);
    }
    
    private void InitializeExitButton()
    {
        var button = new Button();
        
        button.Name = "ExitButton";

        button.Location = new Point(PageHandler.GetDIP(710), PageHandler.GetDIP(580));
        button.Size = new Size(PageHandler.GetDIP(500), PageHandler.GetDIP(100));
        button.TabIndex = 0;

        button.AutoSize = false;
        button.TextAlign = ContentAlignment.MiddleCenter;
        button.Dock = DockStyle.None;
        
        button.Font = PageHandler.MediumFont;

        button.Text = "Выйти";
        button.BackColor = ColorTranslator.FromHtml("#ECE8E8");
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;

        button.Click += ExitButton_Click;
        
        Controls.Add(button);
    }

    private void EventLoadButton_Click(object? sender, EventArgs e)
    {
        Event.Load(FileHandler.SelectFile());
        
        Hide();
        PageHandler.PagesHistory.Push(new EventPage());
        PageHandler.PagesHistory.Peek().Show();
    }
    
    private void ExitButton_Click(object? sender, EventArgs e)
    {
        Application.Exit();
    }
}