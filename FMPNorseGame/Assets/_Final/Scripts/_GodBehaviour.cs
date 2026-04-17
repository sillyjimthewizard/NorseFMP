using UnityEngine;



public class _GodBehaviour : MonoBehaviour
{
    public float Range;
    public bool HasScanned;
    public Transform Target;
    public string UnitTag = "Unit";
    public Transform ThisTransform;
    public bool UnitUpgraded;

    [Header("Upgrade Active")]
    public float UpgradeAmount;
    public EnemyAi UnitScript;
    public bool GodUnlocked;
    

    private void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.5f);
        ThisTransform = this.transform;
    }

    public void UpdateTarget()
    {
        
        GameObject[] units = GameObject.FindGameObjectsWithTag(UnitTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject unit in units)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, unit.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = unit;
                //sets up how it finds the target
            }

        }

        if (nearestEnemy != null && shortestDistance <= Range)
        {
            Target = nearestEnemy.transform;
            UnitScript = Target.GetComponent<EnemyAi>();
            //ChangeAStat();
            if (UnitScript.LastUpgrade != this.gameObject.name)
            {
                Invoke("ChangeAStat", 1f);
            }
           
            //what to do when there is a target 
        }
        else
        {
            Target = null;
            
        }

    }

    private void Update()
    {
        if (Target == null)
            return;

        Vector3 dir = Target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        this.transform.rotation = Quaternion.Euler (0f, rotation.y, 0f);
        // Handles Rotation By turning it based on where the Unit Is
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range); // Shows Range When Clicked
    }

   

    void ChangeAStat()
    {
        if (Target == null)
            return;
        else
        {
            WhichStat();
            //Target.tag = "Untagged"; // Makes it untarget the unit
        }
    }

    void WhichStat()
    {
        
        if (this.gameObject.name == "Thor")
        {
            UnitScript.StrengthMult += UpgradeAmount;
            UnitScript.LastUpgrade = "Thor";
        }

        if (this.gameObject.name == "NotThor")
        {
            UnitScript.CoinMult *= UpgradeAmount;
            UnitScript.LastUpgrade = "NotThor";
        }

        if (this.gameObject.name == "AlsoNotThor")
        {
            UnitScript.HazardImmune = true;
            UnitScript.LastUpgrade = "AlsoNotThor";
        }

    }
}
// Start is called once before the first execution of Update after the MonoBehaviour is created
// public void FixedUpdate()
// {
//     if (_GameManager.Instance.ScanNum >= 1)
//     {
//
//     }
// }
//
// // Update is called once per frame
// public void ScanForUnits()
// {
//     Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, Range);
//     foreach (var hitCollider in hitColliders)
//     {
//         transform.LookAt(hitCollider.transform.position);
//     }
// }