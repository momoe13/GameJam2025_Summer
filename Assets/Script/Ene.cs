using UnityEditor;
using UnityEngine;

public class Ene: MonoBehaviour
{
    Vector2 pos, scale;
    private void Start()
    {
        pos = transform.position;
        scale = transform.localScale;
    }
    private void Update()
    {
        if (scale.y > 0)
        {
            pos.y -= Time.deltaTime;
            scale.y -= Time.deltaTime;
            transform.position = pos;
            transform.localScale = scale;

        }
    }

}
