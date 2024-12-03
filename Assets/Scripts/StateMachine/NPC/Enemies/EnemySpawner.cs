using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    public int wolfAmt;
    public int randChance0to100;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < wolfAmt; i++)
        {
            int random = Random.Range(0,100);
            if(randChance0to100 > random)
            {
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
