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

    public int selectIndex { get; set; } = -1;

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

            foreach (var (container, index) in inventory.Select((v, i) => (v, i)))
            {
                var itemObj = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity, this.transform);
                itemObj.name = index.ToString();
            }

            focusObj = Instantiate(focusPrefab, Vector3.zero, Quaternion.identity);
            focusObj.SetActive(false);
        });

        this.ObserveEveryValueChanged(viewer => viewer.selectIndex).Subscribe(index =>
        {
            if (index < 0)
            {
                focusObj.SetActive(false);
                return;
            }
            inventoryController.HoldingContainer = inventory[index];
            var itemObj = transform.GetChild(index);


            focusObj.SetActive(true);
            focusObj.transform.SetParent(itemObj);
            (focusObj.transform as RectTransform).anchoredPosition = Vector3.zero;
        });

    }

}
