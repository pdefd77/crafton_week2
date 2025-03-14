using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; } // ╫л╠шео

    public Sprite[] Sprites;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Sprites = Resources.LoadAll<Sprite>("Sprites/Shapes");
    }
}
