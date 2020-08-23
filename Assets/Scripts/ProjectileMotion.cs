
using System;
using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    public enum Direction
    {
        In,
        Out
    }

    public float speed = 0.1f;
    public bool isKinematic = false;
    public float MAXDISTANCE = 200;
    public float MINHEIGHT = 0.1f;
    public Direction direction = Direction.Out;
    private Vector3 movement = new Vector3();

    private void Start()
    {
        movement = (Camera.main.transform.forward + Camera.main.transform.up) * speed;
    }

    private void Update()
    {
        if (!isKinematic)
            return;
        Vector3 step = movement * Time.deltaTime;
        transform.Translate(step);
        transform.Rotate(step*5);
        if (Vector3.Distance(transform.position, Camera.main.transform.position) > MAXDISTANCE && direction == Direction.Out)
            Destroy(gameObject);
        if (transform.position.y < MINHEIGHT && direction == Direction.In)
            Destroy(gameObject);
    }
}
