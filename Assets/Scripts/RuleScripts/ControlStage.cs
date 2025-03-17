using System;
using UnityEngine;

[Serializable]
public struct InitialSet
{
    public CerealShape shape;
    public CerealColor color;
    public int count;
}

public class ControlStage : MonoBehaviour
{
    [SerializeField] private ControlCerealBowl controlCerealBowl;
    [SerializeField] private DisplayRemainedCount displayRemainedCount;
    [SerializeField] private int remainedCount;
    [SerializeField] private InitialSet[] initialSets;

    public void Start()
    {
        displayRemainedCount.Init(remainedCount);

        foreach(InitialSet elem in initialSets)
        {
            controlCerealBowl.ChangeCereal((new CerealClass(elem.shape, elem.color), elem.count));
        }
    }

    public void ImplementNormalRule(ref SetCerealClass[] rules, int repeat)
    {
        if (displayRemainedCount.GetRemainedCount() == 0) return;

        bool isWork = false;

        for(int i = 0; i < repeat; i++)
        {
            if (controlCerealBowl.ChangeCereal(rules[0].GetRemoveInfo()))
            {
                isWork = true;
                controlCerealBowl.ChangeCereal(rules[1].GetAddInfo());
            }
        }

        if(isWork) displayRemainedCount.MinusRemainedCount();
    }

    public void ImplementIfRule(ref SetCerealClass[] rules, int repeat)
    {
        if (displayRemainedCount.GetRemainedCount() == 0) return;

        if (!controlCerealBowl.CheckCereal(rules[0].GetAddInfo())) return;

        bool isWork = false;

        for (int i = 0; i < repeat; i++)
        {
            if (!controlCerealBowl.CheckCereal(rules[0].GetAddInfo())) continue;

            if (controlCerealBowl.ChangeCereal(rules[1].GetRemoveInfo()))
            {
                isWork = true;
                controlCerealBowl.ChangeCereal(rules[2].GetAddInfo());
            }
        }

        if (isWork) displayRemainedCount.MinusRemainedCount();
    }
}
