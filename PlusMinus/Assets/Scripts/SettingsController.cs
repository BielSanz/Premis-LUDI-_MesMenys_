using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public AudioSource sampleAudioSource;

    private const string PREF_MUSIC = "MusicVolume";
    private const string PREF_SFX = "SFXVolume";

    void Start()
    {

        float music = PlayerPrefs.GetFloat(PREF_MUSIC, 1f);
        float sfx = PlayerPrefs.GetFloat(PREF_SFX, 1f);

        if (musicSlider != null) musicSlider.value = music;
        if (sfxSlider != null) sfxSlider.value = sfx;


        if (musicSlider != null) musicSlider.onValueChanged.AddListener(OnMusicChanged);
        if (sfxSlider != null) sfxSlider.onValueChanged.AddListener(OnSfxChanged);
    }

    public void OnMusicChanged(float value)
    {
        PlayerPrefs.SetFloat(PREF_MUSIC, value);
        PlayerPrefs.Save();

        Debug.Log("Music volume set to " + value);
    }

    public void OnSfxChanged(float value)
    {
        PlayerPrefs.SetFloat(PREF_SFX, value);
        PlayerPrefs.Save();
        Debug.Log("SFX volume set to " + value);


        if (sampleAudioSource != null)
        {
            sampleAudioSource.volume = value;
            sampleAudioSource.Play();
        }
    }

    private void OnDestroy()
    {
        if (musicSlider != null) musicSlider.onValueChanged.RemoveListener(OnMusicChanged);
        if (sfxSlider != null) sfxSlider.onValueChanged.RemoveListener(OnSfxChanged);
    }
}
