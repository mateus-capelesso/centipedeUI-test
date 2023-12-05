using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace View
{
    public class ViewStateMachine : MonoBehaviour
    {
        [SerializeField] private ViewStates initialState;
        [SerializeField] private List<ViewBaseState> viewStates;

        private Dictionary<ViewStates, ViewBaseState> statesDictionary;
        private ViewStates _currentState;
        

        private void Start()
        {
            InitializeStateMachine();
        }

        private void InitializeStateMachine()
        {
            statesDictionary = new Dictionary<ViewStates, ViewBaseState>();
            
            foreach (var view in viewStates)
            {
                view.Initialize(this);
                statesDictionary.Add(view.state, view);
            }

            _currentState = initialState;
            RequestStateChange(initialState);
        }

        public void RequestStateChange(ViewStates targetState)
        {
            if (_currentState != targetState)
            {
                statesDictionary[_currentState].OnExit();
            }

            _currentState = targetState;
            statesDictionary[_currentState].OnEnter();
        }
    }
}
