using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject ItemPrefab;
    [SerializeField] private List<Transform> itemSlots;
    [SerializeField] private List<Items> itemList;

    private List<Items> availableItems;

    private void OnEnable()
    {
        DisplayItems();
    }

    private void DisplayItems()
    {
        Debug.Log("Display Items Trigger");
        availableItems = new List<Items>(itemList);

        Debug.Log($"Available Items: {availableItems.Count}");
        for (int i = 0; i < itemSlots.Count; i++)
        {
            GameObject itemClone = Instantiate(ItemPrefab, itemSlots[i]);
            RectTransform rt = itemClone.GetComponent<RectTransform>();
            rt.anchoredPosition = Vector2.zero;
            rt.localRotation = Quaternion.identity;
            rt.localScale = Vector3.one;
            
            int itemIdToPut = Random.Range(0, availableItems.Count);
            Items selectedItem = availableItems[itemIdToPut]; 
            
            itemClone.name = selectedItem.name;
            
            ItemDisplayer itds = itemClone.GetComponentInChildren<ItemDisplayer>();
            Image itemImg = itemClone.GetComponent<Image>();

            if (selectedItem.Sprite != null)
                itemImg.sprite = selectedItem.Sprite;

            itds.NamePriceTxt.SetText($"{selectedItem.ItemName} - {selectedItem.Price}$");

            if (selectedItem.Description != null)
                itds.DescriptionTxt.SetText(selectedItem.Description);

            Button btn = itemClone.GetComponentInChildren<Button>();
            btn.onClick.AddListener(() => { GameManager.Instance.ApplyEffect(0, selectedItem); });

            availableItems.Remove(selectedItem);
        }
    }

    public void ResetItems()
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            Destroy(itemSlots[i].GetChild(0).gameObject);
        }
    }
}