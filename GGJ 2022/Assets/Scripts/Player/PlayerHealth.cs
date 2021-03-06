using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameOverUIHandle gameOver;
    public int hp;
    public float immutableTime;
    public bool immutable;
    public Sprite emptyHeart;
    public Sprite heart;
    public AudioClip gotHit;
    public CameraMovement camMove;

    public GameObject hpbar;

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D col)
    {
        if(!immutable && col.attachedRigidbody != null && col.attachedRigidbody.CompareTag("Enemy"))
        {
            Damage();
            RemoveEnemy(col.attachedRigidbody.GetComponent<Enemy>());
            StartCoroutine(PlayerImmutable());
        }
    }

    void Damage()
    {
        this.hp --;
        UpdateHPGUI();
        ParticlePool.I.SpawnParticle(ParticleType.Damage, transform.position, Vector3.zero, 5);
        camMove.Shake(1f, 0.6f);
        Sounds.I.Play(gotHit);
    }

    void UpdateHPGUI()
    {        
        for(int i=0; i<hpbar.transform.childCount;i++)
        {   
            if(this.hp > i)
            {   
                hpbar.transform.GetChild(i).GetComponent<Image>().sprite = heart;            
            }            
            else
            {
                hpbar.transform.GetChild(i).GetComponent<Image>().sprite = emptyHeart;
            }        
        }

        if (hp <= 0)
            gameOver.GameOver();
    }

    void RemoveEnemy(Enemy enemy)
    {
        enemy.Return();
    }

    IEnumerator PlayerImmutable()
    {
        //yield return true;
        immutable = true;
        yield return new WaitForSeconds(immutableTime);
        immutable = false;
        yield return null;
    }
}
