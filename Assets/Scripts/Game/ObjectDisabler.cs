﻿using UnityEngine;

namespace Game
{
    public class ObjectDisabler : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.gameObject.SetActive(false);
        }
    } 
}
