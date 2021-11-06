using System;
using System.Threading.Tasks;
using UnityEngine;

namespace RainbowCube.Player
{
    [RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
    public class RigibodyCharacterController : MonoBehaviour
    {
        public Vector3 recoilRotation;
        public bool haveRecoil;

        [SerializeField] private float defaultSpeed = 15;
        [SerializeField] private float runSpeed = 30;
        [SerializeField] private float jumpForce = 5;
        [SerializeField] private float rotationSpeed = 80;
        [SerializeField] private Transform pointToForce;
        [SerializeField] private Transform walkableCheckPos;
        [SerializeField] private LayerMask walkableLayerMask;
        private GroundCheck _groundChecker;
        private Rigidbody _rigidbody;
        private Camera _playerCamera;
        private float _currentSpeed;
        private float _xRotation;
        private Vector3 dashVelocity;

        void OnEnable()
        {
            _groundChecker = GetComponentInChildren<GroundCheck>();
            walkableLayerMask = LayerMask.GetMask("Walkable");
            _playerCamera = GetComponentInChildren<Camera>();
            _rigidbody = GetComponent<Rigidbody>();
            ChangeCursorLockState(CursorLockMode.Locked);
        }

        void Update()
        {
            dashVelocity -= Vector3.one;
            HandleLook();


            HandleTranslating();
            if (_groundChecker.IsGrounded)
                HandleJump();

            if (Input.GetKeyDown(KeyCode.Escape))
                OnEsc();
        }

        private void OnEsc()
        {
            ChangeCursorLockState(Cursor.lockState == CursorLockMode.Locked
                ? CursorLockMode.None
                : CursorLockMode.Locked);
        }

        private void ChangeCursorLockState(CursorLockMode lockMode)
        {
            Cursor.lockState = lockMode;
        }

        private void HandleLook()
        {
            var mouseX = Input.GetAxis("Mouse X");
            var mouseY = Input.GetAxis("Mouse Y");

            _xRotation -= mouseY * rotationSpeed / 100;
            _xRotation = Mathf.Clamp(_xRotation, -90, 90);

            _playerCamera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);

            transform.Rotate(Vector3.up * (mouseX * rotationSpeed / 100));
        }

        private void HandleTranslating()
        {
            _currentSpeed = defaultSpeed;
            HandleRun();
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            var myTransform = transform;
            var newMovePos = myTransform.right * horizontal + myTransform.forward * vertical;
            newMovePos.y = 0;

            myTransform.position += newMovePos * Time.deltaTime * _currentSpeed;
            if(horizontal != 0 || vertical != 0)
                _rigidbody.velocity = Vector3.zero;
        }

        private void HandleRun()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _currentSpeed = runSpeed;
            }
        }

        private void HandleJump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _groundChecker.IsGrounded)
                _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        public void Dash(float force)
        {
            _rigidbody.AddForce((pointToForce.position - transform.position).normalized * force, ForceMode.Impulse);
        }
    }
}