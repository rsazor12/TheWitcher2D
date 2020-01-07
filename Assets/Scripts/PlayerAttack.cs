using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    private Animator myAnimator;
    

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwAttack <= 0){
            timeBtwAttack = startTimeBtwAttack;

            if(Input.GetKey(KeyCode.C)){
                //Run animation after attack
                myAnimator.SetTrigger("Attack");

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    if(enemiesToDamage[i]!=null && enemiesToDamage[i].GetComponent<Enemy>()!=null)
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }

                 
            }
        } else {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(attackPos.position, attackRange);
    }
}
