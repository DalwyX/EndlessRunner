using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class Obstacle : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            //if (collision.collider.GetComponent<Player>() != null)
            //{
            //    SceneManager.LoadScene(0);
            //}
        }
    } 
}
