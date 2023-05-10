using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public AudioSource bossMusic;
    public AudioSource bossIntro;
    public AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayBossMusic()
    {
        bossMusic.Play();
    }
    public void PlayBgm()
    {
        bgm.UnPause();
    }
    public void PlayIntro()
    {
        bossIntro.Play();
    }

}
