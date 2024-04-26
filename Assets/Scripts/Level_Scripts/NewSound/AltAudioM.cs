using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltAudioM : MonoBehaviour
{
    public static AltAudioM instance;

    [SerializeField] private AudioSource sfxObject;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void PlaySFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spawn gameObject
        AudioSource audioSource = Instantiate(sfxObject, spawnTransform.position, Quaternion.identity);

        //assign audioClip
        audioSource.clip = audioClip;

        //assign volume
        audioSource.volume = volume;

        //play sound
        audioSource.Play();

        //get length of clip
        float clipLength = audioSource.clip.length;

        //destroy self after clip plays
        Destroy(audioSource.gameObject, clipLength);
    }
}
