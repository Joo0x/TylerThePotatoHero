    using System;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using UnityEngine.Pool;

    public class BulletPool : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private float bulletSpeed = 40;
        public static event Action ShootHappend;
        private ObjectPool<Bullet> bulletPool;



        private void Awake()
        {
            bulletPool = new ObjectPool<Bullet>(
                CreatePooledObject,
                OnTakeFromPool,
                OnReturnToPool,
                OnDestroyObject,
                false,
                10,
                20);
        }
        

        void OnShoot(InputValue input)
        {
            ShootHappend?.Invoke();
            bulletPool.Get();
        }
        

        void SpawnBullet(Bullet obj)
        {
            var bullet = bulletPool.Get();
            bullet.Shoot(bulletSpawnPoint.transform.position,gameObject.transform.forward , bulletSpeed);
        }
        

        private void OnDestroyObject(Bullet obj)
        {
            Destroy(obj.gameObject);
        }

        private void OnReturnToPool(Bullet obj)
        {
            obj.gameObject.SetActive(false);
        }

        private void OnTakeFromPool(Bullet obj)
        {
            obj.gameObject.SetActive(true);
            obj.Shoot(bulletSpawnPoint.transform.position,gameObject.transform.forward , 20);
        }

        Bullet CreatePooledObject()
        {
            Bullet bullet = Instantiate(_bulletPrefab, Vector3.zero, Quaternion.identity);
            bullet.Disable += KillBullet;
            bullet.gameObject.SetActive(false);

            return bullet;
        }

        void KillBullet(Bullet obj)
        {
            bulletPool.Release(obj);
        }
    }
