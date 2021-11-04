using UnityEngine;

namespace RainbowCube
{
    [RequireComponent(typeof(Collider))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField]
        private float speed = 15f;
        private float _damage;
        private Vector3 _direction;

        public void Init(Vector3 direction, float damage)
        {
            _direction = direction;
            _damage = damage;
            Destroy(gameObject, 15);
        }

        private void Update()
        {
            transform.position += _direction * speed * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            var damageable = other.GetComponent<IDamageable>();
            damageable?.GetDamage(_damage);
            Destroy(gameObject);
        }
    }
}