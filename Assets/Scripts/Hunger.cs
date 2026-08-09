using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour
{
    [SerializeField] private float maxHunger = 100f;
    [SerializeField] private float drainPerSecond = 2f;
    [SerializeField] private Image hungerBar;

    private float currentHunger;

    private void Awake()
    {
        currentHunger = maxHunger;
    }

    private void Update()
    {
        currentHunger -= drainPerSecond * Time.deltaTime;
        currentHunger = Mathf.Clamp(currentHunger, 0f, maxHunger);

        hungerBar.fillAmount = currentHunger / maxHunger;
    }

    public void Restore(float amount)
    {
        currentHunger += amount;
        currentHunger = Mathf.Clamp(currentHunger, 0f, maxHunger);
    }
}
