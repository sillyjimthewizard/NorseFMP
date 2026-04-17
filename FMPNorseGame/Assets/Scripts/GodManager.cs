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
    public float Clamp;
    //public string GodName;

    public bool GodPlaced;


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
                if (NavMesh.SamplePosition(mousePos, out surface, Clamp, NavMesh.AllAreas))
                {}

                else { CurrentGod.transform.position = mousePos; }

            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GodPlacement = false;
                CurrentGod.transform.position = new Vector3(CurrentGod.transform.position.x, CurrentGod.transform.position.y + 0.5f, CurrentGod.transform.position.z);
                CurrentGod.name = GodPrefab.name;
                CurrentGod = null;
                hit.transform.gameObject.layer = default;
                GodPlaced = true;

            }

        }

    }

 


    public void GodPlacementSetup(string GodName)
    {
        if (GodPlaced == false)
        {
            // GodName = Button.gameObject.name;
            GodPrefab = Resources.Load<GameObject>("Gods/" + GodName);
            GodPrefab.GetComponent<_GodBehaviour>().;
            Debug.Log(GodName);
            CurrentGod = Instantiate(GodPrefab);
            GodPlacement = true;
        }
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
