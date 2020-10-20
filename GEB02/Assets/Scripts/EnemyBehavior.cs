using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [Header("Enemy Variables")]
    public float Speed;
    [Header("Checks")]
    public LayerMask GroundLayer;
    public float EdgeCheckRadius;
    public Transform EdgeCheckPos;
    public Transform WallCheckPos;
    public enum MovementType { wall, edge, both }
    [Tooltip("Toggle accordingly to let the enemy check for walls, edges or both")]
    public MovementType type;
    private bool directionToggle;


    // Update is called once per frame
    void FixedUpdate()
    {
        EdgeCheck();
        MoveLeftRight();
    }

    /// <summary>
    /// Checks if there is Contact with a wall or no contact with the floor and turns the Character
    /// </summary>
    private void EdgeCheck()
    {
        switch (type)
        {
            case MovementType.wall:
                if (Physics2D.OverlapCircle(WallCheckPos.position, EdgeCheckRadius, GroundLayer))
                {
                    directionToggle = !directionToggle;
                    transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
                }
                break;
            case MovementType.edge:
                if (!Physics2D.OverlapCircle(EdgeCheckPos.position, EdgeCheckRadius, GroundLayer))
                {
                    directionToggle = !directionToggle;
                    transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
                }
                break;
            case MovementType.both:
                if (!Physics2D.OverlapCircle(EdgeCheckPos.position, EdgeCheckRadius, GroundLayer) || Physics2D.OverlapCircle(WallCheckPos.position, EdgeCheckRadius, GroundLayer))
                {
                    directionToggle = !directionToggle;
                    transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
                }
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// Moves the Character Left and Right
    /// </summary>
    private void MoveLeftRight()
    {
        if (directionToggle)
        {
            transform.Translate(transform.right * Speed * Time.fixedDeltaTime);
        }
        else
        {
            transform.Translate(-transform.right * Speed * Time.fixedDeltaTime);
        }

    }

    /// <summary>
    /// Visualises the Wall and Edge check radii
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(EdgeCheckPos.position, EdgeCheckRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(WallCheckPos.position, EdgeCheckRadius);

        //Example of Lerp Usage
        //float one = 1;
        //float two = 2;
        //float result;
        //result = Mathf.Lerp(one, two, 1);
        //Debug.Log(result);
    }
}
