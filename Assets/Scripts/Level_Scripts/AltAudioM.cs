using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltAudioM : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Clip")]
    public AudioClip bossAttack;
    public AudioClip chargeShot;
    public AudioClip continueScreen;
    public AudioClip jump;
    public AudioClip mainMenu;
    public AudioClip menuClick;
    public AudioClip outro;
    public AudioClip sDeath;
    public AudioClip sProj;
    public AudioClip stage01;
    public AudioClip tut;
    public AudioClip zDeath;
    public AudioClip zProj;

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
