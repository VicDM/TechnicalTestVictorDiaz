[System.Serializable]
public class UserData
{
    public string userEmail;
    public string userPassword;
    public int userHead;
    public int userWeapon;
}

public static class PlayerData
{
    public static UserData userData = new UserData();
}