using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DroppableRule : MonoBehaviour, IDropHandler
{
    private Image image;
    private RectTransform rect;

    private void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;

        if (eventData.pointerDrag != null && transform.childCount<1)
        {
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;

            image.color = new Color(1f, 0.7f, 0.7f);
        }
    }
}
