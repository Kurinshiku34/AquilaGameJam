using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    public GameObject ResumePanel;
    public const string MIXER_MUSIC = "MusicVolume";
    public const string MIXER_SFX = "SFXVolume";

    void Awake() {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }
    void Start() {
        musicSlider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY, 0f);
        sfxSlider.value = PlayerPrefs.GetFloat(AudioManager.SFX_KEY, 0f);
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ResumePanel.SetActive(true); 
            Time.timeScale = 0f;
        }
    }
    void OnDisable() {
        PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY, musicSlider.value);
        PlayerPrefs.SetFloat(AudioManager.SFX_KEY, sfxSlider.value);
    }
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame() {
        Application.Quit();
    }
    void SetMusicVolume(float value) {
        mixer.SetFloat(MIXER_MUSIC, value);
    }
    void SetSFXVolume(float value) {
        mixer.SetFloat(MIXER_SFX, value);
    }
    public void SetQuality(int qualityIndex) { 
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullscren(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }
    public void SceneChange(int scenenumber) {
        SceneManager.LoadScene(scenenumber);
    }
    public void TimeScale(float scale) {
        Time.timeScale = scale;
    }
}
