using UnityEngine;
using UnityEngine.UI;

namespace Base.Scripts
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        [SerializeField] private Image healthUi;

        private float _currentHealth;

        private void Start()
        {
            _currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            var currentHealthPercent = _currentHealth / maxHealth;

            var imageScale = healthUi.transform.localScale;
            imageScale.x = currentHealthPercent;
            healthUi.transform.localScale = imageScale;

            if (_currentHealth <= 0)
            {
                DestroyObject();
            }
        }

        private void DestroyObject()
        {
            gameObject.SetActive(false);
        }
    }
}