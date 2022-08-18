using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyChasser : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public static event Action damage;
    

    [SerializeField] private float distNum = 15f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        if (player != null) 
            enemy.SetDestination(player.position);
            
    }


    private void OnCollisionEnter(Collision collision)
    {
        var tyler = collision.gameObject.GetComponent<TylerControl>();
        if (collision.gameObject.CompareTag("Player"))
        {
            tyler.GetComponent<Rigidbody>().AddForce(Vector3.forward,ForceMode.Force);
            tyler.damage(2);
        }
        
    }
}