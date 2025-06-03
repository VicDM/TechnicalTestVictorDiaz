using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField]private Button _audioButton;
    [SerializeField]private Button _lobbyButton;
    [SerializeField]private GameObject _popUpObject;

    [SerializeField]private AudioClip _soundEffect;

    void OnEnable()
    {
        EventManager.OnAudioClipFinished += ActivatePopUp;
    }

    void OnDisable()
    {
        EventManager.OnAudioClipFinished -= ActivatePopUp;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audioButton.onClick.AddListener(StartAudio);
        _lobbyButton.onClick.AddListener(Lobby);
    }

    void Lobby()
    {
        EventManager.RequestScene(1);
        //SceneLoader.instance.ChangeScene(1);
    }

    void StartAudio()
    {
        _audioButton.interactable = false;
        EventManager.RequestAudio(_soundEffect);
    }

    void ActivatePopUp()
    {
        _popUpObject.SetActive(true);
    }
}