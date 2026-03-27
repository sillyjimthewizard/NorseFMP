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

    [Header("UnitStats")]
    public float StrengthMult;
    public float SpeedMult;
    public float HealthMult;
    public float CoinMult;
    public float damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        TheBoss = GameObject.Find("TheBoss");

        moveTo = new Vector3(TheBoss.transform.position.x, TheBoss.transform.position.y, TheBoss.transform.position.z);

        agent.SetDestination(moveTo);
        DistanceToBoss = Vector3.Distance(this.transform.position, TheBoss.transform.position);
        InitialDistance = DistanceToBoss;
    }


    public void Update()
    {
       DistanceToBoss = Vector3.Distance(this.transform.position, TheBoss.transform.position);

        if (DistanceToBoss <= 2)
        {
            damage = damage * StrengthMult;
            BossManager.instance.BossHp -= damage;
            Destroy(this.gameObject);
        }
    }

    public void OnDestroy()
    {
        int CoinCount = Mathf.RoundToInt(InitialDistance - DistanceToBoss);

        GameManager.Instance.Currency += CoinCount * CoinMult;
    }

    
}
