using UnityEngine;

public class OrkPaladin : Ork
{
    private int _additiveHealth;

    public OrkPaladin(int additiveHealth, string name, int health, int damage) : base (name, health, damage)
    {
        _additiveHealth = additiveHealth;
    }

    public void CastHeal()
    {
        Debug.Log("Я лечусь!");
        Health += _additiveHealth;
    }
}
