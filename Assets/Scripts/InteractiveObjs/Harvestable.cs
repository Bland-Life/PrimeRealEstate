using UnityEngine;
using System.Collections;

public class Harvestable : Interactable
{
    public AudioSource source;
    private JSONLoader town;
    private ResourcesUI resources;

    public override void DoUpdate()
    {
        if (myCollider.gameObject == null) {
            return;
        }

        resources.addWood(10);
        source.Play();
    }

    public override void TriggerEnter()
    {
        town = FindObjectOfType<JSONLoader>();
        resources = FindObjectOfType<ResourcesUI>();
    }

    public override void TriggerExit() {}
}
