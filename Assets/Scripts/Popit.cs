using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Popit : MonoBehaviour
{
    Cell[,] пукалки = new Cell[6, 6];
    public GameObject popit;
    public Transform cellsContainer;
    static public int activePopitID = 0;

    public void Start()
    {
        ќбновитьѕопыт();
    }
    public void ќбновитьѕопыт()
    {
        popit.GetComponent<Image>().color = Skins.skins[activePopitID];
        for (int i = 0; i < cellsContainer.childCount; i++)
        {
            cellsContainer.GetChild(i).GetChild(0).GetComponent<Image>().color = Skins.skins[activePopitID];
            cellsContainer.GetChild(i).GetChild(1).GetComponent<Image>().color = Skins.skins[activePopitID];
        }

        int count = 0;
        for (int i = 0; i < пукалки.GetLength(0); i++)
        {
            for (int j = 0; j < пукалки.GetLength(1); j++)
            {
                if (transform.GetChild(0).GetChild(6 * i + j).GetComponent<Cell>().нажатаЋи == false)
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

    public void ѕеревернуть()
    {
        for (int i = 0; i < пукалки.GetLength(0); i++)
        {
            //записали в залупу значени€
            bool[] залупа = new bool[6];
            for (int j = 0; j < пукалки.GetLength(1); j++)
            {
                залупа[j] = transform.GetChild(0).GetChild(6 * i + j).GetComponent<Cell>().нажатаЋи;
            }

            transform.GetChild(0).GetChild(6 * i + 0).GetComponent<Cell>().нажатаЋи = !залупа[5];
            transform.GetChild(0).GetChild(6 * i + 1).GetComponent<Cell>().нажатаЋи = !залупа[4];
            transform.GetChild(0).GetChild(6 * i + 2).GetComponent<Cell>().нажатаЋи = !залупа[3];
            transform.GetChild(0).GetChild(6 * i + 3).GetComponent<Cell>().нажатаЋи = !залупа[2];
            transform.GetChild(0).GetChild(6 * i + 4).GetComponent<Cell>().нажатаЋи = !залупа[1];
            transform.GetChild(0).GetChild(6 * i + 5).GetComponent<Cell>().нажатаЋи = !залупа[0];
        }
        GetComponent<Animation>().Play();
        Invoke("ќбновитьѕопыт", 0.666f);
        Menu.перевернул++;
    }
    public void ѕук¬се()
    {
        StartCoroutine(ѕук¬сего());
    }
    IEnumerator ѕук¬сего()
    {
        for (int i = 0; i < пукалки.GetLength(0); i++)
        {
            for (int j = 0; j < пукалки.GetLength(1); j++)
            {
                transform.GetChild(0).GetChild(6 * i + j).GetComponent<Cell>().ѕукнуть();
                yield return new WaitForSeconds(0.08f);
            }
        }
    }
}

