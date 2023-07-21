using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Animations;
using UdemyProject2.Combats;
using UdemyProject2.Inputs;
using UdemyProject2.Movements;
using UnityEngine;
namespace UdemyProject2.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        

        float _horizontal;
        float _vertical;
        bool _isJump;

        PcInput _input;
        Mover _mover;
        Jump _jump;
        CharacterAnimation _characterAnimation;
        Flip _flip;
        OnGround _onGround;
        Climbing _climbing;
        Health _health;

        private void Awake()
        {
            _characterAnimation = GetComponent<CharacterAnimation>();
            _mover = GetComponent<Mover>();
            _jump = GetComponent<Jump>();
            _flip = GetComponent<Flip>();
            _onGround = GetComponent<OnGround>();
            _climbing = GetComponent<Climbing>();
            _input = gameObject.AddComponent<PcInput>();
            _health = GetComponent<Health>();
        }
        private void Update()
        {
            _horizontal = _input.Horizontal;
            _vertical = _input.Vertical;

            if (_input.IsJumpButtonDown && _onGround.IsOnGround)
            {
                _isJump = true;
                
            }

            _characterAnimation.MoveAnimation(_horizontal);
            _characterAnimation.JumpAnimation(!_onGround.IsOnGround && _jump.IsJump);

        }

        private void FixedUpdate()
        {
            _climbing.ClimbAction(_vertical);
            _mover.HorizontalMove(_horizontal);
            _flip.FlipCharacter(_horizontal);

            if (_isJump)
            {
                _jump.JumpAction();
                _isJump = false;
                
            }

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Damage damage = collision.collider.GetComponent<Damage>();
            if (damage != null)
            {
                _health.TakeHit(damage);
            }
        }
    }
}

