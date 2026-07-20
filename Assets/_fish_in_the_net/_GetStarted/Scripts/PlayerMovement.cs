using FishNet.Object;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FishInTheNet.GetStarted
{
    public class PlayerMovement : NetworkBehaviour
    {
        public float MoveSpeed = 5f;
        private Vector2 _currentMovementInput;

        public override void OnStartClient()
        {
            if (IsOwner)
                GetComponent<PlayerInput>().enabled = true;
        }

        public void OnMove(InputValue value)
        {
            _currentMovementInput = value.Get<Vector2>();
        }

        public void Update()
        {
            if (!IsOwner)
                return;

            Vector3 moveDirection = new Vector3(_currentMovementInput.x, 0f, _currentMovementInput.y);
            if (moveDirection.magnitude > 1f)
                moveDirection.Normalize();

            transform.position += MoveSpeed * Time.deltaTime * moveDirection;
        }
    }
}