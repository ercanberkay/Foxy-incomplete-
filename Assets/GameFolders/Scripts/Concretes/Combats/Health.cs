using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 namespace UdemyProject2.Combats
{
    public class Health : MonoBehaviour
    {
        [SerializeField] int maxHealth = 3;
        [SerializeField] int currentHealth = 0;

        public bool IsDead => currentHealth < 1;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        public void TakeHit(Damage damage)
        {
            if (IsDead) return;
            {
                currentHealth -= damage.HitDamage;
            }
            
        }
    }


}
