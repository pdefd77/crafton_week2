using UnityEngine;

public class ImplementRule_testcode : MonoBehaviour
{
    [SerializeField] CerealShape cerealShape1;
    [SerializeField] CerealColor cerealColor1;
    [SerializeField] int cerealClass1Count;
    [SerializeField] CerealShape cerealShape2;
    [SerializeField] CerealColor cerealColor2;
    [SerializeField] int cerealClass2Count;
    [SerializeField] ControlCerealBowl controlCerealBowl;

    public void ImplementRule()
    {
        if (controlCerealBowl.ChangeCereal(new CerealClass(cerealShape1, cerealColor1), -cerealClass1Count)) controlCerealBowl.ChangeCereal(new CerealClass(cerealShape2, cerealColor2), cerealClass2Count);
    }

    public void ImplementRuleVictory()
    {
        if (controlCerealBowl.ChangeCereal(new CerealClass(cerealShape1, cerealColor1), -cerealClass1Count)) Debug.Log("½Â¸®");
    }
}
