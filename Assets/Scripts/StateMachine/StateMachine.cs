using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected IState currentState {get; set;}

    void Start() {
        Init();
        currentState.Start();
    }

    void Update() {
        currentState?.Update();
    }

    public void TransitionState(IState nextState) {
        currentState?.Exit();
        currentState = nextState;
        currentState.Start();
    }

    protected virtual void Init() {
        
    }
}
