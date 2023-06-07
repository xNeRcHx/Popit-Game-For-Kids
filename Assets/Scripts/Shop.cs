using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Transform container;
    public TextMeshProUGUI деньгиТекст;
    public Popit popit;

    public ShopItem[] items = new ShopItem[]
    {
        new ShopItem(Skins.skins[0], 0, true),
        new ShopItem(Skins.skins[1], 5, false),
        new ShopItem(Skins.skins[2], 5, false),
        new ShopItem(Skins.skins[3], 5, false),
        new ShopItem(Skins.skins[4], 5, false),
        new ShopItem(Skins.skins[5], 5, false),
        new ShopItem(Skins.skins[6], 5, false),
        new ShopItem(Skins.skins[7], 5, false),
        new ShopItem(Skins.skins[8], 5, false),
        new ShopItem(Skins.skins[9], 5, false),
        new ShopItem(Skins.skins[10], 5, false),
        new ShopItem(Skins.skins[11], 5, false),
        new ShopItem(Skins.skins[12], 5, false),
        new ShopItem(Skins.skins[13], 5, false),
        new ShopItem(Skins.skins[14], 5, false),
        new ShopItem(Skins.skins[15], 5, false),
        new ShopItem(Skins.skins[16], 5, false),
        new ShopItem(Skins.skins[17], 5, false),
    };
    private Color32 yellowColor = new Color32(255, 165, 0, 255);
    private Color32 greenColor = new Color32(50, 205, 50, 255);
    private Color32 blueColor = new Color32(30, 144, 255, 255);
    public void Открывашка()
    {
        gameObject.SetActive(true);
    }
    public void Закрывашка()
    {
        gameObject.SetActive(false);
    }
    public void OnEnable()
    {
        Упдате();
    }
    public void Упдате()
    {
        деньгиТекст.text = Menu.деньги.ToString();

        for (int i = 0; i < container.childCount; i++)
        {
            container.GetChild(i).GetChild(0).GetComponent<Image>().color = items[i].color;

            if (items[i].isBought == false)
            {
                container.GetChild(i).GetChild(1).GetChild(0).gameObject.SetActive(true);
                container.GetChild(i).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = items[i].cost.ToString();
                container.GetChild(i).GetChild(1).GetComponent<Image>().color = yellowColor;
            }
            else
            {
                container.GetChild(i).GetChild(1).GetChild(0).gameObject.SetActive(false);
                if (i == Popit.activePopitID)
                {
                    container.GetChild(i).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = "EQUIPED";
                    container.GetChild(i).GetChild(1).GetComponent<Image>().color = blueColor;
                }
                else
                {
                    container.GetChild(i).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = "EQUIP";
                    container.GetChild(i).GetChild(1).GetComponent<Image>().color = greenColor;
                }
            }
        }
    }
    public void Купить(int i)
    {
        if (items[i].isBought == false && Menu.деньги >= items[i].cost)
        {
            items[i].isBought = true;
            Menu.деньги -= items[i].cost;
            Menu.естьПопытов++;
        }
        else if (items[i].isBought == true && Popit.activePopitID != i)
        {
            Поставить(i);
        }
        Упдате();
    }
    public void Поставить(int i)
    {
        Popit.activePopitID = i;
        popit.ОбновитьПопыт();
    }
}
