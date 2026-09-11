using UnityEngine;
using UnityEngine.UI;

public abstract class Items : ScriptableObject
{
    [SerializeField] private string itemName;
    public string ItemName => itemName;
    
    [SerializeField] int price;
    public int Price => price;
    [SerializeField] bool isMeteoEvent;
    [SerializeField] private string description;
    public string Description => description;
    [SerializeField] private Sprite sprite;
    public Sprite Sprite => sprite;

    public abstract void Effect(int snailIndex);
}