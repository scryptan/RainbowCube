using RainbowCube.Enemy;
using UnityEngine;

namespace RainbowCube.Skills
{
    [CreateAssetMenu(fileName = nameof(FireEffect), menuName = "Effects/Fire", order = 1)]
    public class FireEffect : BulletEffect
    {
        public float damage;

        protected override void Affect(EnemyComponent enemyComponent)
        {
            enemyComponent.health.Damage(damage);
        }
    }
}