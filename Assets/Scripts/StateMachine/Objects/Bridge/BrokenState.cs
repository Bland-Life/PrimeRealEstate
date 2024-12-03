using UnityEngine;

public class BrokenState : IState
{
    BridgeSM bridgeSM;

    public BrokenState(BridgeSM stateMachine) {
        bridgeSM = stateMachine;
    }
    public void Exit(){}

    public void Start(){
        bridgeSM.sprite.enabled = false;
        bridgeSM.bridge_collider.enabled = false;
    }

    public void Update()
    {
        //Debug.Log("Check JSON to confirm/change bridge state");
        if (!bridgeSM.broken) {
            bridgeSM.TransitionState(bridgeSM.repairedState);
        }
        // Do Nothing
    }
}