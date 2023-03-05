using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioSource buttonSound;
    [SerializeField] AudioClip clip;
    public const string MUSIC_KEY = "musicVolume";
    public const string SFX_KEY = "sfxVolume";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void LoadVolume() // Volume saved in UIManager.cs
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 0f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 0f);
        mixer.SetFloat(UIManager.MIXER_MUSIC, musicVolume);
        mixer.SetFloat(UIManager.MIXER_SFX, sfxVolume);
    }
}
