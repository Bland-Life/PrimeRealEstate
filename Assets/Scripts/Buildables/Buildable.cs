using UnityEngine;
using UnityEngine.Tilemaps;

public class Buildable: ScriptableObject
{
    [SerializeField] public GameObject obj;
    [SerializeField] public Tile tile;
    [SerializeField] public Tilemap tileMap;
    public int cost;

    public Buildable(GameObject obj, int cost) {
        this.obj = obj;
        this.cost = cost;
    }

    public Buildable(Tile tile, Tilemap tileMap, int cost) {
        this.tile = tile;
        this.tileMap = tileMap;
        this.cost = cost;
    }

    public virtual void place(Transform parent, Vector2 pos) {
        GameObject newObj = Instantiate(obj, parent);
        newObj.transform.localPosition = pos;
    }

    public virtual void place(Vector2 pos) {
        Vector3Int vector = new Vector3Int((int) pos.x, (int) pos.y);
        tileMap.SetTile(vector, tile);
    }

    public void setGameObj(GameObject obj) {
        this.obj = obj;
    }

    public void setTileAndMap(Tile tile, Tilemap tileMap) {
        this.tile = tile;
        this.tileMap = tileMap;
    }

    public void setCost(int cost) {
        this.cost = cost;
    }
}
