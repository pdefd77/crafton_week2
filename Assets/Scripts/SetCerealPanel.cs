using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetCerealPanel : MonoBehaviour
{
    private Image[] Images;
    private int[] Counts;

    private void Awake()
    {
        Images = gameObject.GetComponentsInChildren<Image>(); // 0번은 자식이 아니라 본인이라는 것을 기억하기
        Counts = new int[Images.Length];
    }

    private void Start()
    {
        for(int i = 1; i < Images.Length; i++)
        {
            if (Counts[i] > 0) Images[i].gameObject.SetActive(true);
            else Images[i].gameObject.SetActive(false);
        }

        Images[0].gameObject.SetActive(false);
    }

    public void ChangeCount(CerealClass cerealClass, int count)
    {
        int idx = 1 + (int)cerealClass.shape + (int)cerealClass.color * 6;
        TextMeshProUGUI idxText = Images[idx].transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        Counts[idx] += count;
        idxText.text = Counts[idx].ToString();

        if (Counts[idx] > 0) Images[idx].gameObject.SetActive(true);
        else Images[idx].gameObject.SetActive(false);
    }
}
