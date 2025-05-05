using UnityEngine;

public class SpeedItem : Item
{
    [SerializeField] private float _speedIncrease = 10f;

    public override void Use(GameObject user)
    {
        Player player = user.GetComponent<Player>();

        if (player != null)
        {
            player.IncreaseSpeed(_speedIncrease);
            Destroy(gameObject);
        }
    }
}
