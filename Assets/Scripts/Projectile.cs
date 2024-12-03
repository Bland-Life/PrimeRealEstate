using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float distanceRay;
    public int damage;
    public LayerMask whatIsSolid;

    private float timer = 0;
    public float flyTime = 5f;

    void Start()
    {
        speed = 4f;
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector3.right, distanceRay, whatIsSolid);
        if(hitInfo.collider != null)
        {
            if(hitInfo.collider.GetComponentInParent<EnemySMBase>())
            {
                Debug.Log("Hit!");
                Health health = hitInfo.collider.transform.root.gameObject.GetComponent<Health>();
                if(health != null)
                {
                    health.Hit(damage);
                }
                DestroyProjectile();
            }
        }
        if(timer < flyTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            DestroyProjectile();
        }
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    public void Initialize(int damageSource)
    {
        damage = damageSource;
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
