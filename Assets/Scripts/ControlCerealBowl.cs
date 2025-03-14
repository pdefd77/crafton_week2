using System.Collections;
using System.Collections.Generic;
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
        ChangeCereal(new CerealClass(CerealShape.Triangle, CerealColor.Red), 10);
    }

    // cerealClass�� count��ŭ �߰��ϰų� ����
    public void ChangeCereal(CerealClass cerealClass, int count)
    {
        if (count > 0) StartCoroutine(AddCerealCoroutine(cerealClass, count));
        else StartCoroutine(RemoveCerealCoroutine(cerealClass, -count));
    }

    // cerealClass�� count�� �߰�
    private IEnumerator AddCerealCoroutine(CerealClass cerealClass, int count)
    {
        if (!cerealBowlPool.ContainsKey(cerealClass)) cerealBowlPool.Add(cerealClass, new());
        
        var tmpList = cerealBowlPool[cerealClass];

        for(int i = 0; i < count; i++)
        {
            GameObject newCereal = Instantiate(cereal);
            newCereal.transform.position = new Vector2(Random.Range(cerealBowlBounds.min.x + newCereal.transform.localScale.x, cerealBowlBounds.max.x - newCereal.transform.localScale.x), Random.Range(cerealBowlBounds.max.y - newCereal.transform.localScale.y, cerealBowlBounds.max.y - newCereal.transform.localScale.y / 2.0f));
            newCereal.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(Random.Range(-500f, 500f), -200);

            if (Random.Range(0, 2) == 0) tmpList.AddFirst(newCereal);
            else tmpList.AddLast(newCereal);

            yield return new WaitForSeconds(0.25f);
        }
        
        yield break;
    }

    // cerealClass�� count�� ���� (������ ��쿡��)
    private IEnumerator RemoveCerealCoroutine(CerealClass cerealClass, int count)
    {
        if (!cerealBowlPool.ContainsKey(cerealClass) || cerealBowlPool[cerealClass].Count < count) yield break; // cerealClass�� count�� �̸��̶�� �������� ����

        var tmpList = cerealBowlPool[cerealClass];

        for (int i = 0; i < count; i++)
        {
            Destroy(tmpList.First.Value.gameObject);
            tmpList.RemoveFirst();

            yield return new WaitForSeconds(0.25f);
        }

        if (tmpList.Count == 0) cerealBowlPool.Remove(cerealClass);

        yield break;
    }
}
