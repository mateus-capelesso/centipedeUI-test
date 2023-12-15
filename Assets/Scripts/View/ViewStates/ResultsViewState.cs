using UnityEngine;

namespace View
{
    public class ResultsViewState : ViewBaseState
    {
        [SerializeField] private ResultsView view;
        [SerializeField] private GameController gameController;
        public override void OnEnter()
        {
            view.gameObject.SetActive(true);
            view.ShowResults(gameController.PlayerName, gameController.Score);
            view.OnRetryClicked += RetryClicked;
        }

        public override void OnExit()
        {
            view.gameObject.SetActive(false);
            view.OnRetryClicked -= RetryClicked;
        }

        private void RetryClicked()
        {
            gameController.ResetGame();
            RequestStateChange(ViewStates.Loading);
        }
    }
}