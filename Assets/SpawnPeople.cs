using UnityEngine;

public class SpawnPeople : MonoBehaviour
{
    public GameObject spawnpoint;
    public GameObject knight;
    public GameObject archer;

    // Start is called before the first frame update
    void Start()
    {
        GameObject one = Instantiate(knight, this.transform);
        GameObject two = Instantiate(archer, this.transform);
        one.transform.localPosition = spawnpoint.transform.localPosition;
        two.transform.localPosition = spawnpoint.transform.localPosition;
    }
}
