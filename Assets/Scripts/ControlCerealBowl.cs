using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlCerealBowl : MonoBehaviour
{
    [SerializeField] private Transform cerealBowl;
    [SerializeField] private GameObject cereal;
    private SortedDictionary<CerealClass, LinkedList<GameObject> > cerealBowlPool = new();
    private Bounds cerealBowlBounds;

    private void Awake()
    {
        cerealBowlBounds = cerealBowl.GetComponent<CompositeCollider2D>().bounds;
    }

    private void Start()
    {
        ChangeCereal(new CerealClass(CerealShape.Triangle, CerealColor.Red), 4);
        ChangeCereal(new CerealClass(CerealShape.Square, CerealColor.Red), 3);
        ChangeCereal(new CerealClass(CerealShape.Pentagon, CerealColor.Blue), 2);
    }

    // cerealClass를 count만큼 추가하거나 감소
    public bool ChangeCereal(CerealClass cerealClass, int count)
    {
        if (count >= 0)
        {
            StartCoroutine(AddCerealCoroutine(cerealClass, count));
        }
        else
        {
            count = -count;

            //Debug.Log(cerealBowlPool[cerealClass].Count);
            if (cerealBowlPool.ContainsKey(cerealClass) && cerealBowlPool[cerealClass].Count >= count) // cerealClass가 count개 이상일 때만 동작
            {
                StartCoroutine(RemoveCerealCoroutine(cerealClass, count));
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    // cerealClass를 count개 추가
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

            yield return new WaitForSeconds(0.1f);
        }
        
        yield break;
    }

    // cerealClass를 count개 제거 (가능한 경우에만)
    private IEnumerator RemoveCerealCoroutine(CerealClass cerealClass, int count)
    {
        var nowList = cerealBowlPool[cerealClass];

        for (int i = 0; i < count; i++)
        {
            Destroy(nowList.Last.Value);
            nowList.RemoveLast();

            yield return new WaitForSeconds(0.1f);
        }

        if (nowList.Count == 0) cerealBowlPool.Remove(cerealClass);

        yield break;
    }

    private GameObject CreateCereal(CerealClass cerealClass)
    {
        GameObject newCereal = Instantiate(cereal);

        newCereal.transform.GetChild(0).GetComponent<TextMeshPro>().text = (3 + (int)cerealClass.shape).ToString();

        switch (cerealClass.color)
        {
            case CerealColor.Red:
                newCereal.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case CerealColor.Green:
                newCereal.GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case CerealColor.Blue:
                newCereal.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            default:
                break;
        }

        return newCereal;
    }
}
