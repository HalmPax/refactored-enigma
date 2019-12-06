using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{



public float speed;

public bool vertical;
public float changeTime = 3.0f;

    bool broken = true;


Rigidbody2D rigidbody2d;

float timer;
int direction = 1;
Animator animator;

    // Start is called before the first frame update
    void Start()
    {



    rigidbody2d = GetComponent<Rigidbody2D>();
    timer = changeTime;
    animator = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (!broken)
        {
            animator = GetComponent<Animator>();
            animator.enabled = false;
            return;
        }

    timer -= Time.deltaTime;

    if (timer < 0)
    {
     direction = -direction;
     timer = changeTime;
	}
      
      Vector2 position = rigidbody2d.position;
      
      position.x = position.x;
      

      if (vertical)
      {
      position.y = position.y + speed * Time.deltaTime * direction;
      animator.SetFloat("Move X", 0);
      animator.SetFloat("Move Y", direction);
      }

      else
      {
       position.x = position.x + Time.deltaTime * speed * direction;
       animator.SetFloat("Move X", direction);
       animator.SetFloat("Move Y", 0);
	  }

      rigidbody2d.MovePosition(position);




    }

void OnCollisionEnter2D(Collision2D other)
{
    RubyController player = other.gameObject.GetComponent<RubyController>();
    if (player != null)
    {
     player.ChangeHealth(-1);
	}
}

    public void Fix()
    {
        broken = false;
        rigidbody2d.simulated = false;
    }


}
