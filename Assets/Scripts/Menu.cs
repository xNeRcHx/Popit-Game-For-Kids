using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    //����� ��� ���������� ������

    static public int �������� = 0;
    static public int ������ = 0;
    static public int ���������� = 0;
    static public int ����������� = 1;
    public TextMeshProUGUI ���������;
    public TextMeshProUGUI �����������;
    public TextMeshProUGUI ���������;

    public void Update()
    {
        ���������.text = ��������.ToString();
        �����������.text = ������.ToString();
        ���������.text = $"TIMES FLIPPED: \t{����������}\nPOPITS OWNED: \t{�����������}";
    }
    
}
