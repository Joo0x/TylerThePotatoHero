
using System;
using UnityEngine;

public class LetsGoUp : MonoBehaviour
{
    [SerializeField]
    private float desirePosition;
    public UI_SoundManager _killCheck;
    private bool tylercolided =false;

    private void Awake()
    {
        _killCheck = GameObject.Find("UISoundManager").GetComponent<UI_SoundManager>();
    }

    private void Update()
    {
        
        if (tylercolided)
        {
            Debug.Log("Going UP");
            transform.position = Vector3.MoveTowards(transform.position,Vector3.up, 4f * Time.deltaTime);
            
            if (transform.position.y >= desirePosition)
                tylercolided = false;
        }
        else if(_killCheck.killcount >= 4 && transform.position.y >= -1 && !tylercolided)
        {
            Debug.Log("Going Down");
            transform.position = Vector3.MoveTowards(transform.position, Vector3.down, 4f * Time.deltaTime);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //tylercolided = true;
            collision.transform.position = new Vector3(50, 50, 50);
        }
        
    }
    
    private void OnCollisionExit(Collision collision)
    {
  
        
    }

    
}
