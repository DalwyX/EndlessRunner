using UnityEngine;
using UnityEngine.UI;
using Game;

namespace UI
{
    [RequireComponent(typeof(Text))]
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private ScoreCounter _scoreCounter;
        private Text _textField;

        private void Awake()
        {
            _textField = GetComponent<Text>();
            UpdateValue();
        }

        private void OnEnable()
        {
            if (_scoreCounter != null)
                _scoreCounter.ScoreUpdated += UpdateValue;
        }

        private void OnDisable()
        {
            if (_scoreCounter != null)
                _scoreCounter.ScoreUpdated -= UpdateValue;
        }

        private void UpdateValue()
        {
            if (_scoreCounter != null)
                _textField.text = _scoreCounter._currentScore.ToString();
        }
    } 
}
