using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBridge : Interactable
{
    [SerializeField] private BridgeSM bridgeSM;
    private JSONLoader town;
    const int BUILD_COST = 150;

    public override void DoUpdate()
    {
        if (town.inventory.wood >= BUILD_COST) {
            town.inventory.wood -= BUILD_COST;
            bridgeSM.broken = false;
        }
    }

    public override void TriggerEnter() {
        town = FindObjectOfType<JSONLoader>();
    }

    public override void TriggerExit() {}
}
