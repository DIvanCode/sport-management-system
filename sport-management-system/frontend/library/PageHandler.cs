namespace sport_management_system.frontend.library;

public static class PageHandler
{
    public static Font SmallFont = new("Regular", 15);
    public static Font MediumFont = new("Regular", 20);
    public static Font LargeFont = new("Regular", 25);

    public static int SmallHeight = 40;
    public static int MediumHeight = 60;
    public static int LargeHeight = 80;

    public static int DeviceDpi;

    public static Stack<Page> PagesHistory = new();
    
    public static int GetDIP(int px)
    {
        var dpi = DeviceDpi;
        return 72 * px / dpi;
    }


}