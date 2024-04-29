using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    private Vector3 StartPos;
    private float Counter = 0f;

    public float Speed = 1f;
    public Vector2 Radius = new Vector2(1, 1);
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Sin(Counter) * Radius.x;
        float y = Mathf.Cos(Counter) * Radius.y;

        transform.position = new Vector2(StartPos.x + x,StartPos.y + y);

        Counter = Counter + (Speed * Time.deltaTime);

        if (Counter > 2 * Mathf.PI)
        {
            Counter = Counter - 2 * Mathf.PI;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collided");
    }
}
