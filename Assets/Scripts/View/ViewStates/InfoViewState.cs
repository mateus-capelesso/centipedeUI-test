using UnityEngine;

namespace View
{
    public class InfoViewState : ViewBaseState
    {

        [SerializeField] private InfoView view;
        
        private string _playerName;
        private const string NameKey = "playerName";
        
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
            PlayerPrefs.SetString(NameKey, _playerName);
        }

        private bool CheckSaveData()
        {
            if (PlayerPrefs.HasKey(NameKey))
            {
                _playerName = PlayerPrefs.GetString("playerName");
                return true;
            }

            return false;
        }
    }
}