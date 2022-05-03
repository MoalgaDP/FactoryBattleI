using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class InventoryViewer : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindWithTag("Player");
        var inventory = player.GetComponent<InventoryController>().Inventory;

        inventory.ObserveCountChanged(notifyCurrentCount: true).Subscribe(_ =>
        {
            foreach (Transform child in transform)
            {
                Debug.Log(child.gameObject);
                Destroy(child.gameObject);
            }

            foreach (var item in inventory)
            {
                Instantiate(itemPrefab, Vector3.zero, Quaternion.identity, this.transform);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
