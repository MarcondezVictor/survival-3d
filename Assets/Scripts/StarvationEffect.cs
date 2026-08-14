using UnityEngine;

public class StarvationEffect : MonoBehaviour
{
    [SerializeField] private float starveDamagePerSecond = 5f;
    [SerializeField] private float regenPerSecond = 3f;
    [SerializeField] private float regenThreshold = 0.7f;

    private Hunger hunger;
    private Health health;

    private void Awake()
    {
        hunger = GetComponent<Hunger>();
        health = GetComponent<Health>();
    }

    private void Update()
    {
        float hungerLevel = hunger.Normalized;

            // Beetween 0% to 70% health doesnt change
        if (hungerLevel <= 0f)
        {
            // Starving: Health damage
            health.Damage(starveDamagePerSecond * Time.deltaTime);
        }
        else if (hungerLevel >= regenThreshold)
        {
            // Well-fed +70%: regen life 
            health.Heal(regenPerSecond * Time.deltaTime);
        }
    }
}
