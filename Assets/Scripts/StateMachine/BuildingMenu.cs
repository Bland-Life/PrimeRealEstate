using UnityEngine.Tilemaps;
using UnityEngine;

public class BuildingMenu : MonoBehaviour
{
    [SerializeField] PlayerSM playerSM;

    public void setGameObj(BuildOBJ obj) {
        Buildable buildable = new Buildable(obj.obj, obj.cost);
        playerSM.buildObj = buildable;
        
    }

    public void setTile(BuildTILE tile_obj) {
        Tilemap[] maps = FindObjectsOfType<Tilemap>();
        Tilemap tilemap = null;
        foreach(Tilemap map in maps) {
            if (map.name == tile_obj.tileMap) {
                tilemap = map;
                break;
            }
        }
        Buildable buildable = new Buildable(tile_obj.tile, tilemap, tile_obj.cost);
        playerSM.buildObj = buildable;
    }
}
