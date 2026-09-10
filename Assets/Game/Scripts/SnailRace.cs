using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class SnailRace : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    #region Snail Stats

    private int speed;
    private string snailName;
    

    #endregion
    
    public bool HasFinished => Mathf.Approximately(progress, 1f);
    
    private float progress = 0f;
    private float paceTimer;
    private float pace;
    private float NormalizedSpeed;
    private float raceExpectedTime;

    public void Init(int speed, string name)
    {
        Debug.Log($"{name} speed: {speed}");
        NormalizedSpeed = Mathf.InverseLerp(1, 10, speed);
        raceExpectedTime = Mathf.Lerp(40, 20, NormalizedSpeed);
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
        progress = Mathf.Clamp01(progress + mediumSpeed * pace * Time.deltaTime);
        
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, progress);
    }
}