using UnityEngine;

public class AudioVolumeManager : MonoBehaviour
{
    public static AudioVolumeManager Instance { get; private set; }
    private const string VolumeKey = "audioVolume";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1f);
            SetVolume(savedVolume);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat(VolumeKey, volume);
        PlayerPrefs.Save();
    }
}
