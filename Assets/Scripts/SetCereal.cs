using TMPro;
using UnityEngine;

public class SetCereal : MonoBehaviour
{
    // �ø��� �̹����� �Ӽ��� �°� ����
    public void SetCerealApperance(CerealClass cerealClass)
    {
        transform.GetChild(0).GetComponent<TextMeshPro>().text = (3 + (int)cerealClass.shape).ToString();
    }
}
