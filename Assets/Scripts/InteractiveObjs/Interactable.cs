using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private bool in_range = false;
    protected Collider2D myCollider;

    private void OnTriggerEnter2D(Collider2D collider) {
        in_range = true;
        myCollider = collider;
        TriggerEnter();
    }

    private void OnTriggerExit2D(Collider2D collider) {
        in_range = false;
        myCollider = null;
        TriggerExit();
    }

    void Update() {
        if (in_range && Input.GetKeyDown(KeyCode.E)) {
            DoUpdate();
        }
    }

    public abstract void TriggerEnter();

    public abstract void TriggerExit();

    public abstract void DoUpdate();
}
