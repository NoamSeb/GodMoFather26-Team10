using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class PlayerCursorSetup : MonoBehaviour
{
    [Header("Réglages Curseur")] public float cursorSpeed = 800f;

    private PlayerInput playerInput;
    private RectTransform rectTransform;
    private RectTransform parentCanvasRect;

    private Camera playerCamera;

    private Vector2 moveVector;
    private Vector2 direction;

    // Ajouts nécessaires pour le raycast UI
    private Canvas parentCanvas;
    private GraphicRaycaster graphicRaycaster;
    private MultiplayerEventSystem mpEventSystem;
    private PointerEventData pointerEventData;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        mpEventSystem = GetComponent<MultiplayerEventSystem>();
        rectTransform = GetComponent<RectTransform>();

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
            parentCanvas = targetCanvas.GetComponent<Canvas>();
            graphicRaycaster = targetCanvas.GetComponent<GraphicRaycaster>();

            if (mpEventSystem != null)
            {
                mpEventSystem.playerRoot = targetCanvas;
            }

            rectTransform.anchoredPosition = Vector2.zero;
        }

        // Instanciation indispensable
        pointerEventData = new PointerEventData(EventSystem.current);
    }

    private void Update()
    {
        if (parentCanvasRect is null) return;
        MoveCursor();
    }

    public void ReadMoveInput(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    public void ReadClickInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            TryClickUnderCursor();
        }
    }

    private void MoveCursor()
    {
        direction = new Vector2(moveVector.x, moveVector.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            Vector2 newPos = rectTransform.anchoredPosition + (moveVector * (cursorSpeed * Time.deltaTime));

            Vector2 halfCanvasSize = parentCanvasRect.sizeDelta * 0.5f;
            newPos.x = Mathf.Clamp(newPos.x, -halfCanvasSize.x, halfCanvasSize.x);
            newPos.y = Mathf.Clamp(newPos.y, -halfCanvasSize.y, halfCanvasSize.y);

            rectTransform.anchoredPosition = newPos;
        }
    }

    private void TryClickUnderCursor()
    {
        if (graphicRaycaster == null || parentCanvas == null) return;

        Debug.Log("Click");
        
        pointerEventData.position = RectTransformUtility.WorldToScreenPoint(parentCanvas.worldCamera, rectTransform.position);

        List<RaycastResult> results = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerEventData, results);

        foreach (RaycastResult result in results)
        {
            Debug.Log("Hit: " + result.gameObject.name);
            Button button = result.gameObject.GetComponent<Button>();
            if (button != null && button.interactable)
            {
                button.onClick.Invoke();
                return;
            }
        }
            
    }
}