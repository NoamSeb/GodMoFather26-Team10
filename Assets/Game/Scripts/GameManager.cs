using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private List<Snails> snails;
    public List<Snails> Snails => snails;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void ApplyEffect(int snailIndex, Items itemToApply)
    {
        itemToApply.Effect(snailIndex);
    }
}
