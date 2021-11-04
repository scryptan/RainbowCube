using UnityEngine;

namespace RainbowCube
{
    public class BulletSpawner: MonoBehaviour
    {        
        [SerializeField]
        private Bullet bulletPrefab;
        [SerializeField]
        private Transform startPosition;

        public void SpawnBullet(Vector3 destination, float damage)
        {
            var position = startPosition.position;
            var currentInstance = Instantiate(bulletPrefab, position, Quaternion.identity);
            
            currentInstance.Init(destination - position, damage);
        }
    }
}