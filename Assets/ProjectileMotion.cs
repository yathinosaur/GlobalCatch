
using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    public bool isKinematic = false;
    private float MAXDISTANCE = 200;
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
        if (Vector3.Distance(transform.position, Camera.main.transform.position) > MAXDISTANCE)
            Destroy(gameObject);
    }
}
