using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CharacterAudioController : MonoBehaviour
{
    public AudioClip jumpClip;
    public AudioClip attackClip;
    public AudioClip deathClip;
    public AudioClip dashClip;
    public AudioClip GrappleClip;
   

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpClip);
    }
    public void PlayDashSound()
    {
        audioSource.PlayOneShot(dashClip);
    }
    public void PlayGrappleSound()
    {
        audioSource.PlayOneShot(GrappleClip);
    }
    public void PlayAttackSound()
    {
        audioSource.PlayOneShot(attackClip);
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathClip);
    }
}