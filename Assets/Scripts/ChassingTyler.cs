using System;
using UnityEngine;
using UnityEngine.AI;

public class ChassingTyler : MonoBehaviour
{
    [SerializeField] private NavMeshAgent chasser;
    [SerializeField] private Transform WhereIsTyler;
    
    public static event Action<float> TakeDamage;
    
    // Update is called once per frame
    void Update()
    {
        chasser.SetDestination(WhereIsTyler.position);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        var tyler = collision.gameObject.GetComponent<TylerControl>();
        if (collision.gameObject.CompareTag("Player"))
        {
            tyler.damage(2);
            TakeDamage?.Invoke(tyler.tylerHP());
            tyler.GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * 600f,ForceMode.Force);
        }
        
    }
}
