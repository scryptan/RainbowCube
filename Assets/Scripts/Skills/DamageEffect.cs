using RainbowCube.Enemy;
using UnityEngine;

namespace RainbowCube.Skills
{
    [CreateAssetMenu(fileName = nameof(DamageEffect), menuName = "Effects/Damage", order = 1)]
    public class DamageEffect: BulletEffect
    {
        public float damage;

        protected override void Affect(EnemyComponent enemyComponent)
        {
            enemyComponent.health.Damage(damage);
        }
    }
}