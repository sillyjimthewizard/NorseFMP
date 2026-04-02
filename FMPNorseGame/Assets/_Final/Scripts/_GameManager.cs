using UnityEngine;

public class _GameManager : MonoBehaviour
{

    //Store your global variables and game states


    //produce functions that are used globally.


    //store your ugrades


    [Header("Upgrade Active")]
    [SerializeField] private bool coinMultiplierActive;


    [Header("Upgrade Variables")]
    [SerializeField] private float coinMultiplier;
    [SerializeField] private float strengthMultiplier;
    [SerializeField] private int spawnRate;




    public void TakeDamage(int damage, GameObject target)
    {
        //target.GetComponent<healthScript>().health -= damage;
    }


    public void ActivateUpgrade(bool name)
    {
        name = true;
    }

    public void UpgradeFloatValue(float amount, float name)
    {
        name += amount;
    }



    private void Start()
    {
        UpgradeFloatValue(1.9f, strengthMultiplier);
    }





}
