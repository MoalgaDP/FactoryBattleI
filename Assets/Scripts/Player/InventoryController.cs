using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField] List<InventoryContainer> inventory;

    public ReactiveCollection<InventoryContainer> Inventory { get { return new ReactiveCollection<InventoryContainer>(inventory); } }

    public InventoryContainer HoldingContainer { get; set; }

    public void changeHoldContainer(int index)
    {
        HoldingContainer = inventory[index];
    }

    int counter = 1;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            // アイテムリストを順番に追加する
            var items = Enum.GetValues(typeof(ItemName)).Cast<ItemName>().ToList();
            inventory.Add(new InventoryContainer(items[counter % items.Count], counter));
            counter++;
        }
    }
}
