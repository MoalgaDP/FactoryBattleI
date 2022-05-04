using System.Collections;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{

    private void Start()
    {
        var eventTrigger = gameObject.AddComponent<ObservableEventTrigger>();

        eventTrigger.OnPointerDownAsObservable()
            .Subscribe(pointerEventData =>
            {
                var index = int.Parse(transform.name);
                transform.parent.GetComponent<InventoryViewer>().selectIndex = index;
            });


    }

}
