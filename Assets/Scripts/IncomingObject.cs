using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomingObject : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private echoAR echo;
    private GameObject currentProjectile;

    public void SpawnObject(string objectName)
    {
        currentProjectile = echo.prefabs[0];
        foreach (GameObject projectile in echo.prefabs)
        {
            if (projectile.name == objectName)
                currentProjectile = projectile;
        }
        Vector3 spawnPos = camera.transform.position + startPos.z * camera.transform.forward + startPos.y * camera.transform.up;
        GameObject newProjectile = Instantiate(currentProjectile, spawnPos, new Quaternion());
        if (newProjectile.GetComponent<CustomBehaviour>() != null)
            newProjectile.GetComponent<CustomBehaviour>().notChecked = false;
        newProjectile.SetActive(true);
        newProjectile.AddComponent<ProjectileMotion>();
        newProjectile.GetComponent<ProjectileMotion>().speed = -5f;
        newProjectile.GetComponent<ProjectileMotion>().direction = ProjectileMotion.Direction.In;
        newProjectile.GetComponent<ProjectileMotion>().isKinematic = true;
    }
}
