using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Splines;

public class EnemyAi : MonoBehaviour
{

    public NavMeshAgent agent;
    public Vector3 moveTo;
    public GameObject TheBoss;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        TheBoss = GameObject.Find("TheBoss");

        moveTo = new Vector3(TheBoss.transform.position.x, TheBoss.transform.position.y, TheBoss.transform.position.z);

        agent.SetDestination(moveTo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
