using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class ResultsView : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private TMP_Text playerName;
        [SerializeField] private TMP_Text playerScore;
        [SerializeField] private Button retryButton;
        [SerializeField] private Animator buttonAnimator;

        public event Action OnRetryClicked;

        public void ShowResults(string player, int score)
        {
            playerName.text = player;
            playerScore.text = $"{score}";
            retryButton.onClick.AddListener(RetryButton);
            
            animator.SetTrigger("Enter");
            StartCoroutine(WaitAnimationEnter());
        }

        private void RetryButton()
        {
            OnRetryClicked?.Invoke();
        }

        private IEnumerator WaitAnimationEnter()
        {
            yield return new WaitForSecondsRealtime(.75f);
            
            buttonAnimator.SetTrigger("Enter");
        } 
    }
    
}