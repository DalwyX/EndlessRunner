using UnityEngine;

namespace Game
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int _coinValue = 1;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<ScoreCounter>(out var counter))
            {
                counter.AddScore(_coinValue);
                gameObject.SetActive(false);
            }
        }
    } 
}
