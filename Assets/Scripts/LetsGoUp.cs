
using System;
using UnityEngine;

public class LetsGoUp : MonoBehaviour
{

    [SerializeField] private float  platSpeed;
    private UI_SoundManager _killCheck;
    private Vector3 wayPoint;
    private bool tylercolided =false;

    public static event Action platMoved;
    private void Awake()
    {
        _killCheck = GameObject.Find("UISoundManager").GetComponent<UI_SoundManager>();
        wayPoint = transform.GetChild(0).transform.position;
    }

    private void Update()
    {
        if (tylercolided)
        {
            //Move Platform Up
            transform.position = Vector3.MoveTowards(transform.position, wayPoint , platSpeed * Time.deltaTime);

            if (transform.position ==  wayPoint)
            {
                tylercolided = false;
            }
        }
        else if(_killCheck.killcount >= 4 && transform.position.y >= -1 && !tylercolided)
        {
            platMoved?.Invoke();
            //Move Platform Down
            transform.position = Vector3.MoveTowards(transform.position, Vector3.down, platSpeed * Time.deltaTime);
            platMoved = null;
        }

       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tylercolided = true;
            collision.transform.SetParent(transform);
        }
    }
    
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            collision.transform.SetParent(null);
            //collision.transform.position = new Vector3(50, 50, 50);
        }
    }
}
