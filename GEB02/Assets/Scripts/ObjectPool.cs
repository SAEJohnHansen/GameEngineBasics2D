using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject Circle;
    public int PoolSize;

    public List<GameObject> pool = new List<GameObject>();
    private GameObject poolParent;
    // Start is called before the first frame update
    void Start()
    {
        SetupPool();
        InvokeRepeating("ReleaseBall", 0, 0.05f);
    }

    /// <summary>
    /// Instantiates *poolsize* amount of Objects for the pool, sets them inactive and adds them to the list.
    /// </summary>
    private void SetupPool()
    {
        poolParent = new GameObject("PoolParent");
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject temp = Instantiate(Circle, transform.position, Quaternion.identity);
            temp.SetActive(false);
            temp.transform.parent = poolParent.transform;
            pool.Add(temp);
        }
    }

    /// <summary>
    /// Gets the first Inactive item from the pool and sets it active. If none are available instantiates a new one and adds it to the list.
    /// </summary>
    private void ReleaseBall()
    {
        foreach (var item in pool)
        {
            if (!item.activeSelf)
            {
                item.SetActive(true);
                item.transform.position = transform.position;
                item.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                item.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                return;
            }
        }
        GameObject temp = Instantiate(Circle, transform.position, Quaternion.identity);
        temp.transform.parent = poolParent.transform;
        pool.Add(temp);
    }
}
