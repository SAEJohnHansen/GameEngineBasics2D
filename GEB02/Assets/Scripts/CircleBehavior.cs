using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBehavior : MonoBehaviour
{
    [SerializeField] private float deathTimer;
    private void OnEnable()
    {
        Invoke("TimeTillInactive", deathTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TimeTillInactive()
    {
        gameObject.SetActive(false);
    }
}
