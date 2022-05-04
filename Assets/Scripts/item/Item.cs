using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] string itemName;

    public string Name { get { return itemName; } }

    [Obsolete("デバッグ用。プレハブで作って名前を付けること")]
    public void Instantiate(string name)
    {
        this.itemName = name;
    }
}
