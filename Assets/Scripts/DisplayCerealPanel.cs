using UnityEngine;
using UnityEngine.EventSystems;

public class DisplayCerealPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject cerealPanel;

    public void OnPointerEnter(PointerEventData eventData)
    {
        cerealPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cerealPanel.SetActive(false);
    }
}
