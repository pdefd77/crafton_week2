using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCerealBowl : MonoBehaviour
{
    [SerializeField] private Transform cerealBowl;
    [SerializeField] private GameObject cereal;
    [SerializeField] private SetCerealPanel setCerealPanel;
    private SortedDictionary<CerealClass, LinkedList<GameObject> > cerealBowlPool = new();
    private Bounds cerealBowlBounds;
    public int[,] Counts = new int[6,5];

    private void Awake()
    {
        cerealBowlBounds = cerealBowl.GetComponent<CompositeCollider2D>().bounds;
    }

    // cerealClass�� count��ŭ �߰��ϰų� ����
    public bool ChangeCereal((CerealClass ,int) Info)
    {
        CerealClass cerealClass = Info.Item1;
        int count = Info.Item2;

        if (count >= 0)
        {
            setCerealPanel.ChangeCount(cerealClass, count);
            StartCoroutine(AddCerealCoroutine(cerealClass, count));
        }
        else
        {
            if (cerealBowlPool.ContainsKey(cerealClass) && cerealBowlPool[cerealClass].Count >= -count) // cerealClass�� count�� �̻��� ���� ����
            {
                setCerealPanel.ChangeCount(cerealClass, count);
                StartCoroutine(RemoveCerealCoroutine(cerealClass, -count));
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    public bool CheckCereal((CerealClass, int) Info)
    {
        CerealClass cerealClass = Info.Item1;
        int count = Info.Item2;

        return (cerealBowlPool.ContainsKey(cerealClass) && cerealBowlPool[cerealClass].Count == count);
    }

    // cerealClass�� count�� �߰�
    private IEnumerator AddCerealCoroutine(CerealClass cerealClass, int count)
    {
        if (!cerealBowlPool.ContainsKey(cerealClass)) cerealBowlPool.Add(cerealClass, new());
        
        var nowList = cerealBowlPool[cerealClass];

        for(int i = 0; i < count; i++)
        {
            GameObject newCereal = CreateCereal(cerealClass);

            newCereal.transform.position = new Vector2(Random.Range(cerealBowlBounds.min.x + newCereal.transform.localScale.x, cerealBowlBounds.max.x - newCereal.transform.localScale.x), Random.Range(cerealBowlBounds.max.y - newCereal.transform.localScale.y, cerealBowlBounds.max.y - newCereal.transform.localScale.y / 2.0f));
            newCereal.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(Random.Range(-500f, 500f), Random.Range(-400f, -300f));

            if (Random.Range(0, 2) == 0) nowList.AddFirst(newCereal);
            else nowList.AddLast(newCereal);

            yield return null;
            //yield return new WaitForSeconds(0.1f);
        }

        if (cerealClass.shape == CerealShape.Star)
        {
            yield return new WaitForSeconds(0.5f);

            LevelManager.Instance.Win();
        }
        
        yield break;
    }

    // cerealClass�� count�� ���� (������ ��쿡��)
    private IEnumerator RemoveCerealCoroutine(CerealClass cerealClass, int count)
    {
        var nowList = cerealBowlPool[cerealClass];

        for (int i = 0; i < count; i++)
        {
            Destroy(nowList.Last.Value);
            nowList.RemoveLast();

            yield return null;
            //yield return new WaitForSeconds(0.1f);
        }

        if (nowList.Count == 0) cerealBowlPool.Remove(cerealClass);

        yield break;
    }

    private GameObject CreateCereal(CerealClass cerealClass)
    {
        GameObject newCereal = Instantiate(cereal);

        SpriteRenderer newCerealImage = newCereal.transform.GetChild(0).GetComponent<SpriteRenderer>();
        Color newColor = Color.black;

        switch (cerealClass.color)
        {
            case CerealColor.Red:
                newColor = new Color(1f, 0, 0);
                break;
            case CerealColor.Green:
                newColor = new Color(0, 1f, 0);
                break;
            case CerealColor.Blue:
                newColor = new Color(0, 0.4f, 1f);
                break;
            case CerealColor.Pink:
                newColor = new Color(1f, 0.4f, 1f);
                break;
            case CerealColor.Yellow:
                newColor = new Color(0.95f, 0.95f, 0);
                break;
            default:
                break;
        }

        newCerealImage.sprite = LevelManager.Instance.sprites[(int)cerealClass.shape];
        newCerealImage.color = newColor;

        return newCereal;
    }
}
