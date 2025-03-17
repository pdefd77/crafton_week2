using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    public int clearedStages = 0;
}

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; } // ╫л╠шео

    private string filePath;
    public PlayerData playerData;

    public Sprite[] sprites;
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

        playerData = LoadData();

        playerData ??= new PlayerData();

        sprites = Resources.LoadAll<Sprite>("Sprites/Shapes");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GotoScene(0);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            GotoScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Win()
    {
        playerData.clearedStages++;
        Instantiate(winImage);
    }

    public void GotoScene(int sceneIdx)
    {
        SceneManager.LoadScene(sceneIdx);
    }

    public void OnApplicationQuit()
    {
        SaveData(playerData);
    }

    public void SaveData(PlayerData data)
    {
        filePath = Path.Combine(Application.persistentDataPath, "playerData.bin");

        BinaryFormatter formatter = new();
        using FileStream stream = new(filePath, FileMode.Create);
        formatter.Serialize(stream, data);
    }

    private PlayerData LoadData()
    {
        filePath = Path.Combine(Application.persistentDataPath, "playerData.bin");

        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new();
            using FileStream stream = new(filePath, FileMode.Open);
            return (PlayerData)formatter.Deserialize(stream);
        }

        return null;
    }

    public void ResetData()
    {
        playerData = new PlayerData();
    }
}
