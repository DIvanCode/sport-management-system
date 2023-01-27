namespace sport_management_system.frontend.library;

public sealed class ReturnButton : Button
{
    public ReturnButton(string buttonName, string buttonText)
    {
        Name = buttonName + "ReturnButton";

        Location = new Point(PageHandler.GetDIP(1580), PageHandler.GetDIP(40));
        
        Size = new Size(PageHandler.GetDIP(300), PageHandler.GetDIP(PageHandler.SmallHeight));
        TabIndex = 0;

        AutoSize = false;
        TextAlign = ContentAlignment.MiddleCenter;
        Dock = DockStyle.None;
        
        Font = PageHandler.SmallFont;

        Text = buttonText;
        BackColor = ColorTranslator.FromHtml("#ECE8E8");
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;

        Click += ReturnButton_Click;
    }
    
    private void ReturnButton_Click(object? sender, EventArgs e)
    {
        PageHandler.PagesHistory.Peek().Hide();
        PageHandler.PagesHistory.Pop();
        PageHandler.PagesHistory.Peek().Show();
    }
}