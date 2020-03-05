using System;
using UnityEngine;

namespace Game
{
    public class ScoreCounter : MonoBehaviour
    {
        public int Amount { get; private set; }
        public event Action Changed;

        public void AddScore(int value)
        {
            Amount += value;
            Changed?.Invoke();
        }
    } 
}