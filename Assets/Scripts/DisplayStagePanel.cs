using UnityEngine;
using UnityEngine.UI;

public class DisplayStagePanel : MonoBehaviour
{
    private void Awake()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SelectStage>().SetStage(i + 1);
            transform.GetChild(i).GetComponent<Button>().interactable = false;
        }

        transform.GetChild(0).GetComponent<Button>().interactable = true;
    }
}
