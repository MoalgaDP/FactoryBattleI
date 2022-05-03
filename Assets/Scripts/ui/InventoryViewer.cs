using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class InventoryViewer : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;

    InventoryController inventoryController;

    void Start()
    {
        var player = GameObject.FindWithTag("Player");
        inventoryController = player.GetComponent<InventoryController>();

        var inventory = inventoryController.Inventory;
        inventory.ObserveCountChanged(notifyCurrentCount: true).Subscribe(_ =>
        {
            foreach (Transform child in transform)
            {
                Debug.Log(child.gameObject);
                Destroy(child.gameObject);
            }

            foreach (var item in inventory)
            {
                var itemObj = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity, this.transform);
                var itemCtrl = itemObj.GetComponent<InventoryItemController>();
                Debug.Log("gen : " + item.Name);
                itemCtrl.holdItem = item;
            }
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
