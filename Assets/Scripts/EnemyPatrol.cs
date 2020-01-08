using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public bool movingRight = true;
    public Transform groundDetection;
    public float distance = 2f;
    public bool stop = false;

    //To detect player is nearby
    public Transform detectPlayerPos;
    public LayerMask whatIsPlayer;
    public float detectionRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] player = Physics2D.OverlapCircleAll(detectPlayerPos.position, detectionRange, whatIsPlayer);

        // if(player.Length !=0 && player[0].GetComponent<PlayerAttack>()!=null)
        //     Debug.Log("Detected!" + player.Length);
    
        // Check if player nearby
        if(player.Length !=0 && player[0]!=null && player[0].GetComponent<PlayerAttack>()!=null){
            transform.Translate(Vector2.right * 0 * Time.deltaTime); // stop
            return;
        }
            

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }       
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(detectPlayerPos.position, detectionRange);
    }
}
