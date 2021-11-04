using UnityEngine;

namespace RainbowCube.Player
{
    public class GroundCheck : MonoBehaviour
    {
        public bool IsGrounded;

        private void OnTriggerStay(Collider other)
        {
            if (other.GetComponent<PlayerTag>() == null)
                IsGrounded = true;
        }

        private void OnTriggerExit(Collider other)
        {
            IsGrounded = false;
        }
    }
}
