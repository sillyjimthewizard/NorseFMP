using Unity.Cinemachine;
using UnityEngine;

public class _CameraManager : MonoBehaviour
{
    public static _CameraManager Instance;
    [SerializeField] private bool useEdgeScrolling = false;
    public CinemachineFollow cameraFollow;
    public bool CanCam;
    private bool dragPanMoveActive;
    private Vector2 LastMousePos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    private void Update()
    {
        if (CanCam == true)
        {
            Vector3 InputDir = new Vector3(0, 0, 0);
            //inputlogic

            if (Input.GetKey(KeyCode.W)) InputDir.z = +1f;
            if (Input.GetKey(KeyCode.S)) InputDir.z = -1f;
            if (Input.GetKey(KeyCode.A)) InputDir.x = -1f;
            if (Input.GetKey(KeyCode.D)) InputDir.x = +1f;

            if (useEdgeScrolling)
            {
                int edgeScrollSize = 20;
                if (Input.mousePosition.x < edgeScrollSize)
                {
                    InputDir.x = -1f;
                }
                if (Input.mousePosition.y < edgeScrollSize)
                {
                    InputDir.z = -1f;
                }
                if (Input.mousePosition.x > edgeScrollSize)
                {
                    InputDir.x = +1f;
                }
                if (Input.mousePosition.y > edgeScrollSize)
                {
                    InputDir.z = +1f;
                }



                // edge scrolling
                if (Input.mousePosition.x < edgeScrollSize) InputDir.x = -1f;
                if (Input.mousePosition.y < edgeScrollSize) InputDir.z = -1f;
                if (Input.mousePosition.x < Screen.width - edgeScrollSize) InputDir.x = +1f;
                if (Input.mousePosition.y < Screen.height - edgeScrollSize) InputDir.z = -1f;

            }


            if (Input.GetMouseButtonDown(1))
            {
                dragPanMoveActive = true;
                LastMousePos = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(1))
            {
                dragPanMoveActive = false;

            }

            if (dragPanMoveActive == true)
            {
                Vector2 mouseMovementDelta = (Vector2)Input.mousePosition - LastMousePos;
                Debug.Log(mouseMovementDelta);
                float dragPanSpeed = 1f;
                InputDir.x = mouseMovementDelta.x * dragPanSpeed;
                InputDir.z = mouseMovementDelta.y * dragPanSpeed;
                LastMousePos = Input.mousePosition;
            }

            Vector3 moveDir = transform.forward * InputDir.z + transform.right * InputDir.x;

            float moveSpeed = 50f;
            transform.position += moveDir * moveSpeed * Time.deltaTime;


       

            // rotation logic

            float rotateDir = 0f;
            float rotateYDir = 0f;
            if (Input.GetKey(KeyCode.Q)) rotateDir = -1f;
            if (Input.GetKey(KeyCode.E)) rotateDir = +1f;
          //  if (Input.GetKey(KeyCode.LeftShift) && cameraFollow.FollowOffset.y < 10) rotateYDir = +1f;
          //  if (Input.GetKey(KeyCode.LeftControl) && cameraFollow.FollowOffset.y > 0) rotateYDir = -1f;
              if (Input.GetAxis("Mouse ScrollWheel") < 0f && cameraFollow.FollowOffset.y < 10) rotateYDir = +50f;
            if (Input.GetAxis("Mouse ScrollWheel") > 0f && cameraFollow.FollowOffset.y > 0) rotateYDir = -50f;
            float rotateSpeed = 150f;
            float rotateSpeedY = 5;


            cameraFollow.FollowOffset += new Vector3(0, rotateYDir * rotateSpeedY * Time.deltaTime, 0);


            transform.eulerAngles += new Vector3(0, rotateDir * rotateSpeed * Time.deltaTime, 0);
        }
    }


}
