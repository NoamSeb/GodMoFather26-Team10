using System;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    [SerializeField] private List<Snails> snails;
    [SerializeField] private GameObject snailPrefab;
    [SerializeField] private List<Transform> snailSlots;

    private List<SnailRace> snailRaces;
    private void Start()
    {
        for (int i = 0; i < snailSlots.Count; i++)
        {
            GameObject snailClone = Instantiate(snailPrefab, snailSlots[i].position, snailSlots[i].rotation);
            snails[i].Init();
            snailClone.name = snails[i].Name;
            
            SnailRace snailComp = snailClone.GetComponentInChildren<SnailRace>();
            snailRaces.Add(snailComp);
            if (snails[i].Sprite != null)
                snailComp.SnailSprite = snails[i].Sprite;
            else
            {
                Debug.LogWarning(snails[i].Name + " has no sprite");
            }
            
            #region Snail Stats
            snailComp.SnailName = snails[i].Name;
            snailComp.Speed = snails[i].Speed;
            snailComp.Humidity = snails[i].Humidity;
            snailComp.Warmness = snails[i].Warmness;
            snailComp.Weight = snails[i].Weight;
            #endregion Snail Stats
            
            #region Snail Effect

            snailComp.HasRain = snails[i].hasRain;
            snailComp.HasSun =  snails[i].hasSun;
            snailComp.HasSnow = snails[i].hasSnow;
            snailComp.HasWind = snails[i].hasWind;
            snailComp.HasSalt =  snails[i].hasSalt;
            snailComp.HasMutagene = snails[i].hasMutagene;

            #endregion Snail Effect
        }
    }
    
    private void Update()
    {
        for (int i = 0; i < snailRaces.Count; i++)
        {
            if (snailRaces[i].HasFinished)
            {
                Debug.Log($"{snailRaces[i]} has won the race");
                snailRaces[i].ResetStat();
            }
        }
    }
}