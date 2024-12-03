using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesUI : MonoBehaviour
{
    public TextMeshProUGUI wood;
    JSONLoader inv;
    // Start is called before the first frame update
    void Start()
    {
        inv = FindObjectOfType<JSONLoader>();
        inv.LoadData();
        wood.text = "Wood: " + inv.inventory.wood;
    }

    public void removeWood(int amount) {
        inv.inventory.wood -= amount;
        wood.text = "Wood: " + inv.inventory.wood;
        inv.SaveData();
    }

    public void addWood(int amount) {
        inv.inventory.wood += amount;
        wood.text = "Wood: " + inv.inventory.wood;
        inv.SaveData();
    }
}
