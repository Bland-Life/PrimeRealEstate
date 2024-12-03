using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public int wood = 0;

    public int iron = 0;
    public int obsidian = 0;
    private static Inventory _instance = null;

    public static Inventory Instance {
        get {
            if(_instance == null) {
                _instance = new Inventory(0, 0 , 0);
            }
            return _instance;
        }        
    }

    private Inventory(int wood, int iron, int obsidian) {
        this.wood = wood;
        this.iron = iron;
        this.obsidian = obsidian;
    }
}
