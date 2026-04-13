using UnityEngine;
using UnityEngine.EventSystems;
public class _ClickManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject GodUi;
    public GameObject SpawnedGodUI;
    public bool GodUiSpawned;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("PointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("PointerUp");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("PointerClick");
        if (GodUiSpawned == false)
        {
            SpawnedGodUI = Instantiate(GodUi, new Vector3(this.transform.position.x, this.transform.position.y + 3, this.transform.position.z), Quaternion.identity, this.transform);
            GodUiSpawned = true;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("PointerEnter");

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("PointerExit");

        if (GodUiSpawned == true)
        {
            Destroy(SpawnedGodUI);
            GodUiSpawned = false;
        }
    }
}
