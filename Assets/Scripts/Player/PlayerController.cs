using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 10f;

        private Rigidbody2D _rb;
        private Vector2 _movement;
        private Vector2 _lookDirection;
        private Vector2 _mousePosition;
        private Camera _camera;
        
        public GameObject takeOffButton;
        public bool isAttached = true;
        
        private void Awake()
        {
            _camera = Camera.main;
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!isAttached)
            {
                HandleInput();
            }
        }

        private void FixedUpdate()
        {
            MoveAndRotatePlayer(_movement, _lookDirection);
        }

        private void HandleInput()
        {
            _movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            _lookDirection = _mousePosition - _rb.position;
        }

        private void MoveAndRotatePlayer(Vector2 movementVector, Vector2 rotationVector)
        {
            _rb.MovePosition(_rb.position + moveSpeed * Time.deltaTime * movementVector);

            var angle = Mathf.Atan2(rotationVector.y, rotationVector.x) * Mathf.Rad2Deg - 90f;
            _rb.rotation = angle;
        }

        public void TakeOff()
        {
            isAttached = false;
            takeOffButton.SetActive(false);
        }
    }
}
