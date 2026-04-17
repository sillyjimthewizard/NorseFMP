using UnityEngine;

public class _GodUiUpgrader : MonoBehaviour
{

    public Transform cameraTransform;

    public _GameManager gameManager;

    public float UpgradeCostSpawnRate;
    public float UpgradeCostSpawnPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraTransform = Camera.main.transform;
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
        if (gameManager.Currency >= UpgradeCostSpawnRate)
        {
            Debug.Log("sus");
            if (gameManager.SpawnNumber != 1)
            {
                gameManager.SpawnNumber--;
                gameManager.SpawnCounter = 0;
                gameManager.Currency -= UpgradeCostSpawnRate;
                UpgradeCostSpawnRate *= 1.3f;
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

        if (gameManager.Currency >= UpgradeCostSpawnPoints)
        {
            if (gameManager.SpawnPointStart != 4)
        {
            gameManager.SpawnPointStart++;
            gameManager.Currency -= UpgradeCostSpawnPoints;
            UpgradeCostSpawnPoints *= 1.3f;

        }

        }




    }
}
