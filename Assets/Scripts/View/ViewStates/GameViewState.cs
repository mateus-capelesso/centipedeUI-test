using System.Collections.Generic;
using UnityEngine;

namespace View
{
    public class GameViewState : ViewBaseState
    {
        [SerializeField] private GameController game;

        [SerializeField] private List<GameObject> gameItems;
        public override void OnEnter()
        {
            SignEvents();
            SetGameItems(true);
            game.Play();
        }

        public override void OnExit()
        {
            ReleaseEvents();
        }

        private void SetGameItems(bool active)
        {
            foreach (var obj in gameItems)
            {
                obj.SetActive(active);
            }
        }

        private void SignEvents()
        {
            GameEvents.GameOverEvent += GameOver;
            GameEvents.NextLevel += LevelUp;
            GameEvents.IncreaseScore += Score;
            GameEvents.CentipedeHitEvent += CentipedeHit;
        }

        private void ReleaseEvents()
        {
            GameEvents.GameOverEvent -= GameOver;
            GameEvents.NextLevel -= LevelUp;
            GameEvents.IncreaseScore -= Score;
            GameEvents.CentipedeHitEvent -= CentipedeHit;
        }

        private void GameOver()
        {
            
        }

        private void LevelUp()
        {
            
        }

        private void Score(int score)
        {
            
        }

        private void CentipedeHit(Vector3 position)
        {
            
        }
        
    }
}