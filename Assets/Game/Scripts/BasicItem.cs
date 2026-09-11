using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Scriptable Objects/Items/Basic Item")]
    public class BasicItem : Items
    {
        [SerializeField] private ItemType itemType;
        
        public override void Effect(int snailIndex)
        {
            GameManager.Instance.Snails[snailIndex].SetEffect(itemType);
        }
    }
