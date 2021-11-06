using RainbowCube.Enemy;
using UnityEngine;

namespace RainbowCube.Skills
{
    [CreateAssetMenu(fileName = nameof(HealEffect), menuName = "Effects/Heal", order = 1)]
    public class HealEffect : BulletEffect
    {
        public float healAmount = 30;
        
        protected override void Affect(EnemyComponent enemyComponent)
        {
            
        }
    }
}