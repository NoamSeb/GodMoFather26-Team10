using UnityEngine;

[CreateAssetMenu(fileName = "New Weather Item", menuName = "Scriptable Objects/Items/Weather Item")]
public class WeatherItem : Items
{
    [SerializeField] private WeatherType weatherType;

    public override void Effect(int snailIndex)
    {
        // Adapte l'appel selon ton système existant
        GameManager.Instance.Snails[snailIndex].SetWeather(weatherType);
    }
}