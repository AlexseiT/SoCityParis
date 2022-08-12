using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Architecture
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorController : MonoBehaviour
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }   

        public void SetBoolAnimation(string nameAnimation, bool param)
        {
            _animator.SetBool(nameAnimation, param);
        }       
    
        public void SetTriggerAnimation(string nameAnimation)
        {
            _animator.SetTrigger(nameAnimation);
        }       
        
        public void SetIntAnimation(string nameAnimation, int param)
        {
            _animator.SetInteger(nameAnimation, param);
        }       
        
        public void SetFloatAnimation(string nameAnimation, float param)
        {
            _animator.SetFloat(nameAnimation, param);
        }       
    }
}