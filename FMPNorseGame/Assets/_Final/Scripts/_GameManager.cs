using TMPro;
using UnityEngine;

public class _GameManager : MonoBehaviour
{

    //Store your global variables and game states


    //produce functions that are used globally.


    //store your ugrades
    public static _GameManager Instance;

    [Header("Upgrade Active")]
    [SerializeField] private bool coinMultiplierActive;


    [Header("Upgrade Variables")]
    [SerializeField] private float coinMultiplier;
    [SerializeField] private float strengthMultiplier;
    [SerializeField] private int spawnRate;
    public int ScanNum;
    public float Currency;

    [Header("Tick Variables")]
    public float TickTimer;
    [SerializeField] private float SetTickTime;
    [SerializeField] private float GlobalTime;

    [Header("Boss Variables")]
    public int BossStage;

    public void Awake()
    {
        Instance = this;
        SpawnNumber = 5;
        SetSpawns();
    }

    public void FixedUpdate()
    {
        if (TickTimer >= 0)
        {
            TickTimer -= Time.deltaTime;
            GlobalTime += Time.deltaTime;
        }
        else if (TickTimer <= 0)
        {
            TickTimer = SetTickTime;
            SpawnCounter++;
            ScanNum++;
            SpawnUnit();

        }
    }
    public void TakeDamage(float damage, GameObject target)
    {
        target.GetComponent<_HealthScript>().Health -= damage;
    }


    public void ActivateUpgrade(bool name)
    {
        name = true;
    }

    public void UpgradeFloatValue(float amount, float name)
    {
        name += amount;
    }

    public void UpgradeIntValue(int amount, int name)
    {
        name += amount;
    }

    public void UpgradeSpawnNum()
    {

        UpgradeIntValue(1, SpawnPointStart);
    }

    public TMP_Text CurrencyText;



    #region SpawnSystem

    [Header("SpawnSystem")]
    public GameObject[] SpawnPoints;
    [SerializeField] private GameObject Unit;
    public float SpawnNumber;
    public float SpawnCounter;
    public int SpawnPointNum;
    public int SpawnPointStart;


    public void SetSpawns()
    {
        SpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoints");
    }

    public void SpawnUnit()
    {
        if (SpawnCounter == SpawnNumber)
        {
            Debug.Log("Spawning");

            for (int i = 0; i < SpawnPointStart; i++)
            {

                Instantiate(Unit, SpawnPoints[SpawnPointNum].gameObject.transform);
                //i++;
                SpawnPointNum++;

            }
            SpawnCounter = 0;
            SpawnPointNum = 0;


        }
    }

    #endregion


    #region UI and Boss

    private void Start()
    {
        CurrencyText = GameObject.Find("CurrencyText").GetComponent<TMP_Text>();
    }
    private void Update()
    {
        CurrencyText.text = (_GameManager.Instance.Currency.ToString("F1"));

        
    }

    #endregion






}







