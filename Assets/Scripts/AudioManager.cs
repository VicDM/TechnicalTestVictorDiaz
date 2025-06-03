using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    private AudioSource _source;
    [SerializeField] private Image _progressBar;

    private Coroutine _progressCoroutine;


    void OnEnable()
    {
        EventManager.OnAudioRequested += PlaySound;
    }

    void OnDisable()
    {
        EventManager.OnAudioRequested -= PlaySound;
    }

    void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        if (_source == null || clip == null)
        {
            return;
        }

        if (_progressCoroutine != null)
        {
            _source.Stop();
            StopCoroutine(_progressCoroutine);
        }

        _source.PlayOneShot(clip);

        if (_progressBar != null)
        {
            _progressCoroutine = StartCoroutine(UpdateProgressBar(clip.length));
        }
    }

    IEnumerator UpdateProgressBar(float clipLength)
    {
        float timer = 0f;

        while (timer < clipLength)
        {
            timer += Time.deltaTime;

            _progressBar.fillAmount = Mathf.Clamp01(timer / clipLength);

            yield return null;
        }

        _progressBar.fillAmount = 0f;
            
        EventManager.AudioClipFinished();
    }
}