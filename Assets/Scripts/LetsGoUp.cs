using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetsGoUp : MonoBehaviour
{
    public Vector3 desirePosition , temp;


    private static UI_SoundManager getkillCount;

    private void Start()
    {
        desirePosition = transform.position;
        //getkillCount = new UI_SoundManager();//works
        getkillCount = GetComponent<UI_SoundManager>(); //dosenotwork
    }

    private void Update()
    {

            
    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 current = transform.position;
        if (collision.gameObject.CompareTag("Player"))
            transform.position = Vector3.MoveTowards(current,new Vector3(current.x , current.y + 3f , current.z),3f * Time.deltaTime);
        
    }

    
}
