using sport_management_system.frontend;
using sport_management_system.frontend.library;

namespace sport_management_system;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        PageHandler.DeviceDpi = new Page().DeviceDpi;

        PageHandler.PagesHistory.Push(new EventLoadPage());
        Application.Run(PageHandler.PagesHistory.Peek());
    }
}