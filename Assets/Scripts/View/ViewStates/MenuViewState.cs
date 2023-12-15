using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace View
{
    public class MenuViewState : ViewBaseState
    {
        [SerializeField] private MainMenuView view;
        [SerializeField] private Button startGameButton;
        [SerializeField] private Button optionsButton;
        [SerializeField] private Button exitGameButton;
        [SerializeField] private GameObject mainMenu;
        
        public override void OnEnter()
        {
            view.gameObject.SetActive(true);
            startGameButton.onClick.AddListener(StartGameClicked);
            optionsButton.onClick.AddListener(OptionsClicked);
            exitGameButton.onClick.AddListener(ExitGameClicked);

            EventSystem.current.SetSelectedGameObject(startGameButton.gameObject);
            
            view.EnterMainMenu();
        }

        public override void OnExit()
        {
            startGameButton.onClick.RemoveListener(StartGameClicked);
            exitGameButton.onClick.RemoveListener(OptionsClicked);
            optionsButton.onClick.RemoveListener(ExitGameClicked);
            view.gameObject.SetActive(false);
            StartCoroutine(WaitForTransition());
        }

        private void StartGameClicked()
        {
            view.ExitMainMenu();
            StartCoroutine(WaitExitAnimation(() => RequestStateChange(ViewStates.Loading)));

        }

        private void ExitGameClicked()
        {
            Application.Quit();
        }

        private void OptionsClicked()
        {
            PlayerPrefs.DeleteAll();
            ToastController.Toast.ShowToast("Data Cleared");
        }

        private IEnumerator WaitExitAnimation(Action callback)
        {
            yield return new WaitForSecondsRealtime(0.3f);
            
            callback?.Invoke();
        }

        // Wait loading transition to hide main menu
        private IEnumerator WaitForTransition()
        {
            yield return new WaitForSeconds(1f);
            mainMenu.gameObject.SetActive(false);
        }
        
    }
}