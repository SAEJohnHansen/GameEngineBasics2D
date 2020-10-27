using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTesting : MonoBehaviour
{
    public float Timer;
    public int Quarters;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("DebugTime", 1f);
        //InvokeRepeating("DebugTime", 0.5f, 1f);
        //StartCoroutine(CountDown());
        StartCoroutine(HierarchyCheck());
    }

    // Update is called once per frame
    void Update()
    {
        //Default float timer in Update
        //if (Timer > 0)
        //{
        //    Timer -= Time.deltaTime;
        //    Debug.Log(Timer); 
        //}
    }


    private void DebugTime()
    {
        Debug.Log(Time.timeSinceLevelLoad);
    }
    /// <summary>
    /// counts down the time for 5 seconds with 1 second intervalls.
    /// </summary>
    /// <returns></returns>
    IEnumerator CountDown()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("Waited 1 second");
        }
    }
    /// <summary>
    /// increases Quarters by one for each 0.25f seconds that pass
    /// </summary>
    /// <returns></returns>
    IEnumerator EndlessTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);
            Quarters++;
        }
    }
    /// <summary>
    /// Calls EnemyCheck each 0.2f seconds
    /// </summary>
    /// <returns></returns>
    IEnumerator HierarchyCheck()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            EnemyCheck();
        }
    }

    /// <summary>
    /// Checks for Colliders close to the Object
    /// </summary>
    private void EnemyCheck()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, 10);

        for (int i = 0; i < enemies.Length; i++)
        {
            Debug.Log(enemies[i].name + " is in range");
        }
    }

}
