using System;
using UnityEngine;

public static class EventManager
{
    // Audio
    public static event Action OnAudioClipFinished;
    public static void AudioClipFinished() => OnAudioClipFinished?.Invoke();
    public static event Action<AudioClip> OnAudioRequested;
    public static void RequestAudio(AudioClip clip) => OnAudioRequested?.Invoke(clip);

    // Scene
    public static event Action<int> OnSceneRequested;
    public static void RequestScene(int sceneIndex) => OnSceneRequested?.Invoke(sceneIndex);

    // Save/Load
    public static event Action OnUserDataLoaded;
    public static void UserDataLoaded() => OnUserDataLoaded?.Invoke();

    public static event Action OnUserDataSaved;
    public static void UserDataSaved() => OnUserDataSaved?.Invoke();

    public static event Action OnSaveRequested;
    public static void RequestSave() => OnSaveRequested?.Invoke();

    public static event Action OnLoadRequested;
    public static void RequestLoad() => OnLoadRequested?.Invoke();
}