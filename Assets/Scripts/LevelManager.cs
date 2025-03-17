using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; } // ╫л╠шео

    public Sprite[] sprites;
    public int clearedStages = 1;
    [SerializeField] private GameObject winImage;

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

        sprites = Resources.LoadAll<Sprite>("Sprites/Shapes");
    }

    public void Win()
    {
        clearedStages++;
        Instantiate(winImage);
    }

    public void GotoScene(int sceneIdx)
    {
        SceneManager.LoadScene(sceneIdx);
    }
}
