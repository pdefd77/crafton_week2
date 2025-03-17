using UnityEngine;

public class ImplementIf : MonoBehaviour
{
    // if a then b -> c ������ ���ǹ� ����
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

        if (rules.Length < 3) return;

        controlStage.ImplementIfRule(ref rules, repeat);
    }

    private void ReadRules()
    {
        rules = transform.GetComponentsInChildren<SetCerealClass>();
    }
}
