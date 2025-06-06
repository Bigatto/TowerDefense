using UnityEngine;
using UnityEngine.Rendering;

public class BuildManager : MonoBehaviour
{

    public GameObject standardTowerPrefab;
    public GameObject anotherTowerPrefab;
    public static BuildManager Instance;
    private GameObject _towerToBuild;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one BuildManager in the scene!");
            return;
        }
        Instance = this;
    }

    public GameObject GetTowerToBuild()
    {
        return _towerToBuild;
    }
    
    public void SetTowerToBuild(GameObject tower)
    {
        _towerToBuild = tower;
    }
}
