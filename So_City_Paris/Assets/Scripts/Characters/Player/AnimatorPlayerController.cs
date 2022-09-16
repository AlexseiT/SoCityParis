using Architecture.PlayerSpace;
using System;
using UnityEngine;

namespace Architecture
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorPlayerController : MonoBehaviour
    {
        private Animator _animator;
        private readonly string _speedParamName = "Speed";
        private readonly string _jumpParamName = "IsJumping";

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            CheckGround.onLanded += StopPlayJumpAnim;
        }

        private void OnDisable()
        {
            CheckGround.onLanded -= StopPlayJumpAnim;
        }
        public void SetSpeedValue(float move) => _animator.SetFloat(_speedParamName, (float)Math.Round(Mathf.Abs(move), 2));

        public void SetJumpAnim() => _animator.SetBool(_jumpParamName, true);

        public void StopPlayJumpAnim() => _animator.SetBool(_jumpParamName, false);
    }
}