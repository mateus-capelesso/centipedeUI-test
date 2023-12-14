using UnityEngine;

namespace View
{
    public class LoadingViewState : ViewBaseState
    {
        [SerializeField] private LoadingView view;
        
        public override void OnEnter()
        {
            view.gameObject.SetActive(true);
            view.ShowLoading();
            view.OnLoadingOver += RequestNextState;
        }

        public override void OnExit()
        {
            view.OnLoadingOver -= RequestNextState;
            view.gameObject.SetActive(false);
        }

        private void RequestNextState()
        {
            RequestStateChange(ViewStates.Info);
        }
    }
}