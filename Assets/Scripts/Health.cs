using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private GameObject obj;
    [SerializeField] private int health = 1;

    void Update() {
        if (health <= 0) {
            Destroy(obj);
        }
    }

    public void Hit(int damage) {
        health -= damage;
    }

    public void Heal(int points) {
        health += points;
    }

}
