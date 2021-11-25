using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class LoadingSceneManagement : MonoBehaviour
{
    public GameObject loadingScreen;
    public Image progressBar;
    public Text progressText;
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressBar.fillAmount = progress;
            progressText.text = progress * 100 + "%";
          
        }
        yield return null;
    }
    public void LoadLevelAsync(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
}
