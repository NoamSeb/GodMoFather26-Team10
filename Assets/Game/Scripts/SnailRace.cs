using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SnailRace : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    private Sprite snailSprite;

    public Sprite SnailSprite
    {
        get => snailSprite;
        set => snailSprite = value;
    }

    #region Snail Stats

    private int speed;
    public int Speed { get => speed; set => speed = value; }
    private string snailName;
    public string SnailName { get => snailName; set => snailName = value; }
    private int humidity;
    public int Humidity { get => humidity; set => humidity = value; }
    private int warmness;
    public int Warmness { get => warmness; set => warmness = value; }
    private int weight;
    public int Weight { get => weight; set => weight = value; }

    #endregion
    
    #region Snail Effects
    
    private bool hasRain = false;
    public bool HasRain { get => hasRain; set => hasRain = value; }
    
    private bool hasSun = false;
    public bool HasSun { get => hasSun; set => hasSun = value; }
    
    private bool hasSnow = false;
    public bool HasSnow { get => hasSnow; set => hasSnow = value; }
    
    private bool hasWind = false;
    public bool HasWind { get => hasWind; set => hasWind = value; }
    
    private bool hasSalt =  false;
    public bool HasSalt { get => hasSalt; set => hasSalt = value; }
    
    private bool hasMutagene = false;
    public bool HasMutagene { get => hasMutagene; set => hasMutagene = value; }

    #endregion
    
    public bool HasFinished => Mathf.Approximately(progress, 1f);
    
    private float progress = 0f;
    private float paceTimer;
    private float pace;
    private float normalizedSpeed;
    private float raceExpectedTime;


    private float snowTimer;
    
    public void Start()
    {
        CheckEffect();
        normalizedSpeed = Mathf.InverseLerp(1, 10, speed);
        raceExpectedTime = Mathf.Lerp(40, 20, normalizedSpeed);
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = SnailSprite;
        ChangePace();
    }

    private void ChangePace()
    {
        paceTimer = Random.Range(1f,5f);
        pace = Random.Range(0.5f, 1.5f);
    }

    private void Update()
    {
        Debug.Log($"{snailName} has {raceExpectedTime}");
        float mediumSpeed = 1 / raceExpectedTime;
        paceTimer -= Time.deltaTime;
        if (paceTimer <= 0f)
        {
            ChangePace();
        }
        if (hasSnow)
        {
            snowTimer -= Time.deltaTime;
            if (snowTimer <= 0f)
                ApplySnowEffect();
        }
        if (hasWind)
        {
            pace /= weight/1.5f;
        }
        progress = Mathf.Clamp01(progress + mediumSpeed * pace * Time.deltaTime);
        
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, progress);
    }

    private void CheckEffect()
    {
        if (hasRain && humidity > 4f)
            speed += 1;
        if (hasSun && humidity > 7f)
        {
            speed -= 1;
        }
        if(hasMutagene)
            Mutagene();
    }
    private void ApplySnowEffect()
    {   
        snowTimer = Random.Range(1f,3f);
        int probability = Random.Range(0, warmness);
        if (probability == 0)
        {
            pace = 0f;
        }
        else
        {
            ChangePace();
        }
    }
    
    public void Mutagene() //reroll all stats except speed
    {
        int rerollPts = 30 - speed*2;
        humidity = Random.Range(0, 10);
        rerollPts -= humidity;
        warmness = Random.Range(0, 10);
        rerollPts -= warmness;
        if (rerollPts <= 10)
        {
            weight = rerollPts;
        }
        else
        {
            weight = Random.Range(0, 10);
        }
    }

    public void ResetStat()
    {
        // Stats
        speed = 0;
        humidity = 0;
        warmness = 0;
        weight = 0;
        
        // Effects
        hasSnow = false;
        hasWind = false;
        hasMutagene = false;
        hasRain = false;
        hasSalt = false;
        hasSun = false;
    }
}