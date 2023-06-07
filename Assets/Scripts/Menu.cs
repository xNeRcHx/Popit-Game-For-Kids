using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // ласс дл€ обновлени€ текста

    static public int счетѕопа = 0;
    static public int деньги = 0;
    static public int перевернул = 0;
    static public int естьѕопытов = 1;
    public TextMeshProUGUI счет“екст;
    public TextMeshProUGUI деньги“екст;
    public TextMeshProUGUI инфа“екст;

    public void Update()
    {
        счет“екст.text = счетѕопа.ToString();
        деньги“екст.text = деньги.ToString();
        инфа“екст.text = $"TIMES FLIPPED: \t{перевернул}\nPOPITS OWNED: \t{естьѕопытов}";
    }
    
}
