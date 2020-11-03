using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    private float manaReg;
    private float healthReg;
    private float ammoReg;
    public ItemType[] item;

    private void Start()//Takes all values from the scriptable object
    {
        ItemType temp = item[Random.Range(0,item.Length)];
        GetComponent<SpriteRenderer>().sprite = temp.sprite;
        manaReg = temp.mana;
        healthReg = temp.heal;
        ammoReg = temp.ammo;
    }

}
