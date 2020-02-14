using UnityEngine;

namespace Game
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int coinValue = 1;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var counter = other.GetComponent<ScoreCounter>();
            if (counter != null)
            {
                counter.AddScore(coinValue);
                gameObject.SetActive(false);
            }

        }
    } 
}
