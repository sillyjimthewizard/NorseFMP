using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class _GodUiUpgrader : MonoBehaviour
{

    public Transform cameraTransform;

    public _GameManager gameManager;

    public float UpgradeCost1;
    public float UpgradeCost2;
    public float UpgradeCostUtility;
    public float UpgradeAmount;
    public string GodThisBelongsTo;
    public Canvas WorldCanvas;
    public TMP_Text UpgradeTextOne, UpgradeTextTwo, UpgradeTextMult; // mult = upgrade cost 2, upgrade text two = utility and upgrade text one = upgrade cost 1;
    public bool IsFreja;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WorldCanvas = this.GetComponentInChildren < Canvas > ();
        cameraTransform = GameObject.Find("CinemachineCamera").transform;
        gameManager = GameObject.Find("GameManager").GetComponent<_GameManager>();
        WorldCanvas.worldCamera = GameObject.Find("UIcam").GetComponent<Camera>();
        if (IsFreja == false)
        {
            UpgradeTextMult = GameObject.Find("UpgradeCostMult").GetComponent<TMP_Text>();
        }
        UpgradeTextOne = GameObject.Find("UpgradeCost1").GetComponent<TMP_Text>();
        UpgradeTextTwo = GameObject.Find("UpgradeCost2").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cameraTransform.position);
        transform.Rotate(0, 180, 0);
        if (IsFreja == false)
        {
            UpgradeTextMult.text = "Cost: " + UpgradeCost2.ToString("F1");
            UpgradeTextOne.text = "Cost: " + UpgradeCostUtility.ToString("F1");
            UpgradeTextTwo.text = "Cost: " + UpgradeCost1.ToString("F1");
        }
        else if (IsFreja == true)
        {
            UpgradeTextOne.text = "Cost: " + UpgradeCost1.ToString("F1");
            UpgradeTextTwo.text = "Cost: " + UpgradeCost2.ToString("F1");
        }
        



    }

   public void UpgradeSpawnRate()
    {
        if (gameManager.Currency >= UpgradeCost1)
        {
            Debug.Log("sus");
            if (gameManager.SpawnNumber != 1)
            {
                gameManager.SpawnNumber--;
                gameManager.SpawnCounter = 0;
                gameManager.Currency -= UpgradeCost1;
                UpgradeCost1 *= 1.3f;
            }

            else if (gameManager.SpawnNumber == 1)
            {
                gameManager.SpawnNumber++;
            }
        }
    }
    public void UpgradeSpawnPoints()
    {
        //if ( gameManager.SpawnPointStart != 4)
        // {

        if (gameManager.Currency >= UpgradeCost2)
        {
            if (gameManager.SpawnPointStart != 4)
        {
            gameManager.SpawnPointStart++;
            gameManager.Currency -= UpgradeCost2;
            UpgradeCost2 *= 1.3f;
        }
        }
    }

    public void Upgrade()
    {
        if (gameManager.Currency >= UpgradeCost2)
        {
            _GodBehaviour GodScript = GameObject.Find(GodThisBelongsTo).GetComponent<_GodBehaviour>();
            GodScript.UpgradeAmount += UpgradeAmount;
            gameManager.Currency -= UpgradeCost2;
            UpgradeCost2 *= 1.3f;
            Debug.Log("MultUp");
        }
    }

    public void UpgradeRange(float Increase)
    {
        if (gameManager.Currency >= UpgradeCost1)
        {
            _GodBehaviour GodScript = GameObject.Find(GodThisBelongsTo).GetComponent<_GodBehaviour>();
            GodScript.Range += Increase;
            gameManager.Currency -= UpgradeCost1;
            UpgradeCost1 *= 1.3f;
            Debug.Log("rangeUp");
        }
    }
    public void UpgradeFireRate(float Increase)
    {
        if (gameManager.Currency >= UpgradeCostUtility)
        {
            _GodBehaviour GodScript = GameObject.Find(GodThisBelongsTo).GetComponent<_GodBehaviour>();
            GodScript.FireRate -= Increase;
            gameManager.Currency -= UpgradeCostUtility;
            UpgradeCostUtility *= 1.3f;
            Debug.Log("FireRateUp");
        }
    }
}
