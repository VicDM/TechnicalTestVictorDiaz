using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField]private Button _audioButton;
    [SerializeField]private Button _lobbyButton;
    [SerializeField]private GameObject _popUpObject;
    private AudioManager _audioManager;

    void OnEnable()
    {
        _audioManager.OnClipFinished += ActivatePopUp;
    }

    void OnDisale()
    {
        _audioManager.OnClipFinished -= ActivatePopUp;
    }

    void Awake()
    {
        _audioManager = FindAnyObjectByType<AudioManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audioButton.onClick.AddListener(StartAudio);
        _lobbyButton.onClick.AddListener(Lobby);
    }

    void Lobby()
    {
        SceneLoader.instance.ChangeScene(1);
    }

    void StartAudio()
    {
        _audioButton.interactable = false;
        _audioManager.PlaySound(_audioManager.soundEffect);
    }

    void ActivatePopUp()
    {
        _popUpObject.SetActive(true);
    }
}
