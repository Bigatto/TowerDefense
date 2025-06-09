using UnityEngine;

public class shop : MonoBehaviour
{
    public TowerToBuild standardTower;
    public TowerToBuild anotherTower;
    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.Instance;
    }
    public void SelectStandardTower()
    {
        Debug.Log("Standard Tower selected");
        buildManager.SelectTowerToBuild(standardTower);
    }
    public void SelectAnotherTower()
    {
        Debug.Log("Another Tower selected");
        buildManager.SelectTowerToBuild(anotherTower);
    }
}
