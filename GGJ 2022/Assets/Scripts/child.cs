using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class child : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]float movespeed=3;
    [SerializeField]int Hp=5;
    void Start()
    {
        
    }

    // Update is called once per frame
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

    }
     void OnCollisionEnter2D(Collision2D other){
            if (other.gameObject.tag=="Enemy"){
                ModifyHP(-1);
            }
        }
    void ModifyHP(int num){
        Hp+=num;
        if (Hp>5){
            Hp=5;
        }
        else if (Hp<=0){
            Hp=0;
        }
        Debug.Log(Hp);
    }
}