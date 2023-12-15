using System.Collections.Generic;
using UnityEngine;

namespace View
{
    public class GameViewState : ViewBaseState
    {
        [SerializeField] private GameController game;
        [SerializeField] private GameView view;
        
        [SerializeField] private List<GameObject> gameItems;

        private string _playerName;
        public override void OnEnter()
        {
            _playerName = game.PlayerName;
            
            SignEvents();
            SetGameItems(true);
            
            view.SetPlayerName(_playerName);
            game.Play();
        }

        public override void OnExit()
        {
            SetGameItems(false);
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
            GameEvents.IncreaseScore += view.UpdateScore;
            GameEvents.CentipedeHitEvent += view.ShowScoreParticle;
        }

        private void ReleaseEvents()
        {
            GameEvents.GameOverEvent -= GameOver;
            GameEvents.NextLevel -= LevelUp;
            GameEvents.IncreaseScore -= view.UpdateScore;
            GameEvents.CentipedeHitEvent -= view.ShowScoreParticle;
        }

        private void GameOver()
        {
            RequestStateChange(ViewStates.Results);
        }

        private void LevelUp()
        {
            
        }
    }
}