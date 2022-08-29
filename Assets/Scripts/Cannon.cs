using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cannon : MonoBehaviour
{
    public static event Action ShootHappend;
    [SerializeField]private float Firerate = 1f;
    [SerializeField]private float _timeToShoot = 2f;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bullet;
    private bool fire = false;
    private float _timer;
    

    void Update()
    {
        _timer += Time.deltaTime * Firerate;
        if (fire && _timer > _timeToShoot){
            ShootHappend?.Invoke();
            Debug.Log("Pew");
            Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
            _timer = 0;
        }
    }

    void OnShoot(InputValue input)
    {
        fire = input.isPressed;
    }
}