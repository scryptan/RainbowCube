using RainbowCube.Skills;
using UnityEngine;

namespace RainbowCube.Enemy
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(EffectApplier))]
    public class EnemyComponent : MonoBehaviour, IAffectable
    {
        public Health health;
        private EffectApplier effectApplier;

        private void OnEnable()
        {
            effectApplier = GetComponent<EffectApplier>();
            health = GetComponent<Health>();
            health.OnDead = Dead;
            effectApplier.Init(this);
        }

        private void OnDisable()
        {
            health = GetComponent<Health>();
            health.OnDead = null;
        }

        private void Dead()
        {
            Destroy(gameObject);
        }

        public void GetAffect(BulletEffect effect)
        {
            effectApplier.AddEffect(effect);
        }
    }
}