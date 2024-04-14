using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Damage : MonoBehaviour
{
    [Header ("Damage Parameters")]
    [SerializeField] private int attackDamage;
    [SerializeField] private float attackRange;
    public Vector3 attackOffset;
    public LayerMask attackMask;

    //[SerializeField] private int enragedAttackDamage;

    // Start is called before the first frame update
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if(colInfo != null)
        {
            colInfo.GetComponent<Health_Death>().TakeDamage(attackDamage);
        }
    }
}
