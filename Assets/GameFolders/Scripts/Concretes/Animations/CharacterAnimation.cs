using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject2.Animations
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimation : MonoBehaviour
    {
        Animator _animator;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        public void MoveAnimation(float horizontal)
        {
            float MathfValue = Mathf.Abs(horizontal);

            if (_animator.GetFloat("MoveSpeed") == horizontal) return;
            
            _animator.SetFloat("MoveSpeed", MathfValue);
        }

        public void JumpAnimation(bool isJump)
        {
            if (isJump == _animator.GetBool("isJump")) return;

            _animator.SetBool("isJump", isJump);

        }
    }
}
