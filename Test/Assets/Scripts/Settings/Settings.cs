public class Settings 
{
    public static Settings instance;
    private Settings() { }
    static public Settings GetInstance()
    {
        if (instance == null)
        {
            instance = new Settings();
        }
        return instance;
    }

    public string itemsInfoFilePath { get; private set; } = "Assets/Scripts/DataSaves/ItemsInfo.json";


}
