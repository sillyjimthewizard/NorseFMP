using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [Header("State Variables")]
    public int BossStage;
    public int Gamestate; // 0 = main menu 1 = gameplay 

    [Header("Boss Variables")]
    public Animator BossAnimator;
    public GameObject Fenrir;
    public GameObject Nidhogg;
    public GameObject Ratatoskr;
    public GameObject CurrentBoss;
    public GameObject BossName;
    public TMP_Text BossTextMesh;
    public AudioClip Howl;


    public void Awake()
    {
        Instance = this;
        SpawnNumber = 5;
        SetSpawns();
        BossName = GameObject.Find("BossName");
        BossTextMesh = BossName.GetComponent<TMP_Text>();
    }

    public void FixedUpdate()
    {
        if (Gamestate == 1 || Gamestate == 4)
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
        if (CurrentBoss != null)
        {
            BossTextMesh.text = CurrentBoss.name;
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


    #region UI 

    public TMP_Text CurrencyText;
    public GameObject HowToPlay;
    public GameObject GameCamPoint;
    public CinemachineCamera CutsceneCam, GameCam, MenuCam;
    public GameObject UpgradeUI;
    public  GameObject Menu;
    public GameObject QuitCheck;
    public GameObject EndScreen;

    private void Start()
    {
        // CurrencyText = GameObject.Find("CurrencyText").GetComponent<TMP_Text>();
        Menu = GameObject.Find("Buttons");
    }
    private void Update()
    {
        CurrencyText.text = (Currency.ToString("F1"));

    }

    public void play()
    {
        GameObject MainMenu = GameObject.Find("MainMenu");
        MainMenu.SetActive(false);
        Gamestate = 1;
        MenuCam = GameObject.Find("Menu Cam").GetComponent<CinemachineCamera>();
        //CutsceneCam = GameObject.Find("CutsceneCam").GetComponent<CinemachineCamera>(); 
       // GameCam = GameObject.Find("CinemachineCamera").GetComponent<CinemachineCamera>();
        MenuCam.Priority.Value = -1;
       // CutsceneCam.Priority.Value = 1;
        //GameCamPoint.SetActive(true);
    
        UpgradeUI.SetActive(true);
        StartBossAnim();
    }

    public void HowTo()
    {
        
        Menu.SetActive(false);
        HowToPlay.SetActive(true);
    }

    public void StopHowTo()
    {
        HowToPlay.SetActive(false);
        Menu.SetActive(true);
    }

    public void AreYouSure()
    {
        Menu.SetActive(false);
        QuitCheck.SetActive(true);
    }

    public void StopSureCheck()
    {
        QuitCheck.SetActive(false);
        Menu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EndGame()
    {
        EndScreen.SetActive(true);
        UpgradeUI.SetActive(false);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    #endregion

    #region Boss 

    public void StartBossAnim()
    {

        if (BossStage == 0)
        {
            GameCam.Priority.Value = 0;
            CurrentBoss = Instantiate(Ratatoskr);
            CurrentBoss.name = "Ratatoskr";
            BossAnimator = GameObject.Find("Ratatoskr").GetComponent<Animator>();
            BossAnimator.SetInteger("AnimState", 1);
            Invoke("StopAnim", 6);
        }

        if (BossStage == 1)
        {
            GameCam.Priority.Value = 0;
            CurrentBoss = Instantiate(Fenrir);
            CurrentBoss.name = "Fenrir";
            BossAnimator = GameObject.Find("Fenrir").GetComponent<Animator>();
            Time.timeScale = 0.25f;
            BossAnimator.SetInteger("ActionType_int", 6);
            _SoundManager.instance.PlaySound(Howl);
            Invoke("StopAnim", 2);
        }
        if (BossStage == 2)
        {
            Destroy(CurrentBoss);
            GameCam.Priority.Value = 0;
            CurrentBoss = Instantiate(Nidhogg);
            CurrentBoss.name = "Nidhogg";
            BossAnimator = GameObject.Find("Nidhogg").GetComponent<Animator>();
            Time.timeScale = 0.25f;
            
            Invoke("StopAnim", 1.25f);
        }

        if (BossStage == 3)
        {
            EndGame();
            
        }

    }

    public void StopAnim()
    {
        Time.timeScale = 1f;
        if (BossStage == 0)
        {
            BossAnimator.SetInteger("AnimState", 0);

        }

        if (BossStage == 1)
        {
            BossAnimator.SetInteger("ActionType_int", 0);
        }
        GameCam.Priority.Value = 2;
    }


    #endregion

}







