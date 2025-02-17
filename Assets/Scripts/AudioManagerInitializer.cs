using UnityEngine;
using System.Collections.Generic;

public class AudioManagerInitializer : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> audioClipList;

    private void Awake()
    {
        Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();
        foreach (AudioClip clip in audioClipList)
        {
            audioClips[clip.name] = clip;
        }

        AudioManager.Initialize(audioSource, audioClips);
    }
}
