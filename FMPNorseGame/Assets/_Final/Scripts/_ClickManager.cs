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
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       
        if (GodUiSpawned == false)
        {
            SpawnedGodUI = Instantiate(GodUi, new Vector3(this.transform.position.x, this.transform.position.y + 3, this.transform.position.z), Quaternion.identity, this.transform);
            GodUiSpawned = true;
        }
        if (GodUiSpawned == true)
        {
            GodUi.SetActive(true);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        

        if (GodUiSpawned == true)
        {
            GodUi.SetActive(false);
        }
    }
}
