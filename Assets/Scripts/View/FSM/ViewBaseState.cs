using UnityEngine;
namespace View
{
    public abstract class ViewBaseState: MonoBehaviour
    {
        private ViewStateMachine _controller;
        public ViewStates state;

        public virtual void Initialize(ViewStateMachine controller)
        {
            _controller = controller;
        }
        public abstract void OnEnter();

        public virtual void OnExit()
        {
            
        }

        protected virtual void RequestStateChange(ViewStates targetState)
        {
            _controller.RequestStateChange(targetState);
        }
    }
}
