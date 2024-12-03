using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    SaveBuild buildSave;
    SaveTiles tileSave;

    //When loading a scene with the player, reset time scale for some reason
    public void nextScene(string sceneName) {
        buildSave = FindObjectOfType<SaveBuild>();
        tileSave = FindObjectOfType<SaveTiles>();
        if (buildSave != null) {
            if (sceneName == "Town" || sceneName == "NightTown") {
                buildSave.showObjs();
                tileSave.showObjs();
            }
            else {
                buildSave.hideObjs();
                tileSave.hideObjs();
            }
        }
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

    public void quitGame() {
        Application.Quit();
    }
}
