using System;
using UnityEngine;

namespace Game
{
    public class ScoreCounter : MonoBehaviour
    {
        public int currentScore { get; private set; }
        public event Action ScoreUpdated;

        public void AddScore(int val)
        {
            currentScore += val;
            ScoreUpdated?.Invoke();
        }
    } 
}