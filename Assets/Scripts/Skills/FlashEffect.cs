using RainbowCube.Enemy;

namespace RainbowCube.Skills
{
    public class FlashEffect : BulletEffect
    {
        protected override void Affect(EnemyComponent enemyComponent)
        {
            enemyComponent.Mover.randomWalker = true;
        }
    }
}