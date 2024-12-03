using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;
using static TileType;

public class GridManager : MonoBehaviour {

    [field:SerializeField] private Vector2 gridSize;
    protected static Vector3Int[] NEIGHBOURS = new Vector3Int[] {
        new Vector3Int(0, 0, 0),
        new Vector3Int(1, 0, 0),
        new Vector3Int(0, 1, 0),
        new Vector3Int(1, 1, 0)
    };

    protected static Dictionary<Tuple<TileType, TileType, TileType, TileType>, Tile> neighbourTupleToTile;

    // Provide references to each tilemap in the inspector
    public Tilemap placeholderTilemap;
    public Tilemap displayTilemap;

    // Provide the dirt and grass placeholder tiles in the inspector
    public Tile grassPlaceholderTile;

    // Provide the 16 tiles in the inspector
    public Tile[] tiles;

    void Start() {
        placeholderTilemap.GetComponent<TilemapRenderer>().renderingLayerMask = 0;
        // This dictionary stores the "rules", each 4-neighbour configuration corresponds to a tile
        // |_1_|_2_|
        // |_3_|_4_|
        neighbourTupleToTile = new() {
            {new (Grass, Grass, Grass, Grass), tiles[0]},
            {new (Grass, Grass, Grass, None), tiles[1]},
            {new (Grass, Grass, None, Grass), tiles[2]},
            {new (Grass, None, Grass, Grass), tiles[3]},
            {new (None, Grass, Grass, Grass), tiles[4]},
            {new (Grass, None, None, None), tiles[5]},
            {new (None, None, Grass, None), tiles[6]},
            {new (None, Grass, None, None), tiles[7]},
            {new (None, None, None, Grass), tiles[8]},
            {new (Grass, None, None, Grass), tiles[9]},
            {new (None, Grass, Grass, None), tiles[10]},
            {new (Grass, None, Grass, None), tiles[11]},
            {new (Grass, Grass, None, None), tiles[14]},
            {new (None, None, Grass, Grass), tiles[13]},
            {new (None, Grass, None, Grass), tiles[12]},

        };
        RefreshDisplayTilemap();
    }

    public void SetCell(Vector3Int coords, Tile tile) {
        placeholderTilemap.SetTile(coords, tile);
        setDisplayTile(coords);
    }

    private TileType getPlaceholderTileTypeAt(Vector3Int coords) {
        if (placeholderTilemap.GetTile(coords) == grassPlaceholderTile)
            return Grass;
        else
            return None;
    }

    protected Tile calculateDisplayTile(Vector3Int coords) {
        // 4 neighbours
        TileType topRight = getPlaceholderTileTypeAt(coords - NEIGHBOURS[0]);
        TileType topLeft = getPlaceholderTileTypeAt(coords - NEIGHBOURS[1]);
        TileType botRight = getPlaceholderTileTypeAt(coords - NEIGHBOURS[2]);
        TileType botLeft = getPlaceholderTileTypeAt(coords - NEIGHBOURS[3]);
        if (topRight == topLeft && topLeft == botRight && botRight == botLeft && botLeft == None) {
            return null;
        }

        Tuple<TileType, TileType, TileType, TileType> neighbourTuple = new(topLeft, topRight, botLeft, botRight);
        return neighbourTupleToTile[neighbourTuple];
    }

    protected void setDisplayTile(Vector3Int pos) {
        for (int i = 0; i < NEIGHBOURS.Length; i++) {
            Vector3Int newPos = pos + NEIGHBOURS[i];
            Tile toPlace= calculateDisplayTile(newPos);
            if (toPlace == null) {
                continue;
            }
            displayTilemap.SetTile(newPos, toPlace);
        }
    }

    // The tiles on the display tilemap will recalculate themselves based on the placeholder tilemap
    public void RefreshDisplayTilemap() {
        for (int i = 0; i < gridSize.x; i++) {
            for (int j = 0; j < gridSize.y; j++) {
                setDisplayTile(new Vector3Int(i, j, 0));
            }
        }
    }
}

public enum TileType {
    None,
    Grass
}