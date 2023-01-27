using System.ComponentModel;

namespace sport_management_system.frontend.library;

public class Page : Form
{
    protected List<Action> InitializeMethods = new();
    
    protected void InitializeForm(string name, string text)
    {
        SuspendLayout();
        
        Name = name;
        Text = text;
        
        AutoScaleMode = AutoScaleMode.Font;
        AutoSize = true;
        StartPosition = FormStartPosition.CenterScreen;
        WindowState = FormWindowState.Maximized;
            
        BackColor = ColorTranslator.FromHtml("#D9D9D9");
        Font = PageHandler.MediumFont;

        foreach (var method in InitializeMethods)
        {
            method();
        }

        Closing += FormClosingAction;
        
        ResumeLayout();        
    }
    
    private static void FormClosingAction(object? sender, CancelEventArgs cancelEventArgs)
    {
        Application.Exit();
    }
}