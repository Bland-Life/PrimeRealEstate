using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTiles : MonoBehaviour
{
    GameObject[] childrenObjs;

    void Awake() {
        SaveTiles[] objs = FindObjectsOfType<SaveTiles>();
        if (objs.Length > 1) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void hideObjs() {
        int children = this.transform.childCount;
        childrenObjs = new GameObject[children];
        for (int i = 0; i < children; i++) {
            childrenObjs[i] = this.transform.GetChild(i).gameObject;
            childrenObjs[i].gameObject.SetActive(false);
        }
    }

    public void showObjs() {
        if (childrenObjs == null) return;
        foreach(GameObject child in childrenObjs) {
            child.gameObject.SetActive(true);
        }
    }
}
