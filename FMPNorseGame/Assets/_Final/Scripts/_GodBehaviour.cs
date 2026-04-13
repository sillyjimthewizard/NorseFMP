using UnityEngine;



public class _GodBehaviour : MonoBehaviour
{
    public float Range;
    public bool HasScanned;
    public Transform Target;
    public string UnitTag = "Unit";
    public Transform ThisTransform;

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
            }
        }

        if (nearestEnemy != null && shortestDistance <= Range)
        {
            Target = nearestEnemy.transform;
            Invoke("removetag", 1f);
            
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
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    void removetag()
    {
        if (Target == null)
            return;
        else
        {
            Target.tag = "Untagged";
        }
           
    }
}
