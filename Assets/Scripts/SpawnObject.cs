
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Camera camera;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private echoAR echo;

    private GameObject currentProjectile;
    private int index = 0;
    public void LaunchProjectile()
    {

        Vector3 spawnPos = camera.transform.position + startPos.z * camera.transform.forward + startPos.y * camera.transform.up;
        //currentProjectile = Instantiate(projectiles[index], spawnPos, new Quaternion());
        currentProjectile = Instantiate(GetGameObject(), spawnPos, new Quaternion());
        if (currentProjectile.GetComponent<CustomBehaviour>() != null)
            currentProjectile.GetComponent<CustomBehaviour>().notChecked = false;
        currentProjectile.SetActive(true);
        currentProjectile.AddComponent<ProjectileMotion>();
        currentProjectile.GetComponent<ProjectileMotion>().speed = 5f;
        currentProjectile.GetComponent<ProjectileMotion>().direction = ProjectileMotion.Direction.Out;
        currentProjectile.GetComponent<ProjectileMotion>().isKinematic = true;

        string projectileName = GetName();
        gameManager.SendProjectile(projectileName);

        ShiftIndex();
    }
    private void ShiftIndex()
    {
        ++index;
        //if (index >= projectiles.Length)
        if(index >= echo.prefabs.Count)
            index = 0;
    }
    private GameObject GetGameObject()
    {
        //if (index >= container.transform.childCount)
        if (index >= echo.prefabs.Count)
            index = 0;
        //return container.transform.GetChild(index).gameObject;
        return echo.prefabs[index];
    }

    private string GetName()
    {
        //if (index >= container.transform.childCount)
        if (index >= echo.prefabs.Count)
            index = 0;
        //return container.transform.GetChild(index).gameObject;
        return echo.prefabs[index].name;
    }
}
