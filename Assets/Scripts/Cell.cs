using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool �������� = false;

    public void �������()
    {
        if (�������� == false)
        {
            �������� = true;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            GetComponent<AudioSource>().Play();
            Menu.��������++;
            Menu.������++;
        }
    }
}
