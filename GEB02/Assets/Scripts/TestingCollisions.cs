using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingCollisions : MonoBehaviour
{
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log(collision.name + " has entered my personal space");
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log(collision.gameObject.name + " has collided with my personal space");
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log(collision.name + " has left my personal space");
    //}
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.name + " is in my personal space");
        //if (Input.GetKeyDown(KeyCode.Q)) Input in der FixedUpdate bzw. TriggerStay Funktion ist eine Sünde.
        //{
        //    transform.position = transform.position + Vector3.up * 2;
        //}
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name + " is on my personal space");
    }
}
