using Unity.Cinemachine;
using UnityEngine;

public class _GodUiUpgrader : MonoBehaviour
{

    public Transform cameraTransform;

    public _GameManager gameManager;

    public float UpgradeCost1;
    public float UpgradeCost2;
    public float UpgradeCostUtility;
    public float UpgradeCostUtility2;
    public float UpgradeAmount;
    public string GodThisBelongsTo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraTransform = GameObject.Find("CinemachineCamera").transform;
        gameManager = GameObject.Find("GameManager").GetComponent<_GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cameraTransform.position);
        transform.Rotate(0, 180, 0);
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
        if (gameManager.Currency >= UpgradeCostUtility)
        {
            _GodBehaviour GodScript = GameObject.Find(GodThisBelongsTo).GetComponent<_GodBehaviour>();
            GodScript.Range += Increase;
            gameManager.Currency -= UpgradeCostUtility;
            UpgradeCostUtility *= 1.3f;
            Debug.Log("rangeUp");
        }
    }
    public void UpgradeFireRate(float Increase)
    {
        if (gameManager.Currency >= UpgradeCostUtility)
        {
            _GodBehaviour GodScript = GameObject.Find(GodThisBelongsTo).GetComponent<_GodBehaviour>();
            GodScript.FireRate -= Increase;
            gameManager.Currency -= UpgradeCostUtility2;
            UpgradeCostUtility *= 1.3f;
            Debug.Log("FireRateUp");
        }
    }
}
