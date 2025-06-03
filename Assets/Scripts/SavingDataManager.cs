using UnityEngine;

public class SavingDataManager : MonoBehaviour
{
    public static SavingDataManager instance { get; private set; }

    void OnEnable()
    {
        EventManager.OnSaveRequested += SaveData;
        EventManager.OnLoadRequested += LoadData;
    }

    void OnDisable()
    {
        EventManager.OnSaveRequested -= SaveData;
        EventManager.OnLoadRequested -= LoadData;
    }

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void SaveData()
    {
        SavingDataSystem.Save();
    }

    void LoadData()
    {
        SavingDataSystem.Load();
    }
}