using TMPro;
using UnityEngine;

namespace View
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private GameObject scoreParticle;
        [SerializeField] private Transform particleHolder;

        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text nameText;

        private int _score = 0;

        public void ShowScoreParticle(Vector3 position)
        {
            Instantiate(scoreParticle, position, Quaternion.identity, particleHolder);
        }

        public void UpdateScore(int score)
        {
            _score += score;
            scoreText.text = $"Score: {_score}";
        }

        public void SetPlayerName(string playerName)
        {
            nameText.text = $"Player: {playerName}";
        }
        
    }
}