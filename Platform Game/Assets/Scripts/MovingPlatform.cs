using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform pointA, pointB;
    private Transform target;

    private float speed = 1.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position == pointA.position)
        {
            target = pointB;
        }
        else if(transform.position == pointB.position)
        {
            target = pointA;
        }
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = null;
        }

    }
}
