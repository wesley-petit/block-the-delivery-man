using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingProgress : MonoBehaviour
{
    // Cet élément est le parent du panel de loading

    private int indexScene;
    [SerializeField] private TextMeshProUGUI text_loading;
    [SerializeField] private Slider sliderBar;
    [SerializeField] private GameObject UIPanel_Loading;
    private bool loadScene;

    void Start()
    {
        Helpers.loadingProgress = this;
        DontDestroyOnLoad(this.gameObject);
        sliderBar.gameObject.SetActive(false);

    }

    // Update is called once per frame
    public void LoadScene(int index)
    {
        if (loadScene == false)
        {
            indexScene = index;
            loadScene = true;
            Show();
            StartCoroutine(LoadAsyncScene());

        }
        

    }
    private IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(indexScene);
        if (indexScene > 1)
        {
            SceneManager.LoadScene(0,LoadSceneMode.Additive);
        }
        
        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            sliderBar.value = progress;
            text_loading.SetText(progress * 100f + " %");
            yield return null;
        }

        loadScene = false;
        Hide();
        StopCoroutine(LoadAsyncScene());
    }

    private void Hide()
    {
        UIPanel_Loading.SetActive(false);
    }
    private void Show()
    {
        UIPanel_Loading.SetActive(true);
    }
}
