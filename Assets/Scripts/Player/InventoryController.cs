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

    int counter;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            var item = gameObject.AddComponent<Item>();
            item.Instantiate(counter.ToString());

            inventory.Add(new InventoryContainer(item, 10));
            counter++;
        }
    }
}
