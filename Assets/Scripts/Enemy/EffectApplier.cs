using System;
using System.Collections.Generic;
using RainbowCube.Skills;
using UnityEngine;

namespace RainbowCube.Enemy
{
    public class EffectApplier: MonoBehaviour
    {
        private readonly List<BulletEffect> _effects = new List<BulletEffect>();
        private readonly List<BulletEffect> _effectsToRemove = new List<BulletEffect>();
        private EnemyComponent _enemyComponent;

        public void Init(EnemyComponent enemyComponent)
        {
            _enemyComponent = enemyComponent;
        }
        
        public void AddEffect(BulletEffect effect)
        {
            _effects.Add(effect);
        }

        private void Update()
        {
            foreach (var effect in _effects)
            {
                effect.Apply(_enemyComponent);
                if (effect.ShouldDelete)
                    _effectsToRemove.Add(effect);
            }

            foreach (var effect in _effectsToRemove)
                _effects.Remove(effect);
            
            _effectsToRemove.Clear();
        }
    }
}