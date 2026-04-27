using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Splines;

public class EnemyAi : MonoBehaviour
{

    public NavMeshAgent agent;
    public Vector3 moveTo;
    public GameObject TheBoss;


    public float DistanceToBoss;
    public float InitialDistance;
    public float DistanceToPoint;

    [Header("UnitStats")]
    public float StrengthMult;
    public float SpeedMult;
    public float HealthMult;
    public float CoinMult;
    public float damage;
    public string LastUpgrade;
    public bool HazardImmune;

    [Header("Movement")]
    public float DivideBy;
    public float point, point2, point3;
    public int pointCounter;

    [Header("FFX")]
    public AudioClip DeathSound;
    public AudioClip SpawnSound;
    public GameObject SpawnEffect;
    public GameObject DeathEffect;
    public Animator animator;
    Rigidbody[] thephysics;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //_SoundManager.instance.PlaySound(SpawnSound);
        agent = GetComponent<NavMeshAgent>();
        TheBoss = GameObject.Find("TheBoss");
        DistanceToBoss = Vector3.Distance(this.transform.position, TheBoss.transform.position);
        InitialDistance = DistanceToBoss;
        CalculateDistance();
        _SoundManager.instance.PlayParticle(SpawnEffect, this.transform.position, 1f);
        thephysics = GetComponentsInChildren<Rigidbody>();
        deactivateRagdoll();
    }


    public void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
        DistanceToBoss = Vector3.Distance(this.transform.position, TheBoss.transform.position);

        if (DistanceToBoss <= 2)
        {
            damage = damage * StrengthMult;
            _GameManager.Instance.TakeDamage(damage, TheBoss);
            _SoundManager.instance.PlayParticle(DeathEffect, this.transform.position, 1f);
            Destroy(this.gameObject);
        }

        DistanceToPoint = Vector3.Distance(this.transform.position, new Vector3(point, moveTo.y, moveTo.z));
        if (DistanceToPoint <= 2)
        {
            pointCounter++;
            CalculateDistance();
        }
    }

    public void OnDestroy()
    {
        int CoinCount = Mathf.RoundToInt(InitialDistance - DistanceToBoss);

        _GameManager.Instance.Currency += CoinCount * CoinMult;
        //_SoundManager.instance.PlaySound(DeathSound);

    }


    public void CalculateDistance()
    {
        if (pointCounter <= 2)
        {
            DivideBy += 0.3f;

            CheckValid();
            
            //point2 = TheBoss.transform.position.x * 0.6f;
            //point3 = TheBoss.transform.position.x * 0.9f;
            agent.SetDestination(moveTo);
        }
        else
        {
            agent.SetDestination(TheBoss.transform.position);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            Debug.Log("Hit");
            if (HazardImmune == false)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void deactivateRagdoll()
    {
        foreach (var rigidBody in thephysics)
        {
            rigidBody.isKinematic = true;
            rigidBody.useGravity = true;
            animator.enabled = true;
            agent.enabled = true;
        }
    }

    public void CheckValid()
    {
        point = TheBoss.transform.position.x * DivideBy;
        NavMeshHit hit;
        float Additive = Random.Range(-22, 55);
        Vector3 Pointcheck = new Vector3(point, TheBoss.transform.position.y, TheBoss.transform.position.z + Additive);
        if (NavMesh.SamplePosition(Pointcheck, out hit, 1.0f, NavMesh.AllAreas))
        {
            
            moveTo = new Vector3(point, TheBoss.transform.position.y, TheBoss.transform.position.z + Additive);
        }

        else { CheckValid(); }
    }
      


}
