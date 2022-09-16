using UnityEngine;

namespace Architecture.PlayerSpace
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMover : MonoBehaviour, IFliper
    {
        [SerializeField] private float _walkSpeed;
        [SerializeField] private float _runSpeed;
        [SerializeField] private float _jumpForce;
        private CheckGround _checkGround;
        private AnimatorPlayerController _animatorController;

        private Transform _transform;
        private Rigidbody2D _rigidBody2D;

        private void Start()
        {
            _animatorController = GetComponent<AnimatorPlayerController>();
            _transform = GetComponent<Transform>();
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _checkGround = GetComponentInChildren<CheckGround>();
        }

        public void Walk(float moveX)
        {
            var move = moveX * _walkSpeed;
            Move(move);
            _animatorController.SetSpeedValue(move);
        }

        public void Run(float moveX)
        {
            var move = moveX * _runSpeed;
            Move(move);
            _animatorController.SetSpeedValue(move);
        }

        private void Move(float move)
        {
            if (!Mathf.Approximately(move, 0))
            {
                _transform.position += new Vector3(move * Time.deltaTime, 0);
            }
        }

        public void Jump()
        {
            if (_checkGround.IsGround)
            {
                _rigidBody2D.velocity = Vector2.up*_jumpForce;
                _animatorController.SetJumpAnim();
            }
                
        }

        public void Flip(float move)
        {
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);
        }

        public void TryGoDownOnPlatform()
        {
            if (_checkGround.pl != null)
                _checkGround.pl.RemoveSurfaceArc();
        }
    }
}