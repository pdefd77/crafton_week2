using TMPro;
using UnityEngine;

public class SetCerealClass : MonoBehaviour
{
    [SerializeField] private int count;
    [SerializeField] private CerealShape shape;
    [SerializeField] private CerealColor color;

    private void Start()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = count.ToString();
    }

    public (CerealClass, int) GetRemoveInfo()
    {
        return (new CerealClass(shape, color), -count);
    }

    public (CerealClass, int) GetAddInfo()
    {
        return (new CerealClass(shape, color), count);
    }
}
