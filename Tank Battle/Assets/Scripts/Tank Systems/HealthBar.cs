using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health health;

    private RectTransform healthBar;

    private float width;
    private float height;

    void Awake()
    {
        healthBar = GetComponent<RectTransform>();
    }

    void Start()
    {
        width = healthBar.sizeDelta.x;
        height = healthBar.sizeDelta.y;
    }

    void Update()
    {
        float x = width * health.healthPercentage;
        float y = height;

        Vector2 healthBarSize = new(x, y);
        healthBar.sizeDelta = healthBarSize;
    }
}
