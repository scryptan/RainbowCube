using RainbowCube.Enemy;
using UnityEngine;

namespace RainbowCube.Skills
{
    [CreateAssetMenu(fileName = nameof(DashEffect), menuName = "Effects/Dash", order = 1)]
    public class DashEffect : BulletEffect
    {
        public float force = 5f;
        protected override void Affect(EnemyComponent enemyComponent)
        {
        }
    }
}