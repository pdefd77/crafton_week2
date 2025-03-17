using UnityEngine;

public class ImplementNormal : MonoBehaviour
{
    // a -> b 형태의 기본 규칙 구문
    private SetCerealClass[] rules;
    private ControlStage controlStage;

    private void Awake()
    {
        ReadRules();
        controlStage = GameObject.Find("StageControl").GetComponent<ControlStage>();
    }

    public void ImplementRule(int repeat)
    {
        ReadRules();

        if (rules.Length < 2) return;

        controlStage.ImplementNormalRule(ref rules, repeat);
    }

    private void ReadRules()
    {
        rules = transform.GetComponentsInChildren<SetCerealClass>();
    }
}
