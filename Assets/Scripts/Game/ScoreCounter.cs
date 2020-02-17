using System;
using UnityEngine;

namespace Game
{
    public class ScoreCounter : MonoBehaviour
    {
        public int _currentScore { get; private set; }
        public event Action ScoreUpdated;

        public void AddScore(int val)
        {
            _currentScore += val;
            ScoreUpdated?.Invoke();
        }
    } 
}