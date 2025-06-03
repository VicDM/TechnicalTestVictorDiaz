using System.IO;
using UnityEngine;

public static class SavingDataSystem
{
    private static string savePath = Application.persistentDataPath + "/playerData.json";

    public static void Save()
    {
        string json = JsonUtility.ToJson(PlayerData.userData, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Guardado en: " + savePath);
        EventManager.UserDataSaved();
    }

    public static void Load()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            PlayerData.userData = JsonUtility.FromJson<UserData>(json);
            Debug.Log("Cargado desde: " + savePath);
            EventManager.UserDataLoaded();
        }
        else
        {
            Debug.Log("No hay datos guardados.");
        }
    }
}