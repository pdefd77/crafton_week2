using UnityEngine;

public class SetWinImage : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = new Vector2(Screen.width, Screen.height);

        Destroy(gameObject, 1.5f);
    }

    private void OnDestroy()
    {
        LevelManager.Instance.GotoScene(0);
    }
}
