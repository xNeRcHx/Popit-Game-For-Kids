using UnityEngine;

public class ShopItem
{
    public ShopItem(Color32 color, int cost, bool isBought)
    {
        this.color = color;
        this.cost = cost;
        this.isBought = isBought;
    }
    public Color32 color;
    public int cost;
    public bool isBought;
}
