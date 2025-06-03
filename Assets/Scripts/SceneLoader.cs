using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance {get; private set;}

    public GameObject loadingCanvas;
    [SerializeField]private TMP_Text _progressText;
    [SerializeField]private Image _progressBar;

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

    public void ChangeScene(int sceneIndex)
    {
        StartCoroutine(LoadNewScene(sceneIndex));
    }

    IEnumerator LoadNewScene(int sceneIndex)
    {
        yield return null;

        loadingCanvas.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
        asyncLoad.allowSceneActivation = false;

        float loadPercentage = 0f;

        while (!asyncLoad.isDone)
        {
            //Simulate a loading progress
            loadPercentage += 0.01f;
            _progressBar.fillAmount = Mathf.Clamp01(loadPercentage);
            _progressText.text = "Loading progress: " + (loadPercentage * 100).ToString("F0") + "%";

            if (asyncLoad.progress >= 0.9f && loadPercentage >= 0.99f)
            {
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }       

        loadingCanvas.SetActive(false);
    }
}