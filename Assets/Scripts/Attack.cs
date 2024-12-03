using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage = 1;
    public float attack_speed = 1f;
    private bool in_collider = false;

    public AudioSource source;

    Collider2D my_collider;

    void OnTriggerEnter2D(Collider2D collider) {
        in_collider = true;
        my_collider = collider;
        
    }

    void OnTriggerExit2D(Collider2D collider) {
        in_collider = false;
    }

    void Update() {
        if (my_collider == null || !in_collider) return;
        StartCoroutine(IFrames()); 

        Health health = my_collider.transform.root.gameObject.GetComponent<Health>();
        TroopSMBase troopSM = this.GetComponent<TroopSMBase>();
        if (troopSM != null) {
            if (my_collider.transform.parent != null && my_collider.transform.parent.GetComponent<PlayerSM>() != null) {
                return;
            }
        }
        if (health != null) {
            health.Hit(damage);
            if (source == null) return;
            source.Play();
        }
    }

    IEnumerator IFrames() {
        in_collider = false;
        yield return new WaitForSeconds(attack_speed);
        in_collider = true;
    }
}
