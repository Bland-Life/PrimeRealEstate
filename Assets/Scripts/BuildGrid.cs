using UnityEngine;

public class BuildGrid : MonoBehaviour
{
    [field:SerializeField] public GameObject gridObj{get; private set;}

    public void hideGrid() {
        this.gameObject.SetActive(false);
    }

    public void showGrid() {
        this.gameObject.SetActive(true);
    }
}
