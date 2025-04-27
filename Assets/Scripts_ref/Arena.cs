using UnityEngine;

public class Arena : MonoBehaviour
{
    void Start()
    {
        //Ork opk = new Ork("Базовый орк", 100, 20);
        OrkMage orkMage = new OrkMage(2, "Орк-Маг", 35, 20);
        OrkPaladin orkPaladin = new OrkPaladin(10, "Орк-Паладин", 80, 10);

        ProcessBattle(orkMage,orkPaladin);

        DetermineWinner(orkMage, orkPaladin);
    }

    private void ProcessBattle(OrkMage orkMage, OrkPaladin orkPaladin)
    {
        while (orkMage.Health > 0 && orkPaladin.Health > 0)
        {
            orkMage.CastSpell();
            orkPaladin.TakeDamage(orkMage.Damage);

            orkPaladin.CastHeal();
            orkMage.TakeDamage(orkPaladin.Damage);

            Debug.Log($"{orkPaladin.Name} - {orkPaladin.Health}");
            Debug.Log($"{orkMage.Name} - {orkMage.Health}");
        }
    }

    private void DetermineWinner(OrkMage orkMage, OrkPaladin orkPaladin)
    {
        if (orkMage.Health <= 0 && orkPaladin.Health <= 0)
            Debug.Log("Ничья!");
        else if (orkMage.Health > 0)
            Debug.Log($"{orkMage.Name} победил!");
        else
            Debug.Log($"{orkPaladin.Name} победил!");
    }
}
