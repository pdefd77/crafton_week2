using UnityEngine;
using UnityEngine.UI;

public class SetRuleImage : MonoBehaviour
{
    private RectTransform ruleText;

    private void Awake()
    {
        ruleText = transform.GetChild(0).GetComponent<RectTransform>();
    }

    void Start()
    {
        SetRuleTransform();
    }

    public void SetRuleTransform()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(ruleText);
        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(ruleText.rect.width * 1.2f, ruleText.rect.height * 1.2f);
    }
}
