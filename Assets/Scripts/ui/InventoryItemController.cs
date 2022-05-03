using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    public Item holdItem { get; set; }

    private void Start()
    {
        var inventoryController = GameObject.FindWithTag("Player").GetComponent<InventoryController>();
        var eventTrigger = gameObject.AddComponent<ObservableEventTrigger>();

        eventTrigger.OnPointerDownAsObservable()
            .Subscribe(pointerEventData =>
            {
                inventoryController.HoldingItem = holdItem;
            });
    }

}
