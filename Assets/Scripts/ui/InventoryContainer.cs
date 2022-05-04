

public class InventoryContainer
{
    public InventoryContainer(Item item, int stack)
    {
        this.Item = item;
        this.Stack = stack;
    }

    public Item Item { get; set; }
    public int Stack { get; set; }
}