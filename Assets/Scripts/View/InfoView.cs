using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class InfoView : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private TMP_InputField inputName;
        [SerializeField] private TMP_Text errorInput;
        [SerializeField] private Button continueButton;

        [SerializeField] private string enterTrigger;
        [SerializeField] private string exitTrigger;

        public event Action<string> OnNameTyped;

        public void ShowInfo()
        {
            animator.SetTrigger(enterTrigger);
            inputName.onSelect.AddListener(ClearInputField);
            inputName.onEndEdit.AddListener(s =>
            {
                ContinueClicked();
            });
            continueButton.onClick.AddListener(ContinueClicked);
        }
        
        private void ContinueClicked()
        {
            if (string.IsNullOrEmpty(inputName.text))
            {
                errorInput.gameObject.SetActive(true);
                errorInput.text = "Please, inform your name";
                inputName.placeholder.color = Color.red;
                return;
            }
            
            animator.SetTrigger(exitTrigger);
            StartCoroutine(WaitExitAnimation());
        }

        private void ClearInputField(string s)
        {
            errorInput.gameObject.SetActive(false);
            inputName.placeholder.color = Color.white;
        }

        public void ClearReferences()
        {
            inputName.onSelect.RemoveListener(ClearInputField);
            inputName.onEndEdit.RemoveAllListeners();
            continueButton.onClick.RemoveListener(ContinueClicked);
        }

        private IEnumerator WaitExitAnimation()
        {
            
            yield return new WaitForSecondsRealtime(0.5f);
            
            OnNameTyped?.Invoke(inputName.text);
            
        }
        
    }
}