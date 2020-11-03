using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Set animator trigger to jump
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Animator>().SetTrigger("Jump");
        }
    }
    /// <summary>
    /// Function called via Animator Event 
    /// </summary>
    public void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
    }
}
