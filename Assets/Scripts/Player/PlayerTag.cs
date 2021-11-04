using RainbowCube.Skills;
using UnityEngine;

namespace RainbowCube.Player
{
    [RequireComponent(typeof(PlayerAttack))]
    public class PlayerTag : MonoBehaviour
    {
        [SerializeField] private BulletEffect currentEffect;

        private PlayerAttack _playerAttack;

        private void OnEnable()
        {
            _playerAttack = GetComponent<PlayerAttack>();
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire1") && currentEffect.affectFor == AffectFor.Enemy || currentEffect.affectFor == AffectFor.Environment)
            {
                _playerAttack.Attack(currentEffect);
            }
        }
    }
}