using UnityEngine;

namespace View
{
    public class InfoViewState : ViewBaseState
    {

        [SerializeField] private InfoView view;
        [SerializeField] private GameController gameController;
        
        private string _playerName;
        
        public override void OnEnter()
        {
            if (CheckSaveData())
            {
                RequestStateChange(ViewStates.Game);
                return;
            }
            
            view.gameObject.SetActive(true);
            view.ShowInfo();
            view.OnNameTyped += SavePlayerData;
        }

        public override void OnExit()
        {
            view.OnNameTyped -= SavePlayerData;
            view.ClearReferences();
            view.gameObject.SetActive(false);
        }

        private void SavePlayerData(string playerName)
        {
            _playerName = playerName;
            PlayerPrefs.SetString("playerName", _playerName);
            PlayerPrefs.Save();

            gameController.PlayerName = playerName;
            
            RequestStateChange(ViewStates.Game);
        }

        private bool CheckSaveData()
        {
            if (PlayerPrefs.HasKey("playerName"))
            {
                _playerName = PlayerPrefs.GetString("playerName");
                gameController.PlayerName = _playerName;
                return true;
            }

            return false;
        }
    }
}