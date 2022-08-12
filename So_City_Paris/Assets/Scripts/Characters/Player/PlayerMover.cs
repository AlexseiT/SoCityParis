using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architecture.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _walkSpeed;
        [SerializeField] private float _runSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private CheckGround _checkGround;

        private Transform _transform;
        private Rigidbody2D _rigidBody2D;

        private void Start()
        {
            _transform = GetComponent<Transform>();
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _checkGround = GetComponentInChildren<CheckGround>();
        }

        public void Walk(float moveX)
        {
            Move(moveX * _walkSpeed);
        }

        public void Run(float moveX)
        {
            Move(moveX * _runSpeed);
        }

        private void Move(float move)
        {
            if (!Mathf.Approximately(move, 0))
                _transform.position += new Vector3(move * Time.deltaTime, 0);

        }

        public void Jump()
        {       
            if (_checkGround.IsGround)
                _rigidBody2D.AddForce(new Vector2(0, _jumpForce));
        }

        public void TryGoDownOnPlatform()
        {
            if (_checkGround.pl!= null)
                _checkGround.pl.RemoveSurfaceArc();
        }
    }

}