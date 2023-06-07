using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool нажатаЋи = false;

    public void ѕукнуть()
    {
        if (нажатаЋи == false)
        {
            нажатаЋи = true;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            GetComponent<AudioSource>().Play();
            Menu.счетѕопа++;
            Menu.деньги++;
        }
    }
}
