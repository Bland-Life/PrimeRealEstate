using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackRanged : MonoBehaviour
{
    public float offSet;
    public int damage = 2;
    public float attackSpeed = 3f;
    public GameObject projectile;
    public float distance;
    private float attackRange;
    public float timer;
    public ArcherSM archerSM;

    void Start()
    {
        archerSM = GetComponent<ArcherSM>();
        attackRange = archerSM.attackRange;
        timer = attackSpeed;
    }
    void Update()
    {
        if(archerSM.enemy == null)
        {
            
        }
        else if(timer < attackSpeed)
        {
            timer += Time.deltaTime;
        }
        else if(timer >= attackSpeed)
        {
            timer = 0;
            if (archerSM.enemy == null) return;
            distance = Vector2.Distance(archerSM.transform.position, archerSM.enemy.transform.position);
            if(distance <= attackRange)
            {
                Vector2 direction = archerSM.enemy.transform.position - archerSM.transform.position;
                float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion holder = Quaternion.Euler(0f, 0f, rotZ );
                GameObject spawnedProj = Instantiate(projectile, archerSM.transform.position, holder);
                spawnedProj.GetComponent<Projectile>().Initialize(damage);
            }
        }
    }
    
}
