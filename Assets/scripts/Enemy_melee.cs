
using UnityEngine;

public class Enemy_melee : MonoBehaviour
{
    [SerializeField] private float attackcooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField]private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float coolDownTime = Mathf.Infinity;

    private Animator anim;
    private playerHealthController playerHealth;
    private Enemy_Patrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<Enemy_Patrol>();
    }

    private void Update()
    {
        coolDownTime += Time.deltaTime;

        if (PlayerInSight())
        {
            if (coolDownTime >= attackcooldown)
            {
                //attack
                coolDownTime = 0;
                anim.SetTrigger("isAttacking");
            }
        }

        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if(hit.collider != null )
        {
            playerHealth = hit.transform.GetComponent<playerHealthController>();
        }

        return hit.collider != null;
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void damagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.dealDamage();

            /*playerHealthController.instance.currentHealth = playerHealthController.instance.currentHealth - damage;*/




        }

    }
   

}
