using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class ItemCollector : MonoBehaviour
{
    private Item _currentItem;
    [SerializeField] private Transform _itemHoldPoint;
    private GameObject _user;

    private void Awake()
    {
        _user = gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (_currentItem != null) return;

        Item item = other.GetComponent<Item>();
        if (item != null)
        {
            _currentItem = item;

            item.transform.SetParent(_itemHoldPoint);
            item.transform.localPosition = Vector3.zero;
            item.transform.localRotation = Quaternion.identity;

            Debug.Log("Ты подобрал предмет.");
        }

        if (_currentItem != null)
        {
            Rotator rotator = _currentItem.GetComponentInChildren<Rotator>();

            if (rotator != null)
            {
                rotator.enabled = false;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_currentItem != null)
            {
                Debug.Log("Ты использовал предмет.");
                _currentItem.Use(_user);
                _currentItem = null;
            }
            else
            {
                Debug.Log("Нет предмета для использования!");
            }
        }
    }
}
