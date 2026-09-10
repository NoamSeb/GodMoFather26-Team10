using System;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    [SerializeField] private List<Snails> snails;
    [SerializeField] private GameObject snailPrefab;
    [SerializeField] private List<Transform> snailSlots;

    private void Start()
    {
        for (int i = 0; i < snailSlots.Count; i++)
        {
            GameObject snailClone = Instantiate(snailPrefab, snailSlots[i].position, snailSlots[i].rotation);
            snails[i].Init();
            snailClone.name = snails[i].Name;
            SpriteRenderer spriteRenderer = snailClone.gameObject.GetComponentInChildren<SpriteRenderer>();
            if (snails[i].Sprite != null)
                spriteRenderer.sprite = snails[i].Sprite;
            else
            {
                Debug.LogWarning(snails[i].Name + " has no sprite");
            }

            SnailRace snailComp = snailClone.GetComponentInChildren<SnailRace>();
            snailComp.Init(snails[i].Speed, snails[i].Name);
            // snailComp.Speed = snails[i].Speed;
            // Debug.Log($"{snails[i].Name} speed: {snailComp.Speed}");
        }
    }
}