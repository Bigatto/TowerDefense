using UnityEngine;

public class BuildManager : MonoBehaviour
{

    //[SerializeField] private GameObject standardTowerPrefab;
    //[SerializeField] private GameObject anotherTowerPrefab;
    [SerializeField] private GameObject _buildEffect;
    public static BuildManager Instance;
    private TowerToBuild _towerToBuild;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one BuildManager in the scene!");
            return;
        }
        Instance = this;
    }

    public bool CanBuild
    {
        get { return _towerToBuild != null; }
    }
    public bool HasMoney
    {
        get { return PlayerStats.Money >= _towerToBuild.cost; }
    }

    public void BuildTowerOn(TowerPurchase purchase)
    {
        if (PlayerStats.Money < _towerToBuild.cost)
        {
            Debug.Log("Not enough money to build this tower!");
            return;
        }

        PlayerStats.Money -= _towerToBuild.cost;
        GameObject _tower = Instantiate(_towerToBuild.towerPrefab, purchase.GetBuildPosition(), Quaternion.identity);
        purchase._tower = _tower;
        GameObject _effect = Instantiate(_buildEffect, purchase.GetBuildPosition(), Quaternion.identity);
        Destroy(_effect, 5f);
        //SelectTowerToBuild(null);

    }
    public void SelectTowerToBuild(TowerToBuild tower)
    {
        _towerToBuild = tower;
    }
}
