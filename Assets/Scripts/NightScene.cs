using UnityEngine;

public class NightScene : MonoBehaviour
{
    public SceneController controller;
    EnemySMBase[] enemies;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        enemies = FindObjectsOfType<EnemySMBase>();
        if (enemies.Length == 0) {
            controller.nextScene("Town");
        }
    }
}
