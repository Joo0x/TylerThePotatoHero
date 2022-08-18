using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.AI;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletLifeSpan;

    public static event Action hit;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = transform.forward * bulletSpeed;
        Invoke("Delete",bulletLifeSpan);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Enemy"))
        {
            hit?.Invoke();
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }

    private void Delete()
    {
        Destroy(gameObject);
    }
    


}
