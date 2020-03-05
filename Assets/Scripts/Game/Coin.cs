using UnityEngine;

namespace Game
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int _value = 1;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<ScoreCounter>(out var counter))
            {
                counter.AddScore(_value);
                gameObject.SetActive(false);
            }
        }
    } 
}
