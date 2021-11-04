using UnityEngine;

namespace RainbowCube.Player
{
    [RequireComponent(typeof(PlayerAttack))]
    public class PlayerTag : MonoBehaviour
    {
        private PlayerAttack _playerAttack;

        private void OnEnable()
        {
            _playerAttack = GetComponent<PlayerAttack>();
        }

        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _playerAttack.Attack(100);
            }
        }
    }
}
