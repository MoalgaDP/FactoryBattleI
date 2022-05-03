using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] ReactiveCollection<Item> inventory;

    public ReactiveCollection<Item> Inventory { get { return inventory; } }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            inventory.Add(new Item());
        }
    }
}
