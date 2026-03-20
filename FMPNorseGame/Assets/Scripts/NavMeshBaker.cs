using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBaker : MonoBehaviour
{
    public NavMeshSurface NavMesh;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NavMesh = GameObject.FindGameObjectWithTag("NavMesh").GetComponent<NavMeshSurface>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            NavMesh.BuildNavMesh();
        }
    }



}
