using RainbowCube.Enemy;
using UnityEngine;

namespace RainbowCube.Skills
{
    public abstract class BulletEffect : ScriptableObject
    {
        public int id;
        public Color color = Color.white;
        
        [SerializeField] private float duration;
        [SerializeField] private float affectDelay;
        private float _affectedTime;
        private float _delayedTime;

        public AffectFor affectFor = AffectFor.Enemy;
        public bool ShouldDelete => duration <= _affectedTime;

        protected abstract void Affect(EnemyComponent enemyComponent);

        public void Apply(EnemyComponent enemyComponent)
        {
            _affectedTime += Time.deltaTime;
            if (_delayedTime <= 0)
            {
                Affect(enemyComponent);
                _delayedTime = affectDelay;
            }

            _delayedTime -= Time.deltaTime;
        }
    }
}