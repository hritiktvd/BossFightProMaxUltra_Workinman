using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DifficultyVariables
{
    public string Difficulty;
    public int PlatformCount;
    public float MinXScale;
    public float MaxXScale;
    public float MinZcale;
    public float MaxZScale;
    public float MinYHeight;
    public float MaxYHeight;
    public float MinPlatformGap;
    public int MaxPlatformGap;
    public float BossSpeed;
    public int JetpackFuel;
}

public class PCGLevelGenerator : MonoBehaviour
{
    private enum Difficulty { Baby, Easy, Medium, Hard, Titan}
    Difficulty difficulty;

    private static int DifficultyID;

    [SerializeField]
    private GameObject PCGCube;

    [SerializeField]
    private List<GameObject> Towers;

    private GameObject platform;

    [SerializeField]
    public List<DifficultyVariables> DifficultyVariables;

    public static bool spawnPlatform;

    private void OnEnable()
    {
        EventsManager.onTowerEnter += InitLevel;
    }

    private void OnDisable()
    {
        EventsManager.onTowerEnter -= InitLevel;
    }

    // Start is called before the first frame update
    void Start()
    {
        //difficulty = Difficulty.Baby;
        DifficultyID = 0;
        spawnPlatform = false;
    }

    private void InitLevel()
    {
        if (Input.GetKey(KeyCode.C))
        {
            //difficulty = (Difficulty)Random.Range(0,4);
            //Debug.Log("Difficulty:" + difficulty);
            if (!spawnPlatform)
            {
                GenerateLevel();
                spawnPlatform = true;
            }
        }
        if (Input.GetKey(KeyCode.X))
        {
            //switchDifficulty();
            spawnPlatform = false;
        }
    }

    private void generateBlockValues(int spawnID)
    {
        float CubeScaleX = Random.Range(DifficultyVariables[DifficultyID].MinXScale, DifficultyVariables[DifficultyID].MaxXScale);
        float CubeScaleZ = Random.Range(DifficultyVariables[DifficultyID].MinZcale, DifficultyVariables[DifficultyID].MaxZScale);
        float CubeHeightY = Random.Range(DifficultyVariables[DifficultyID].MinYHeight, DifficultyVariables[DifficultyID].MaxYHeight);
        float PlatformGap = Random.Range(DifficultyVariables[DifficultyID].MinPlatformGap, DifficultyVariables[DifficultyID].MaxPlatformGap);
        
        GenerateBlock(CubeScaleX, CubeScaleZ, CubeHeightY, PlatformGap, spawnID);
    }

    private void GenerateBlock(float scaleX, float scaleZ, float heightY, float platformGap, int spawnID)
    {
        platform = Instantiate(PCGCube);
        platform.SetActive(true);
        platform.transform.localScale = new Vector3(scaleX, PCGCube.transform.localScale.y, scaleZ);
        platform.transform.position = new Vector3(Towers[CollisionDetection.TowerID].transform.position.x, heightY, Towers[CollisionDetection.TowerID].transform.position.z*spawnID*0.4f);
        platform.transform.localRotation = Quaternion.Euler(0, 90, 0);
    }

    private void GenerateLevel()
    {
        PCGCube.SetActive(false);
        for(int i=0; i< DifficultyVariables[DifficultyID].PlatformCount; ++i)
        {
            generateBlockValues(i);
        }
    }

    [ContextMenu("Fetch Value")]
    public void FetchDifficultyRangeFromList()
    {
        Debug.Log(DifficultyVariables[0]);
    }

    public static void switchDifficulty() { 
        if(DifficultyID < 5) // 5 levels of difficulty. Same as difficultyVariables.count but this is a static function
        {
            DifficultyID++;
        }
    }
}
