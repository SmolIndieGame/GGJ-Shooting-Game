using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int hp;
    public float immutableTime;
    public bool immutable;
    public Sprite emptyHeart;
    public Sprite heart;

    public GameObject hpbar;

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.gameObject.tag == "Enemy" & !immutable)
        {
            Damage();
            RemoveEnemy(col.gameObject);
            StartCoroutine(PlayerImmutable());
        }
    }

    void Damage()
    {
        this.hp --;
        UpdateHPGUI();
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
    }

    void RemoveEnemy(GameObject enemy)
    {
        Destroy(enemy);
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
