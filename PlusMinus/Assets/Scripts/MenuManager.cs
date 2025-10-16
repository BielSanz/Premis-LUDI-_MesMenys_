using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject settingsPanel;
    public GameObject creditsPanel;


    public Button playButton;
    public Button settingsButton;
    public Button creditsButton;
    public Button exitButton;

    void Start()
    {
    
        if (settingsPanel) settingsPanel.SetActive(false);
        if (creditsPanel) creditsPanel.SetActive(false);

#if UNITY_ANDROID
        // nada extra; se manejará en Update
#endif
    }

    public void OnPlayPressed()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnSettingsPressed()
    {
        if (settingsPanel) settingsPanel.SetActive(true);
    }

    public void OnCloseSettings()
    {
        if (settingsPanel) settingsPanel.SetActive(false);
    }

    public void OnCreditsPressed()
    {
        if (creditsPanel) creditsPanel.SetActive(true);
    }

    public void OnCloseCredits()
    {
        if (creditsPanel) creditsPanel.SetActive(false);
    }

    public void OnExitPressed()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsPanel != null && settingsPanel.activeSelf) { settingsPanel.SetActive(false); }
            else if (creditsPanel != null && creditsPanel.activeSelf) { creditsPanel.SetActive(false); }
            else { OnExitPressed(); }
        }
    }
}
