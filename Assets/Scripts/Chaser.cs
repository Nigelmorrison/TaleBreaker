using UnityEngine;
using System.Collections;



public class Chaser : MonoBehaviour
{

    public float speed = 20.0f;
    public float minDist = 1f;
    public Transform target;
    public float Within_range;




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
        float distance = vector.magnitude;
        if (distance < minDist)
            transform.position += vector.normalized * speed * Time.deltaTime;
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