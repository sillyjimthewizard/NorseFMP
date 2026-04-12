using UnityEngine;

public class _GodUiUpgrader : MonoBehaviour
{

    public Transform cameraTransform;

    public _GameManager gameManager;
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
        Debug.Log("sus");
         if (gameManager.SpawnNumber != 1)
         {
            gameManager.SpawnNumber--;
            gameManager.SpawnCounter = 0;
         }

         else if (gameManager.SpawnNumber == 1)
         {
            gameManager.SpawnNumber++;

         }


    }
    public void UpgradeSpawnPoints()
    {
        //if ( gameManager.SpawnPointStart != 4)
        // {
        

         if (gameManager.SpawnPointStart != 4)
        {
            gameManager.SpawnPointStart++;

        }
        // }




    }
}
