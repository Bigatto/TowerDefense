using UnityEngine;

namespace Base.Scripts
{
    public class PlayerBase : MonoBehaviour
    {
        [SerializeField] private float maxHealth;

        private float _currentHealth;

        private void Start()
        {
            _currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                DestroyBase();
            }
        }

        private void DestroyBase()
        {
            gameObject.SetActive(false);
        }
    }
}