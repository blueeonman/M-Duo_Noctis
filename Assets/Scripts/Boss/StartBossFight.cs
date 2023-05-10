using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBossFight : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource bossIntro;
    public Boss boss;
    BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isPlayer = collision.gameObject.CompareTag("Player");
        if (isPlayer)
        {
            bossIntro.Play();
            StartCoroutine(BossPrep());
            /*boss.gameObject.SetActive(true);
            bgm.Pause();
            boss.PlayBossMusic();
            Destroy(this.gameObject);*/
        }
    }

    public IEnumerator BossPrep()
    {
        //bgm.Pause();
        yield return new WaitForSeconds(5);
        boss.gameObject.SetActive(true);
        boss.PlayBossMusic();
        Destroy(this.gameObject);
    }
}
