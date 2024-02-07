public class Inventory
{
    private static Inventory inventory;

    private Inventory() { }

    public static Inventory GetInstance()
    {
        if (inventory == null)
        {
            inventory = new Inventory();
        }
        return inventory;
    }

    public int gold = 0;
}

public class Player
{
    public void SpendGold()
    {
        Inventory.GetInstance().gold -= 100;
    }
}

public class Monster
{
    public void Die()
    {
        Inventory.GetInstance().gold += 100;
    }
}

public class Items
{
    public void GetGold()
    {
        Inventory.GetInstance().gold += 200;
    }
}
