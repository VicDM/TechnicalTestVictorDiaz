using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomization : MonoBehaviour
{
    [SerializeField]private GameObject[] _heads;
    [SerializeField]private GameObject[] _weapons;

    private int _headType;
    private int _weaponType;

    [SerializeField]private Button _playButton;
    
    void Start()
    {
        _playButton.onClick.AddListener(StartGame);
        
        LoadCustomization();        
    }

    void LoadCustomization()
    {
        _headType = PlayerData.userData.userHead;
        _weaponType = PlayerData.userData.userWeapon;

        UpdateSelection(_heads, ref _headType, 0);
        UpdateSelection(_weapons, ref _weaponType, 0);
    }

    void UpdateSelection(GameObject[] options,ref int currentIndex, int change)
    {
        //Carousel style customization when the end of the array is reached go back to the first element
        currentIndex = (currentIndex + change + options.Length) % options.Length;

        for (int i = 0; i < options.Length; i++)
        {
            options[i].SetActive(i == currentIndex);
        }
    }

    //These two methods have to be placed in the canvas buttons
    //the int paramater needs to be -1 in the left buttons and 1 in the right buttons
    public void ChangeHead(int change)
    {
        UpdateSelection(_heads, ref _headType, change);
        PlayerData.userData.userHead = _headType;
    }

    public void ChangeWeapong(int change)
    {
        UpdateSelection(_weapons, ref _weaponType, change);
        PlayerData.userData.userWeapon = _weaponType;
    }

    void StartGame()
    {
        SavingDataSystem.Save();
        
        SceneLoader.instance.ChangeScene(2);
    }
}