using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChassingTyler : MonoBehaviour
{
    public NavMeshAgent chasser;
    [SerializeField] private Transform WhereIsTyler;
    
    void Start()
    {
        chasser = new NavMeshAgent();
    }

    // Update is called once per frame
    void Update()
    {
        chasser.SetDestination(WhereIsTyler.position);
    }
}
