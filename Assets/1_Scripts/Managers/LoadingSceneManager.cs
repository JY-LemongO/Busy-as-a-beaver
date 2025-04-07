using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneManager : MonoBehaviour
{
    [SerializeField] Slider progressBar;
    [SerializeField] TextMeshProUGUI progressText;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync("TitleScene");
        op.allowSceneActivation = false;

        //yield return StartCoroutine(LoadResources(op));  
        yield return StartCoroutine(SetupData(op));      
        //yield return StartCoroutine(CheckPlayerInfo(op));
        //yield return StartCoroutine(AdditionalSetup(op));

        while (!op.isDone)
        {
            yield return null;
            if (progressBar.value >= 1f)
            {
                op.allowSceneActivation = true;
                yield break;
            }
        }
    }

    IEnumerator LoadResources(AsyncOperation op)
    {
        progressText.text = "Loading Resources...";

        var resourceLoad = Resources.LoadAsync("Resources/Prefabs/Pools");
        while (!resourceLoad.isDone)
        {
            progressBar.value = Mathf.Lerp(progressBar.value, resourceLoad.progress, 0.1f);
            yield return null;
        }

        progressText.text = "Resources Loaded";
    }

    IEnumerator SetupData(AsyncOperation op)
    {
        progressText.text = "Setting up Data...";

        float progress = 0f;
        while (progress < 1f)
        {
            progress += 0.1f * Time.deltaTime;
            progressBar.value = Mathf.Lerp(progressBar.value, progress, 0.1f);
            yield return null;
        }

        progressText.text = "Data Setup Complete";
    }

    IEnumerator CheckPlayerInfo(AsyncOperation op)
    {
        progressText.text = "Checking Player Info...";

        float progress = 0f;
        while (progress < 1f)
        {
            progress += 0.1f * Time.deltaTime;
            progressBar.value = Mathf.Lerp(progressBar.value, progress, 0.1f);
            yield return null;
        }

        progressText.text = "Player Info Checked";
    }

    IEnumerator AdditionalSetup(AsyncOperation op)
    {
        progressText.text = "Performing Additional Setup...";

        float progress = 0f;
        while (progress < 1f)
        {
            progress += 0.1f * Time.deltaTime;
            progressBar.value = Mathf.Lerp(progressBar.value, progress, 0.1f);
            yield return null;
        }

        progressText.text = "Additional Setup Complete";
    }
}
