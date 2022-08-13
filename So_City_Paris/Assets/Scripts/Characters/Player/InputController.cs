using System.Collections.Generic;
using UnityEngine;

namespace Architecture.Player
{
    [RequireComponent(typeof(PlayerMover))]
    public class InputController : MonoBehaviour
    {
        private enum KeyButtonConfiguration
        {
            Run = 0,
            Jump,
            GoDown,
            Shoot
        };

        private Dictionary<KeyButtonConfiguration, KeyCode> _keyButtons;
        private PlayerMover _playerMover;
        private Idamagable _damagableEntity;
        private Weapon _Currentweapon;

        private void Start()
        {
            _keyButtons = new Dictionary<KeyButtonConfiguration, KeyCode>()
            {
                { KeyButtonConfiguration.Run, KeyCode.LeftShift },
                { KeyButtonConfiguration.Jump, KeyCode.Space },
                { KeyButtonConfiguration.GoDown, KeyCode.S },
                { KeyButtonConfiguration.Shoot, KeyCode.Mouse0 },
            };
            _Currentweapon = GetComponentInChildren<Weapon>();
            _damagableEntity = GetComponentInChildren<Idamagable>();
            _playerMover = GetComponent<PlayerMover>();
        }

        private void Update()
        {
            CheckPlayerMove();

            CheckPlayerJump();

            CheckPressedDown();

            CheckPlayerShoot();
        }

        private void CheckPlayerShoot()
        {
            if (Input.GetKeyDown(_keyButtons[KeyButtonConfiguration.Shoot]))
            {
                Debug.Log("Shoot Button Is pressed");
                _damagableEntity.GiveDamage(_Currentweapon);
            }
        }

        private void CheckPressedDown()
        {
            if (Input.GetKeyDown(_keyButtons[KeyButtonConfiguration.GoDown]))
            {
                _playerMover.TryGoDownOnPlatform();
            }
        }

        private void CheckPlayerMove()
        {
            float moveX = Input.GetAxis("Horizontal");

            if (Input.GetKey(_keyButtons[KeyButtonConfiguration.Run]))
            {
                _playerMover.Run(moveX);
            }
            else
            {
                _playerMover.Walk(moveX);
            }
        }

        private void CheckPlayerJump()
        {
            if (Input.GetKeyDown(_keyButtons[KeyButtonConfiguration.Jump]))
            {
                _playerMover.Jump();
            }
        }
    }
}