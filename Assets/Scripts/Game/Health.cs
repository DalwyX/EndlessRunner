using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Game
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _gameOverDelay;
        [SerializeField] private UnityEvent _died;

        public async void TakeDamage()
        {
            _died?.Invoke();
            await Task.Delay(TimeSpan.FromSeconds(_gameOverDelay));
            SceneManager.LoadScene(0);
        }
    } 
}
