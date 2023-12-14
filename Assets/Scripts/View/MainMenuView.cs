using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

namespace View
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private List<Animator> mainMenuAnimators;
        [SerializeField] private float delay = 1f;
        
        [SerializeField] private string enterTrigger;
        [SerializeField] private string exitTrigger;
        
        
        public void EnterMainMenu()
        {
            StartCoroutine(TriggerAnimation(enterTrigger));
        }

        public void ExitMainMenu()
        {
            StartCoroutine(TriggerAnimation(exitTrigger));
        }

        private IEnumerator TriggerAnimation(string trigger)
        {

            foreach (var animator in mainMenuAnimators)
            {
                animator.SetTrigger(trigger);
                yield return new WaitForSeconds(delay);
            }
            
            yield return new WaitForEndOfFrame();
        } 
    }
}