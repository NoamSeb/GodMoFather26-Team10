using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointOfInterest : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject canvasToActivate;

    private void Start()
    {
#if UNITY_EDITOR
        FocusGameView();
#endif
    }

#if UNITY_EDITOR
    public static EditorWindow GetMainGameView()
    {
        var assembly = typeof(EditorWindow).Assembly;
        var type = assembly.GetType("UnityEditor.GameView");
        var gameview = EditorWindow.GetWindow(type);
        return gameview;
    }

    public static void FocusGameView()
    {
        var gameView = GetMainGameView();
        gameView.Focus();
    }
#endif

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Has been clicked");
        if (canvasToActivate != null)
        {
            canvasToActivate.SetActive(true);
            // canvasToActivate.TryGetComponent<ItemManager>(out ItemManager im);
            // if(im !=null)
            //     im.DisplayItems();
            // else
            // {
            //     Debug.LogWarning("No ItemManager found");
            // }
        }
    }
}