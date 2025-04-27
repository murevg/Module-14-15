using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private Item currentItem;
    public Transform itemHoldPoint;

    void OnTriggerEnter(Collider other)
    {
        if (currentItem != null) return;

        Item item = other.GetComponent<Item>();
        if (item != null)
        {
            currentItem = item;
            item.transform.SetParent(itemHoldPoint);
            item.transform.localPosition = Vector3.zero;
            Debug.Log("Ты подобрал предмет.");
        }

        if (currentItem is ProjectileItem projectileItem)
        {
            projectileItem.SetShootPoint(itemHoldPoint);
        }

        if (currentItem != null)
        {
            Rotator rotator = currentItem.GetComponentInChildren<Rotator>();

            if (rotator != null)
            {
                rotator.enabled = false;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (currentItem != null)
            {
                Debug.Log("Ты использовал предмет.");
                currentItem.Use(GetComponent<Player>());
                currentItem = null;
            }
            else
            {
                Debug.Log("Нет предмета для использования!");
            }
        }
    }
}
