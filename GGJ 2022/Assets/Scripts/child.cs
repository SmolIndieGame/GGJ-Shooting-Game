using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class child : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]float movespeed=3;
    [SerializeField] GameObject Hpbar;
    [SerializeField]int Hp=3;

    Watch invincibleTimer;
    Watch flashingTimer;
    void Start()
    {
        invincibleTimer = new Watch(3, true);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
            transform.Translate(-movespeed*Time.deltaTime,0,0);
        }
        else if(Input.GetKey(KeyCode.D)){
            transform.Translate(movespeed*Time.deltaTime,0,0);
        }  
        else if(Input.GetKey(KeyCode.W)){
            transform.Translate(0,movespeed*Time.deltaTime,0);
        } 
        else if(Input.GetKey(KeyCode.S)){
            transform.Translate(0,-movespeed*Time.deltaTime,0);
        }   

if (invincibleTimer.TimeOut)
{
    GetComponent<BoxCollider2D>().enabled=true;
}
    }
     void OnCollisionEnter2D(Collision2D other){
            if (other.gameObject.tag=="Enemy"){ 
                ModifyHP(-1);
                GetComponent<BoxCollider2D>().enabled=false;
                invincibleTimer.Reset();
            }
        }
        
    void ModifyHP(int num){
        Hp+=num;
        if (Hp>3){
            Hp=3;
        }
        else if (Hp<=0){
            Hp=0;
        }
        UpdateHp();
    }
    void UpdateHp()
    {        
        for(int i=0;i<Hpbar.transform.childCount;i++)
        {   
            if(Hp>i)
            {   
                Hpbar.transform.GetChild(i).gameObject.SetActive(true);            
            }            
            else
            {
                Hpbar.transform.GetChild(i).gameObject.SetActive(false);        
            }        
        }            
    }
    

}
