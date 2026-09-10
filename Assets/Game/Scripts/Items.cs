using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Scriptable Objects/Items")]
public class Items : ScriptableObject
{
    [SerializeField] int price;
    [SerializeField] bool isMeteoEvent;
    [SerializeField] private string description;
    [SerializeField] private Sprite sprite;
    
}