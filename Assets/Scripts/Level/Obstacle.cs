using UnityEngine;
using Game;

namespace Level
{
    public class Obstacle : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            collision.collider.GetComponent<Health>()?.TakeDamage();
        }
    } 
}
