using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System.Linq;
using UnityEngine.UI;
using System;

public class InventoryViewer : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;

    [SerializeField] GameObject focusPrefab;
    GameObject focusObj;

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
                Destroy(child.gameObject);
            }

            foreach (var item in inventory)
            {
                var itemObj = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity, this.transform);
                itemObj.name = item.Name;

                var itemCtrl = itemObj.GetComponent<InventoryItemController>();
                itemCtrl.holdItem = item;
            }

            focusObj = Instantiate(focusPrefab, Vector3.zero, Quaternion.identity);
            focusObj.SetActive(false);
        });

        inventoryController.ObserveEveryValueChanged(ctrl => ctrl.HoldingItem).Subscribe(item =>
                {
                    if (item == null)
                    {
                        focusObj.SetActive(false);
                        return;
                    };

                    var itemIndex = int.Parse(item.Name);
                    var itemObj = transform.GetChild(itemIndex);

                    focusObj.SetActive(true);
                    focusObj.transform.SetParent(itemObj);
                    (focusObj.transform as RectTransform).anchoredPosition = Vector3.zero;
                });
    }

}
