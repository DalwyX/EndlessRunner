using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Game
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float endGameDelay;
        [SerializeField] private UnityEvent Died;

        public async void TakeDamage()
        {
            Died?.Invoke();
            await Task.Delay(TimeSpan.FromSeconds(endGameDelay));
            SceneManager.LoadScene(0);
        }
    } 
}
