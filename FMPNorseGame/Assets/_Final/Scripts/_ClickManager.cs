using UnityEngine;
using UnityEngine.EventSystems;
public class _ClickManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject GodUi;

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
        Instantiate(GodUi);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("PointerEnter");

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("PointerExit");
    }
}
