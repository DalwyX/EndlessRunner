using UnityEngine;

namespace ObjectPool
{
    public class ObjectDisabler : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.gameObject.SetActive(false);
        }
    } 
}
