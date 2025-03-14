using TMPro;
using UnityEngine;

public class SetCereal : MonoBehaviour
{
    // 시리얼 이미지를 속성에 맞게 변경
    public void SetCerealApperance(CerealClass cerealClass)
    {
        transform.GetChild(0).GetComponent<TextMeshPro>().text = (3 + (int)cerealClass.shape).ToString();
    }
}
