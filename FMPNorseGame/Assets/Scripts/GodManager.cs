using TMPro;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GodManager : MonoBehaviour
{

    public GameObject GodPrefab;
    public bool GodPlacement;
    public GameObject CurrentGod;
    RaycastHit hit;
    public LayerMask LayerMask;
    public Camera Camera;
    //public string GodName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GodPlacement ==  true)
        {
            //
            ////ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, LayerMask))
            //   {
            //    transform.position = hit.point;
            //
            NavMeshHit surface;
            Ray ray = Camera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, LayerMask))
            {
                Vector3 mousePos = hit.point;
                if (NavMesh.SamplePosition(mousePos, out surface, 2.0f, NavMesh.AllAreas))
                {}

                else { CurrentGod.transform.position = mousePos; }

            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GodPlacement = false;
                CurrentGod = null;

            }

        }

    }

 


    public void GodPlacementSetup(string GodName)
    {
        
       // GodName = Button.gameObject.name;
        GodPrefab = Resources.Load<GameObject>("Gods/" + GodName);
        Debug.Log(GodName);
        CurrentGod = Instantiate(GodPrefab);
        GodPlacement = true; 

    }


    public void GetGod(string GodNumber)
    {
        if (GodNumber == "0")
        {
            Debug.Log("God 1");
        }
        else if (GodNumber == "1") 
        {
            Debug.Log("God 2");             
        }
    }
}
