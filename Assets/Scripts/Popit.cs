using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Popit : MonoBehaviour
{
    Cell[,] ������� = new Cell[6, 6];
    public GameObject popit;
    public Transform cellsContainer;
    static public int activePopitID = 0;

    public void Start()
    {
        �������������();
    }
    public void �������������()
    {
        popit.GetComponent<Image>().color = Skins.skins[activePopitID];
        for (int i = 0; i < cellsContainer.childCount; i++)
        {
            cellsContainer.GetChild(i).GetChild(0).GetComponent<Image>().color = Skins.skins[activePopitID];
            cellsContainer.GetChild(i).GetChild(1).GetComponent<Image>().color = Skins.skins[activePopitID];
        }

        int count = 0;
        for (int i = 0; i < �������.GetLength(0); i++)
        {
            for (int j = 0; j < �������.GetLength(1); j++)
            {
                if (transform.GetChild(0).GetChild(6 * i + j).GetComponent<Cell>().�������� == false)
                {
                    transform.GetChild(0).GetChild(count).GetChild(0).gameObject.SetActive(true);
                    transform.GetChild(0).GetChild(count).GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(0).GetChild(count).GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(0).GetChild(count).GetChild(1).gameObject.SetActive(true);
                }
                count++;
            }
        }
    }

    public void �����������()
    {
        for (int i = 0; i < �������.GetLength(0); i++)
        {
            //�������� � ������ ��������
            bool[] ������ = new bool[6];
            for (int j = 0; j < �������.GetLength(1); j++)
            {
                ������[j] = transform.GetChild(0).GetChild(6 * i + j).GetComponent<Cell>().��������;
            }

            transform.GetChild(0).GetChild(6 * i + 0).GetComponent<Cell>().�������� = !������[5];
            transform.GetChild(0).GetChild(6 * i + 1).GetComponent<Cell>().�������� = !������[4];
            transform.GetChild(0).GetChild(6 * i + 2).GetComponent<Cell>().�������� = !������[3];
            transform.GetChild(0).GetChild(6 * i + 3).GetComponent<Cell>().�������� = !������[2];
            transform.GetChild(0).GetChild(6 * i + 4).GetComponent<Cell>().�������� = !������[1];
            transform.GetChild(0).GetChild(6 * i + 5).GetComponent<Cell>().�������� = !������[0];
        }
        GetComponent<Animation>().Play();
        Invoke("�������������", 0.666f);
        Menu.����������++;
    }
    public void ������()
    {
        StartCoroutine(��������());
    }
    IEnumerator ��������()
    {
        for (int i = 0; i < �������.GetLength(0); i++)
        {
            for (int j = 0; j < �������.GetLength(1); j++)
            {
                transform.GetChild(0).GetChild(6 * i + j).GetComponent<Cell>().�������();
                yield return new WaitForSeconds(0.08f);
            }
        }
    }
}

