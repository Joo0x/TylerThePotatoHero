using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public delegate void OnDisableCallback(Bullet Instance);
    public OnDisableCallback Disable ;
    private float lifeSpanMax = 2f,lifespan;

    public static event Action hit;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>() ;
    }

    private void Update()
    { 
        lifespan += Time.deltaTime;
        if (lifespan > lifeSpanMax)
        {
            Debug.Log("this is shooting");
            Disable?.Invoke(this);
            lifespan = 0;
        }
    }

    public void Shoot(Vector3 Position, Vector3 Direction, float speed)
    {
        _rigidbody.velocity = Vector3.zero;
        transform.position = Position;
        transform.forward = Direction;
        
        _rigidbody.AddForce(Direction*speed,ForceMode.VelocityChange);
    }
    
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            Debug.Log("this is triggering");
            Disable?.Invoke(this);
            hit?.Invoke();
            _rigidbody.velocity = Vector3.zero;
            Destroy(other.gameObject);
        }
    }
}
