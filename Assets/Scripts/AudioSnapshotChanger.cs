using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSnapshotChanger : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixerSnapshot snapshotToChangeTo;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Replace "Player" with the tag of the object you want to trigger the change
        {
            audioMixer.TransitionToSnapshots(new AudioMixerSnapshot[] { snapshotToChangeTo }, new float[] { 1.0f }, 0.5f); // Replace 0.5f with the time you want to take to transition to the new snapshot
        }
    }
}