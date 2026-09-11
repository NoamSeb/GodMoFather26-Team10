using System;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.UIElements;
using System.Collections.Generic;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "Snails", menuName = "Scriptable Objects/Snails")]
public class Snails : ScriptableObject
{
    //stats always between 0 and 10
    int points = 30;

    [SerializeField] private string name;

    public string Name
    {
        get => name;
    }

    [SerializeField] private Sprite sprite;
    public Sprite Sprite => sprite;


    [SerializeField] int speed = 5; //determines its rate

    public int Speed
    {
        get => speed;
        set => speed = value;
    }

    [SerializeField] int humidity = 5; //if rain event -> speed gets +1

    public int Humidity
    {
        get => humidity;
    }

    [SerializeField] int warmness = 5; //if snow event -> the higher it is, the lesser the snail freezes

    public int Warmness
    {
        get => warmness;
    }

    [SerializeField] int weight = 5; //if wind event -> the higher it is, the lesser the snail gets pushed back

    public int Weight
    {
        get => weight;
    }

    //to know if the snail gets special events during the race
    public bool hasRain = false;
    public bool hasSun = false;
    public bool hasSnow = false;
    public bool hasWind = false;
    public bool hasSalt = false;
    public bool hasBackJump = false;
    public bool hasGun = false;
    public bool hasMutagene = false;


    private int snailOods;

    public int SnailOods
    {
        get => snailOods;
    }

    public void Init()
    {
        speed = Random.Range(1, 10);
        // Debug.Log(speed);
        points -= speed * 2;
        humidity = Random.Range(1, 10);
        points -= humidity;
        if (points <= 0)
        {
            warmness = 0;
        }
        else if (points <= 10)
        {
            warmness = points;
        }
        else
        {
            warmness = Random.Range(1, 10);
        }

        points -= warmness;
        if (points <= 0)
        {
            weight = 0;
        }
        else if (points <= 10)
        {
            weight = points;
        }
        else
        {
            weight = Random.Range(1, 10);
        }

        points = 30;
    }

    public string[] GetStats()
    {
        List<int> statsNb = new List<int>() { speed, humidity, warmness, weight };
        string[] statsChara = new string[4];
        for (int i = 0; i < statsNb.Count; i++)
        {
            if (statsNb[i] <= 2)
            {
                statsChara[i] = "--";
            }
            else if (statsNb[i] <= 5)
            {
                statsChara[i] = "-";
            }
            else if (statsNb[i] <= 8)
            {
                statsChara[i] = "+";
            }
            else
            {
                statsChara[i] = "++";
            }
        }

        return statsChara;
    }

    private static readonly Dictionary<WeatherType, Action<Snails>> weatherSetters = new()
    {
        { WeatherType.Rain, s => s.hasRain = true },
        { WeatherType.Sun, s => s.hasSun = true },
        { WeatherType.Snow, s => s.hasSnow = true },
        { WeatherType.Wind, s => s.hasWind = true },
    };

    private static readonly Dictionary<ItemType, Action<Snails>> itemSetters = new()
    {
        { ItemType.Salt, s => s.hasSalt = true },
        { ItemType.Mutagene, s => s.hasMutagene = true }
    };

    public void SetWeather(WeatherType type)
    {
        if (weatherSetters.TryGetValue(type, out var setter))
        {
            setter(this);
        }
        else
        {
            Debug.LogWarning($"Aucun setter défini pour {type}");
        }
    }

    public void SetEffect(ItemType itemType)
    {
        if (itemSetters.TryGetValue(itemType, out var setter))
        {
            setter(this);
        }
        else
        {
            Debug.LogWarning($"Aucun setter pour {itemType}");
        }
    }
}