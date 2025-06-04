using UnityEngine;
using UnityEngine.Rendering;

public class BuildManager : MonoBehaviour
{

    [SerializeField] private GameObject standardTowerPrefab;
    public static BuildManager Instance;
    private GameObject _towerToBuild;
    

    private void Start()
    {
        _towerToBuild = standardTowerPrefab;
    }


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
}
