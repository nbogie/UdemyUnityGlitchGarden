using UnityEngine;

public class DamageFloatingScript : MonoBehaviour
{
    public float speed = 1f;
    public float amplitude = 0.5f;
    public float frequency = 4f;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        Vector2 offset = Time.deltaTime * Vector2.right * amplitude * Mathf.Sin(Time.timeSinceLevelLoad * frequency);

        transform.Translate((Vector2.up * speed * Time.deltaTime) + offset);
        Color c = spriteRenderer.color;
        c.a -= 1f * Time.deltaTime;
        spriteRenderer.color = c;
    }
}
