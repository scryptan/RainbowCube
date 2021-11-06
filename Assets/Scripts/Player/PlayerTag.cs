using System.Collections.Generic;
using RainbowCube.Skills;
using UnityEngine;
using UnityEngine.UI;

namespace RainbowCube.Player
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(PlayerAttack))]
    public class PlayerTag : MonoBehaviour
    {
        public Health health;
        public RigibodyCharacterController character;
        public Image skillImage;

        [SerializeField] private List<BulletEffect> _effects = new List<BulletEffect>();
        private int effectIndex = -1;
        private BulletEffect currentEffect;

        private PlayerAttack _playerAttack;

        public void Affect(BulletEffect bulletEffect)
        {
            if(bulletEffect is HealEffect healEffect)
            {
                health.Heal(healEffect.healAmount);
            }

            if (bulletEffect is DashEffect dashEffect)
            {
                character.Dash(dashEffect.force);
            }
        }
        
        private void OnEnable()
        {
            _playerAttack = GetComponent<PlayerAttack>();
            health = GetComponent<Health>();
            character = GetComponent<RigibodyCharacterController>();
            if (effectIndex == -1)
                effectIndex = 0;
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (currentEffect.affectFor == AffectFor.Enemy || currentEffect.affectFor == AffectFor.Environment)
                {
                    _playerAttack.Attack(currentEffect);
                    return;
                }

                if (currentEffect.affectFor == AffectFor.Player)
                {
                    Affect(currentEffect);
                }
            }

            CycleEffectIndex();
        }

        private void CycleEffectIndex()
        {
            effectIndex += Mathf.CeilToInt(Input.mouseScrollDelta.y);

            if (effectIndex >= _effects.Count)
                effectIndex = 0;

            if (effectIndex < 0)
                effectIndex = _effects.Count - 1;

            currentEffect = _effects[effectIndex];
            skillImage.color = currentEffect.color;
        }
    }
}