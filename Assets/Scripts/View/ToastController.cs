using System.Collections;
using TMPro;
using UnityEngine;

namespace View
{
    public class ToastController : MonoBehaviour
    {
        public static ToastController Toast;

        [SerializeField] private Animator animator;
        [SerializeField] private TMP_Text toastText;

        [SerializeField] private string toastEnter;
        [SerializeField] private string toastExit;
        
        private void Awake()
        {
            if (Toast != null && Toast != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Toast = this;
            }
        
            DontDestroyOnLoad(gameObject);
        }

        public void ShowToast(string text)
        {
            toastText.text = text;
            animator.SetTrigger(toastEnter);
            StartCoroutine(WaitAndHideToast());
        }

        private IEnumerator WaitAndHideToast()
        {
            yield return new WaitForSecondsRealtime(2f);
            animator.SetTrigger(toastExit);
        }
    }
}