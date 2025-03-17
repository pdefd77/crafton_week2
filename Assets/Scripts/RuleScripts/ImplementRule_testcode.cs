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
    [SerializeField] GameObject winImage;

    public void ImplementRule()
    {
        if (controlCerealBowl.ChangeCereal(new CerealClass(cerealShape1, cerealColor1), -cerealClass1Count))
        {
            controlCerealBowl.ChangeCereal(new CerealClass(cerealShape2, cerealColor2), cerealClass2Count);

            if (cerealShape2 == CerealShape.Star)
            {
                LevelManager.Instance.Win();
            }
        }
    }
}
