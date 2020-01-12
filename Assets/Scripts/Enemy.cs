using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage) {

        health -= damage;
        Debug.Log("damage TAKEN");
        if(health==0)
        {
            Destroy(gameObject);
        }
    }
    
}

