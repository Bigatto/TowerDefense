using UnityEngine;

public class shop : MonoBehaviour
{

    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.Instance;
    }
    public void PurchaseStandardTower()
    {
        Debug.Log("Standard Tower selected");
        buildManager.SetTowerToBuild(buildManager.standardTowerPrefab);
    }
    public void PurchaseAnotherTower()
    {
        Debug.Log("Another Tower selected");
        buildManager.SetTowerToBuild(buildManager.anotherTowerPrefab);
    }
}
