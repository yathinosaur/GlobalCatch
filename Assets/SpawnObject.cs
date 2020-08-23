
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject[] projectiles;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Camera camera;

    private GameObject currentProjectile;
    private int index = 0;
x
    public void LaunchProjectile()
    {
        if (projectiles[index].GetComponent<ProjectileMotion>() == null)
            projectiles[index].AddComponent<ProjectileMotion>();
        Vector3 spawnPos = camera.transform.position + startPos.z * camera.transform.forward + startPos.y * camera.transform.up;
        currentProjectile = Instantiate(projectiles[index], spawnPos, new Quaternion());
        currentProjectile.GetComponent<ProjectileMotion>().isKinematic = true;
        ShiftIndex();
    }
    private void ShiftIndex()
    {
        ++index;
        if (index >= projectiles.Length)
            index = 0;
    }
}
