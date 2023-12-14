using System;
using System.Collections;
using UnityEngine;

namespace View
{
    public class LoadingView : MonoBehaviour
    {
        
        [SerializeField] private Animator animator;

        public event Action OnLoadingOver;

        public void ShowLoading()
        {
            animator.SetTrigger($"Enter");
            StartCoroutine(FakeLoading());
        }

        public void HideLoading()
        {
            animator.SetTrigger($"Exit");
            StartCoroutine(WaitForExitAnimationOver());
        }

        private IEnumerator FakeLoading()
        {
            yield return new WaitForSecondsRealtime(3f);

            HideLoading();
        }

        private IEnumerator WaitForExitAnimationOver()
        {
            yield return new WaitForSeconds(0.5f);

            OnLoadingOver?.Invoke();
        }
    }
}