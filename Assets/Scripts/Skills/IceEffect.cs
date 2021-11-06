using RainbowCube.Enemy;
using UnityEngine;

namespace RainbowCube.Skills
{
    [CreateAssetMenu(fileName = nameof(IceEffect), menuName = "Effects/Ice", order = 1)]
    public class IceEffect : BulletEffect
    {
        protected override void Affect(EnemyComponent enemyComponent)
        {
            enemyComponent.Mover.slowerEffect += 33;
        }
    }
}