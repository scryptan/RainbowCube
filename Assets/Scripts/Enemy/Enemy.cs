using UnityEngine;

namespace RainbowCube.Enemy
{
    [RequireComponent(typeof(Health))]
    public class Enemy : MonoBehaviour, IDamageable
    {
        public Health health;

        private void OnEnable()
        {
            health = GetComponent<Health>();
            health.OnDead = Dead;
        }

        private void OnDisable()
        {
            health = GetComponent<Health>();
            health.OnDead = null;
        }

        public void GetDamage(float amount)
        {
            health.Damage(amount);
        }

        private void Dead()
        {
            Destroy(gameObject);
        }
    }
}