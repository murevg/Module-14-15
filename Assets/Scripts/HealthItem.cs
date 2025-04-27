using UnityEngine;

public class HealthItem : Item
{
    [SerializeField] private int healthIncrease = 20;

    public override void Use(Player player)
    {
        player.IncreaseHealth(healthIncrease);
        Destroy(gameObject);
    }
}
