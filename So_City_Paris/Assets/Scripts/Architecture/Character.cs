using UnityEngine;
using System.Collections.Generic;
using System;

namespace Architecture
{
    public abstract class Character : MonoBehaviour
    {
        [SerializeField] protected int _health;
        [SerializeField] protected int _maxHealth;

        protected void Start()
        {
        }

        private void Die()
        {
            Destroy(gameObject);
        }

        public void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new System.Exception("Damage less zero!");

            _health -= damage;

            if (_health <= 0)
                Die();
        }


    }
}

