using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairedState : IState
{
    BridgeSM bridgeSM;
    
    public RepairedState(BridgeSM stateMachine) {
        bridgeSM = stateMachine;
    }

    public void Exit(){}

    public void Start()
    {
       // Bridge fixed!
       bridgeSM.sprite.enabled = true;
       bridgeSM.bridge_collider.enabled = true;
       bridgeSM.build_sign.SetActive(false);
    }

    public void Update(){}
}
