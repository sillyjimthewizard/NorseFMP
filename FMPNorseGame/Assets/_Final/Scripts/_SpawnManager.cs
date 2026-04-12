using UnityEngine;

public class _SpawnManager : MonoBehaviour
{
    public static _SpawnManager Instance;

    [Header("SpawnSystem")]
    public GameObject[] SpawnPoints;
    [SerializeField] private GameObject Unit;
    public float SpawnNumber, SpawnPointNum;
    public float SpawnCounter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
        //SetSpawns();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

   