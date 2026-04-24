using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.InputSystem.UI.VirtualMouseInput;

public class UIDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public RectTransform startingTransform;
    public Vector2 startinglocation;
    public string upgradetype;

    public bool CursorState; // true == unlocked : false == locked

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        startinglocation = rectTransform.localPosition;
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        //ResetPosition();

    }




    // Update is called once per frame
    void Update()
    {
        if (rectTransform.localPosition.x >= 958)
        {
            rectTransform.localPosition = new Vector2(880, rectTransform.localPosition.y);
        }
        if (rectTransform.localPosition.x <= -958)
        {
            rectTransform.localPosition = new Vector2(-880, rectTransform.localPosition.y);
        }

        if (rectTransform.localPosition.y >= 1131.555)
        {
            rectTransform.localPosition = new Vector2(rectTransform.localPosition.x, 550);
        }
        if (rectTransform.localPosition.y <= -1131.555)
        {
            rectTransform.localPosition = new Vector2(rectTransform.localPosition.x, -550);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CursorState = !CursorState;
            CheckCursor();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            ResetPosition();
        }
    }

    public void FixedUpdate()
    {
       
    }

    void ResetPosition()
    {
        rectTransform.localPosition = startinglocation;
    }

    void CheckCursor()
    {
        if (CursorState == true)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            _CameraManager.Instance.CanCam = false;
            

        }
        if (CursorState == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _CameraManager.Instance.CanCam = true;
            

        }
    }

}