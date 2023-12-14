using System;
using UnityEngine;

namespace View
{
    public class IntroViewState : ViewBaseState
    {
        [SerializeField] private Animator ctaAnimator;
        [SerializeField] private GameObject mainMenu;
        
        private bool _isIntroState;
        
        public override void OnEnter()
        {
            mainMenu.SetActive(true);
            _isIntroState = true;
        }

        private void ConfirmIntro()
        {
            _isIntroState = false;
            ctaAnimator.SetTrigger("IntroConfirm");
            RequestStateChange(ViewStates.Menu);
        }

        private void Update()
        {
            if (!_isIntroState) return;

            if (Input.anyKey)
            {
                ConfirmIntro();
            }
        }
    }
}