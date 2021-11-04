using RainbowCube.Skills;
using UnityEngine;

namespace RainbowCube
{
    [RequireComponent(typeof(Collider))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private float speed = 15f;
        private BulletEffect _bulletEffect;
        private Vector3 _direction;

        public void Init(Vector3 direction, BulletEffect bulletEffect)
        {
            _direction = direction;
            _bulletEffect = bulletEffect;
            Destroy(gameObject, 15);
        }

        private void Update()
        {
            transform.position += _direction * speed * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            var damageable = other.GetComponent<IAffectable>();
            damageable?.GetAffect(_bulletEffect);
            Destroy(gameObject);
        }
    }
}