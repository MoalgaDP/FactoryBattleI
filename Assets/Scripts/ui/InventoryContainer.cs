
using UnityEngine;

[System.Serializable]
public class InventoryContainer
{
    [SerializeField] ItemName item;
    [SerializeField] int stack;

    public InventoryContainer(ItemName item, int stack)
    {
        this.Item = item;
        this.Stack = stack;
    }

    public ItemName Item { get => item; set { item = value; } }
    public int Stack { get => stack; set { stack = value; } }
}