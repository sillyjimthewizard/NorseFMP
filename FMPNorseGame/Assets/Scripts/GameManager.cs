using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("TickSystem")]
    public float TickTimer ;
    public float SetTickTime;
    public float GlobalTime;

    [Header("SpawnSystem")]
    public GameObject[] SpawnPoints;
    public GameObject Unit;
    public int SpawnCounter;
    public int SpawnNumber;
    public int SpawnPointNum;

    [Header("MONEY")]
    public float Currency;

   

    public static GameManager Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
        //SetTickTime = TickTimer;
        SetSpawns();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (TickTimer >= 0)
        {
            TickTimer -= Time.deltaTime;
            GlobalTime += Time.deltaTime;
        }
        else if (TickTimer <= 0)
        {
            SpawnCounter++;
            TickTimer = SetTickTime;
        }

        SpawnEnemy();

        
    }

    public void SpawnEnemy()
    {
        if (SpawnCounter == SpawnNumber)
        {
            Instantiate(Unit, SpawnPoints[SpawnPointNum].gameObject.transform);
            SpawnCounter = 0;
        }
    }
    public void SetSpawns()
    {
        SpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoints");
    }



}
