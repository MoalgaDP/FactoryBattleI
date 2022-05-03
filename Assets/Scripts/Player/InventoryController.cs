using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField] ReactiveCollection<Item> inventory;

    public ReactiveCollection<Item> Inventory { get { return inventory; } }

    public Item HoldingItem { get; set; }


    int counter;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            var item = gameObject.AddComponent<Item>();
            item.Instantiate(counter.ToString());

            inventory.Add(item);
            counter++;
        }
    }
}
