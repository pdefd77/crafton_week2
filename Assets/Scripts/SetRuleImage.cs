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
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(ruleText.rect.width * 1.1f, ruleText.rect.height * 1.1f);
    }
}
