using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSM : StateMachine
{
    public bool broken = true;
    [field: SerializeField] public SpriteRenderer sprite{get; private set;}
    [field: SerializeField] public BoxCollider2D bridge_collider{get; private set;}
    public GameObject build_sign;
    public BrokenState brokenState{get; private set;}
    public RepairedState repairedState{get; private set;}
    public BridgeSM() {
        brokenState = new BrokenState(this);
        repairedState = new RepairedState(this);
        currentState = brokenState;
    }
}
