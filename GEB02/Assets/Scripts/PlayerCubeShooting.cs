using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubeShooting : MonoBehaviour
{

    [SerializeField] private GameObject CubePrefab;
    [SerializeField] private float ShootPower;
    private SpriteRenderer spRend;
    public int MaxAmountOfCubes;

    private Queue<GameObject> CompanionQueue = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        spRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootCube();
        }
    }
    /// <summary>
    /// Checks in what Position to Spawn the Cube and in what direction to launch it
    /// Checks the CompanienQueue for the maximum amount of cubes and destroys last object.
    /// </summary>
    private void ShootCube()
    {
        Vector2 dir;
        Vector2 spawnPos;

        if (spRend.flipX)
        {
            dir = new Vector2(-1, 0.33f);
            spawnPos = transform.position + Vector3.left;
        }
        else
        {
            dir = new Vector2(1, 0.33f);
            spawnPos = transform.position + Vector3.right;
        }

        GameObject myCube = Instantiate(CubePrefab, spawnPos, Quaternion.identity);
        myCube.GetComponent<Rigidbody2D>().AddForce(dir * ShootPower, ForceMode2D.Impulse);

        CompanionQueue.Enqueue(myCube);
        if (CompanionQueue.Count > MaxAmountOfCubes)
        {
            Destroy(CompanionQueue.Dequeue());
            //GameObject temp = CompanionQueue.Dequeue();
            //Destroy(temp);
        }
    }
}
