using UnityEngine;
using System.Collections.Generic;

public static class AudioManager
{
    private static AudioSource audioSource;
    private static Dictionary<string, AudioClip> audioClips;

    public static void Initialize(AudioSource source, Dictionary<string, AudioClip> clips)
    {
        audioSource = source;
        audioClips = clips;
    }

    public static void PlaySound(string clipName)
    {
        audioSource.volume = PlayerPrefs.GetFloat("audioVolume", 1f);
        if (audioClips.ContainsKey(clipName))
        {
            audioSource.PlayOneShot(audioClips[clipName]);
        }
        else
        {
            Debug.LogWarning($"AudioManager: Clip '{clipName}' not found!");
        }
    }
}
