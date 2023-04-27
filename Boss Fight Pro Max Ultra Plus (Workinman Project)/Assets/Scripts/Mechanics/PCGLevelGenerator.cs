using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    public float MaxPlatformGap;
    public float BossSpeed;
    //public int JetpackFuel;
} 

public class PCGLevelGenerator : MonoBehaviour
{
    private enum Difficulty { Baby, Easy, Medium, Hard, Titan}
    Difficulty difficulty;


    [SerializeField]
    private GameObject PCGCube;

    [SerializeField]
    private List<GameObject> Towers;

    private GameObject platform;
    public NavMeshAgent BadGuy;

    [SerializeField]
    public List<DifficultyVariables> DifficultyVariables;

    public static bool spawnPlatform;

    private void OnEnable()
    {
        EventsManager.onTowerEnter += InitLevel;
        EventsManager.onGameStart += StartGame;
        EventsManager.onDifficultyChange += changeBossSpeed;
    }

    private void OnDisable()
    {
        EventsManager.onTowerEnter -= InitLevel;
        EventsManager.onGameStart -= StartGame;
        EventsManager.onDifficultyChange -= changeBossSpeed;
    }

    // Start is called before the first frame update
    private void StartGame()
    {
        //difficulty = Difficulty.Baby;
        GameState.DifficultyID = 0;
        BadGuy.speed = DifficultyVariables[GameState.DifficultyID].BossSpeed;
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
                StartCoroutine(CooldownPeriod());
            }
        }
    }

    private IEnumerator CooldownPeriod()
    {
        yield return new WaitForSeconds(0.5f);
        spawnPlatform = false; 
    }

    private void generateBlockValues(int spawnID)
    {
        float CubeScaleX = Random.Range(DifficultyVariables[GameState.DifficultyID].MinXScale, DifficultyVariables[GameState.DifficultyID].MaxXScale);
        float CubeScaleZ = Random.Range(DifficultyVariables[GameState.DifficultyID].MinZcale, DifficultyVariables[GameState.DifficultyID].MaxZScale);
        float CubeHeightY = Random.Range(DifficultyVariables[GameState.DifficultyID].MinYHeight, DifficultyVariables[GameState.DifficultyID].MaxYHeight);
        float PlatformGap = Random.Range(DifficultyVariables[GameState.DifficultyID].MinPlatformGap, DifficultyVariables[GameState.DifficultyID].MaxPlatformGap);

        Debug.Log(DifficultyVariables[GameState.DifficultyID].PlatformCount+" " +CubeScaleX + " " + CubeScaleZ + " " + CubeHeightY + " " + PlatformGap);
        
        GenerateBlock(CubeScaleX, CubeScaleZ, CubeHeightY, PlatformGap, spawnID);
    }

    private void GenerateBlock(float scaleX, float scaleZ, float heightY, float platformGap, int spawnID)
    {
        platform = Instantiate(PCGCube);
        platform.SetActive(true);
        platform.transform.localScale = new Vector3(scaleX, PCGCube.transform.localScale.y, scaleZ);
        platform.transform.position = new Vector3(Towers[EventsManager.TowerID].transform.position.x, heightY, Towers[EventsManager.TowerID].transform.position.z*platformGap);
        platform.transform.localRotation = Quaternion.Euler(0, 90, 0);
    }

    private void GenerateLevel()
    {
        PCGCube.SetActive(false);
        for(int i=0; i< DifficultyVariables[GameState.DifficultyID].PlatformCount; ++i)
        {
            generateBlockValues(i);
        }
    }

    [ContextMenu("Fetch Value")]
    public void FetchDifficultyRangeFromList()
    {
        Debug.Log(DifficultyVariables[0]);
    }

    private void changeBossSpeed()
    {
        BadGuy.speed = DifficultyVariables[GameState.DifficultyID].BossSpeed;
        Debug.Log("Boss Speed Changed to" + BadGuy.speed);
        if(GameState.DifficultyID == DifficultyVariables.Count-1) { Debug.Log("Max Boss Speed Reached"); }
    }

}
