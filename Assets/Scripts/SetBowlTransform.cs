using UnityEngine;

public class SetBowlTransform : MonoBehaviour
{
    void Start()
    {
        float height = Screen.height / 2; // 600
        float width = Screen.width / 2; // 960
        float size = Screen.height * 3 / 4; // 900
        transform.localScale = new Vector3(size, size, 1);
        transform.position = new Vector3(height - width, 0, 0);
    }
}
