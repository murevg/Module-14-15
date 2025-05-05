using UnityEngine;

public class HealthItem : Item
{
    [SerializeField] private int healthIncrease = 20;

    public override void Use(GameObject user)
    {
        Player player = user.GetComponent<Player>();

        if (player != null)
        {
            player.IncreaseHealth(healthIncrease);
            Destroy(gameObject);
        }
    }
}
