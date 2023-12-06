using System;
using UnityEngine;

namespace View
{
    public class IntroViewState : ViewBaseState
    {
        [SerializeField] private Animator ctaAnimator;
        
        private bool _isIntroState;
        
        public override void OnEnter()
        {
            _isIntroState = true;
            ctaAnimator.Play("IntroEnter");
        }

        private void ConfirmIntro()
        {
            _isIntroState = false;
            ctaAnimator.SetTrigger("confirmIntro");
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