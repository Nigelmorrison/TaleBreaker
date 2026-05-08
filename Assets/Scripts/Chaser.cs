using UnityEngine;
using System.Collections;



public class Chaser : MonoBehaviour
{

    public float speed = 20.0f;
    public float minDist = 1f;
    public Transform target;
    public Rigidbody rb;
    public float Within_range;

    public float lightKnockback = 0.2f;
    public float heavyKnockback = 0.5f;

    float knockBackTime;

    void Start()
    {
        target = GameObject.FindAnyObjectByType<Movement>().transform;
        //if (target == null)
        //{

        //    if (GameObject.FindWithTag("Player") != null)
        //    {
        //        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //    }
        //}
    }


    void Update()
    {
        if (target == null)
            return;


        //transform.LookAt(target);
        Vector3 vector = target.position - transform.position;
        if (knockBackTime > 0)
        {
            knockBackTime -= Time.deltaTime;
            rb.linearVelocity = -vector.normalized * speed;
        }
        else
        {
            rb.linearVelocity = vector.normalized * speed;            
        }
    }

    public void KnockBack(int damage)
    {
        knockBackTime = damage > 15? heavyKnockback : lightKnockback;
    }


    public void SetTarget(Transform newTarget)
    {
        target = newTarget;


        float dist = Vector3.Distance(target.position, transform.position);

        if (dist <= Within_range)
        {

            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }



    }

}