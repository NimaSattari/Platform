using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform T1, T2;
    [SerializeField] private float Speed = 1.0f;
    private bool Switch = false;

    void FixedUpdate()
    {
        if(Switch == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, T2.position, Speed * Time.deltaTime);
        }
        else if(Switch == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, T1.position, Speed * Time.deltaTime);
        }
        if (transform.position == T2.position)
        {
            Switch = true;
        }
        else if (transform.position == T1.position)
        {
            Switch = false;
        }
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
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
