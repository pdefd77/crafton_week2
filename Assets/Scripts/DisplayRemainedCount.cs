using TMPro;
using UnityEngine;

public class DisplayRemainedCount : MonoBehaviour
{
    private int remainedCount;
    private TextMeshProUGUI remainedCountText;

    public void Awake()
    {
        remainedCountText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void Init(int count)
    {
        remainedCount = count;
        SetRemainedCount();
    }

    public int GetRemainedCount()
    {
        return remainedCount;
    }

    public void PlusRemainedCount(int count)
    {
        remainedCount += count;
    }

    public void MinusRemainedCount()
    {
        if (remainedCount == 0) return;

        remainedCount--;
        SetRemainedCount();
    }

    private void SetRemainedCount()
    {
        remainedCountText.text = remainedCount.ToString();
    }
}
