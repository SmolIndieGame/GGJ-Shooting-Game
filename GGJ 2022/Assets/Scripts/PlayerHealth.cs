using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int hp;
    public float immutableTime;
    public bool immutable;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.name);
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
