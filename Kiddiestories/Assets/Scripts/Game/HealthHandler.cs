using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kiddiestories
{
    public class HealthHandler : MonoBehaviour
    {

        [SerializeField] private GameObject[] _healthObject;

        private const int _defaultHealth = 3;
        private int _currentHealth;

        public void Start()
        {
            _currentHealth = _defaultHealth;
        }

        public int GetCurrentHealth()
        {
            return _currentHealth;
        }

        public void LoseHealth()
        {
            if (_currentHealth <= 0)
                return;

            _currentHealth--;
            _healthObject[_currentHealth].SetActive(false);
        }

        public void Reset()
        {
            foreach (GameObject o in _healthObject)
            {
                o.SetActive(true);
            }

            _currentHealth = _defaultHealth;
        }

    }
}
