using UnityEngine;

public class SpeedItem : Item
{
    [SerializeField] private float _speedIncrease = 10f;

    public override void Use(Player player)
    {
        player.IncreaseSpeed(_speedIncrease);
        Destroy(gameObject);
    }
}
