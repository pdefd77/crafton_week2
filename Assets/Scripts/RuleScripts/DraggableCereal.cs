using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableCereal : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform canvas;
    private RectTransform rect;
    private CanvasGroup canvasGroup;
    private float w, h;

    private void Awake()
    {
        canvas = FindFirstObjectByType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        w = (Screen.width - rect.sizeDelta.x) / 2;
        h = (Screen.height - rect.sizeDelta.y) / 2;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;

        if (transform.parent != canvas)
        {
            transform.parent.GetComponent<Image>().color = new Color(0.7f, 1f, 0.7f);
            transform.SetParent(canvas);
        }

        transform.SetAsLastSibling();

        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;

        rect.position += (Vector3)eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;

        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;

        Vector3 Pos = rect.position;

        if (Pos.x < -w) Pos.x = -w;
        else if (Pos.x > w) Pos.x = w;
        if (Pos.y < -h) Pos.y = -h;
        else if (Pos.y > h) Pos.y = h;

        rect.position = Pos;
    }
}
