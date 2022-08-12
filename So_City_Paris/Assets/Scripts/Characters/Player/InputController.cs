using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Architecture.Player
{
    [RequireComponent(typeof(PlayerMover))]
    public class InputController : MonoBehaviour
    {
        private enum KeyButtonConfiguration
        {
            Run = 0,
            Jump,
            GoDown
        };

        private Dictionary<KeyButtonConfiguration, KeyCode> _keyButtons;
        private PlayerMover _playerMover;

        private void Start()
        {
            _keyButtons = new Dictionary<KeyButtonConfiguration, KeyCode>()
            {
                { KeyButtonConfiguration.Run, KeyCode.LeftShift },
                { KeyButtonConfiguration.Jump, KeyCode.Space },
                { KeyButtonConfiguration.GoDown, KeyCode.S },
                
            };

            _playerMover = GetComponent<PlayerMover>();
        }

        private void Update()
        {
            PlayerMove();

            PlayerJump();

            if (Input.GetKeyDown(_keyButtons[KeyButtonConfiguration.GoDown]))
            {
                _playerMover.TryGoDownOnPlatform();
            }

        }

        private void PlayerMove()
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

        private void PlayerJump()
        {
            if (Input.GetKeyDown(_keyButtons[KeyButtonConfiguration.Jump]))
            {
                _playerMover.Jump();
            }
        }
    }
}
