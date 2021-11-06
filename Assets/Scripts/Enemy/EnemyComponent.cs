using System;
using RainbowCube.Skills;
using UnityEngine;

namespace RainbowCube.Enemy
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(EnemyMover))]
    [RequireComponent(typeof(EffectApplier))]
    public class EnemyComponent : MonoBehaviour, IAffectable
    {
        public Health health;
        public EnemyMover Mover;
        private EffectApplier _effectApplier;

        private void OnEnable()
        {
            Mover = GetComponent<EnemyMover>();
            _effectApplier = GetComponent<EffectApplier>();
            health = GetComponent<Health>();
            health.OnDead = Dead;
            _effectApplier.Init(this);
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
            _effectApplier.AddEffect(effect);
        }

        private void Update()
        {
            Mover.Move();
            _effectApplier.ProcessEffects();
        }
    }
}