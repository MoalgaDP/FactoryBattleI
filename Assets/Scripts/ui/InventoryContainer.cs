
using UnityEngine;

[System.Serializable]
public class InventoryContainer
{
    [SerializeField] Item item;
    [SerializeField] int stack;

    public InventoryContainer(Item item, int stack)
    {
        this.Item = item;
        this.Stack = stack;
    }

    public Item Item { get => item; set { item = value; } }
    public int Stack { get => stack; set { stack = value; } }
}