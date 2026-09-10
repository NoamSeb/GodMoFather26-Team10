using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;

public class PlayerCursorSetup : MonoBehaviour
{
    [Header("Réglages Curseur")]
    public float cursorSpeed = 800f;

    private PlayerInput playerInput;
    private VirtualMouseInput virtualMouseInput;
    private RectTransform rectTransform;
    private RectTransform parentCanvasRect;
    private Camera playerCamera;
    private InputAction moveAction;
    private InputAction clickAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        MultiplayerEventSystem mpEventSystem = GetComponent<MultiplayerEventSystem>();
        virtualMouseInput = GetComponent<VirtualMouseInput>();
        rectTransform = GetComponent<RectTransform>();
        
        if (playerInput != null && playerInput.actions != null)
        {
            moveAction = playerInput.actions.FindAction("Navigate");
            clickAction = playerInput.actions.FindAction("Click");
            if(clickAction != null)
                Debug.LogWarning(clickAction.name);
            else
                Debug.Log("Click action is null");
            
            if (moveAction != null)
            {
                moveAction.Enable();
                clickAction.Enable();
            }
        }
        else
        {
            Debug.Log("No PlayerInput found");
        }
        
        int index = playerInput.playerIndex;
        string cameraName = (index == 0) ? "Camera_P1" : "Camera_P2";
        string canvasName = (index == 0) ? "Canvas_P1" : "Canvas_P2";

        GameObject camObj = GameObject.Find(cameraName);
        if (camObj != null)
        {
            playerCamera = camObj.GetComponent<Camera>();
            playerInput.camera = playerCamera;
        }

        GameObject targetCanvas = GameObject.Find(canvasName);
        if (targetCanvas != null)
        {
            transform.SetParent(targetCanvas.transform, false);
            parentCanvasRect = targetCanvas.GetComponent<RectTransform>();

            if (mpEventSystem != null)
            {
                mpEventSystem.playerRoot = targetCanvas;
            }

            rectTransform.anchoredPosition = Vector2.zero;
        }
    }
    
    private void Start()
    {
        if (virtualMouseInput != null && virtualMouseInput.virtualMouse != null && playerInput != null)
        {
            InputUser.PerformPairingWithDevice(virtualMouseInput.virtualMouse, playerInput.user);
        }
    }

    private void Update()
    {
        if (parentCanvasRect == null || moveAction == null) return;

        
        Vector2 stickInput = moveAction.ReadValue<Vector2>();

        if (stickInput.sqrMagnitude > 0.01f)
        {
            Vector2 newPos = rectTransform.anchoredPosition + (stickInput * cursorSpeed * Time.deltaTime);
            
            Vector2 halfCanvasSize = parentCanvasRect.sizeDelta * 0.5f;
            newPos.x = Mathf.Clamp(newPos.x, -halfCanvasSize.x, halfCanvasSize.x);
            newPos.y = Mathf.Clamp(newPos.y, -halfCanvasSize.y, halfCanvasSize.y);

            rectTransform.anchoredPosition = newPos;
            
            if (virtualMouseInput != null && virtualMouseInput.virtualMouse != null && playerCamera != null)
            {
                Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(playerCamera, rectTransform.position);
                InputState.Change(virtualMouseInput.virtualMouse.position, screenPoint);
            }
            else
            {
                Debug.Log("Virtual Mouse not found");
            }

            if (clickAction != null && clickAction.triggered)
            {
                Debug.Log("Click");
            }
        }
    }
}