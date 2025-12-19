using System;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public bool isActive { get; set; }

    public bool isMoving = false;
    public Vector3 direction = Vector3.zero;
    public float speed = 2f;
    public float distance = 3f;
    public float time = 0f;
    private Vector3 pos;

    public bool isCircular = false;
    public float circleRadius = 2f;
    public float circleSpeed = 2f;
    private float circleAngle = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
            return;

        if (isMoving)
        {
            time += Time.deltaTime;
            transform.localPosition = pos + direction * (float)Math.Sin(time * speed) * distance;   //oscillation :000
        }

        if (isCircular)
        {
            circleAngle += circleSpeed * Time.deltaTime;

            transform.localPosition = pos + new Vector3((float)Math.Cos(circleAngle) * circleRadius,
                (float)Math.Sin(circleAngle) * circleRadius, 0f);
        }
    }

    public void SetMovement(Vector3 Direction)
    {
        isMoving = true;
        isCircular = false;
        direction = Direction;
        pos = transform.localPosition;
    }

    public void SetCircularMovement(float radius, float speed)
    {
        isCircular = true;
        isMoving = false;
        circleRadius = radius;
        circleSpeed = speed;
        circleAngle = 0f;
        pos = transform.localPosition;
    }


    public void Reset()
    {
        pos = transform.localPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            GameManager.Instance.AddScore(10);
        }
    }
}
