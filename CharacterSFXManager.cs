using UnityEngine;
using UnityEngine.Rendering;

public class CharacterSFXManager : MonoBehaviour
{
    [HideInInspector] public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip sfx, float volume = 1, bool randomizePitch = true, float pitchRandom = 0.1f, float pitch = 1f)
    {
        audioSource.PlayOneShot(sfx, volume);
        audioSource.pitch = pitch;
        
        if (randomizePitch)
        {
            audioSource.pitch += Random.Range(-pitchRandom, pitchRandom);
        }
    }

    public void StopAllAISounds()
    {
        AudioSource[] allSources = GetComponentsInChildren<AudioSource>();

        foreach (AudioSource source in allSources)
        {
            source.Stop(); // สั่งให้หยุดเล่นทันที
        }
    }

    public void PlayRollSoundFX()
    {
        
    }
}
