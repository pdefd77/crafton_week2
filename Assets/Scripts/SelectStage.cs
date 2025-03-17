using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectStage : MonoBehaviour
{
    public int stage;

    private void Start()
    {
        if (LevelManager.Instance.clearedStages < stage) transform.GetComponent<Button>().interactable = false;
        else transform.GetComponent<Button>().interactable = true;
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
