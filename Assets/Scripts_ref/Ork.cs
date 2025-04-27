using UnityEngine;

public class Ork : MonoBehaviour
{
    //private string _name;
    //private int _health;
    //private int _damage;

    public Ork(string name, int health, int damage)
    {
        Name = name;
        Health = health;
        Damage = damage;
    }

    public string Name { get; }
    public int Health { get; protected set; }
    public int Damage { get; protected set; }

    //public string Name => _name;
    //public int Health => _health;
    //public int Damage => _damage;

    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            Debug.LogError("damage < 0");
            return;
        }

        Health -= damage;

        if (Health < 0)
        {
            Health = 0;
            Debug.Log($"О нет! я {Name} умер!");
        }
    }
}
