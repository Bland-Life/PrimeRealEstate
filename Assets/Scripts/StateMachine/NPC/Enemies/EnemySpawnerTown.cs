using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerTown : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    public int nightNum;
    int i =0;
    int wolfAmt;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Here");
        SaveBuild saveB = FindObjectOfType<SaveBuild>();
        nightNum = saveB.nightCount;
        wolfAmt = nightNum * 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(i < wolfAmt)
        {
            StartCoroutine(waiter());
            i++;
        }
    }

    IEnumerator waiter()
    {
        int random = Random.Range(1,3);
        yield return new WaitForSeconds(random);
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.position = transform.position;
        EnemySMBase enemySM = enemy.GetComponent<EnemySMBase>();
        enemySM.target = FindObjectOfType<PlayerSM>().gameObject;
        enemySM.startChaseDistance = 1000;
    }
}
