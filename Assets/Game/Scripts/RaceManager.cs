using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RaceManager : MonoBehaviour
{

    [SerializeField] private List<Snails> snails;
    [SerializeField] private GameObject snailPrefab;
    [SerializeField] private List<Transform> snailSlots;

    [FormerlySerializedAs("WinCanva")]
    [Header("WinCanva")]
    [SerializeField] private GameObject winCanva;
    [Header("Snail info")]
    [SerializeField] private Image snailImage;

    [SerializeField] private TextMeshProUGUI snailName;

    private bool isRaceOver = false;

    private List<SnailRace> snailRaces = new List<SnailRace>();
    
    private void Start()
    {
        winCanva.SetActive(false);
        for (int i = 0; i < snailSlots.Count; i++)
        {
            GameObject snailClone = Instantiate(snailPrefab, snailSlots[i].position, snailSlots[i].rotation);
            snails[i].Init();
            snailClone.name = snails[i].Name;
            
            SnailRace snailComp = snailClone.GetComponentInChildren<SnailRace>();
            if (snailComp == null)
            {
                Debug.LogError($"Aucun composant SnailRace trouvé sur le prefab pour {snails[i].Name}");
                continue;
            }
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
            if (snailRaces[i].HasFinished && !isRaceOver)
            {
                isRaceOver = true;
                StartCoroutine(SpawnRaces(snailRaces[i]));
                snailRaces[i].ResetStat();
            }
        }
    }
    
    IEnumerator SpawnRaces(SnailRace snailRace)
    {
        snailImage.sprite = snailRace.SnailSprite;
        snailName.SetText(snailRace.SnailName);
        winCanva.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu");
    }
}