using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectStage : MonoBehaviour
{
    public int stage;

    private void Start()
    {
        if (LevelManager.Instance.playerData.clearedStages + 1 < stage)
        {
            transform.GetComponent<Button>().interactable = false;
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0f, 0f, 0f, 0);
        }
        else
        {
            transform.GetComponent<Button>().interactable = true;
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(0f, 0f, 0f);
        }
    }

    public void SetStage(int stage)
    {
        this.stage = stage;
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = stage.ToString();
    }

    public void GotoStage()
    {
        LevelManager.Instance.GotoScene(stage);
    }
}
