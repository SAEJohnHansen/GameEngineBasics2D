using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float MoveSpeed;
    public Transform Player;

    private void FixedUpdate()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        transform.up = (Player.transform.position - transform.position).normalized;
        transform.Translate(Vector3.up * MoveSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
       // Gizmos.DrawLine(transform.position, Player.transform.position);
    }


}
