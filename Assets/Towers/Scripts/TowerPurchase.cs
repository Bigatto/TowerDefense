using UnityEngine;
using UnityEngine.EventSystems;


public class TowerPurchase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler

{
    private Renderer _rend;
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color noMoneyColor;
    public Vector3 positionOffset;
    private Color _startColor;

    [Header("Optional")]
    public GameObject _tower;
    BuildManager _buildManager;


    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
        _buildManager = BuildManager.Instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_buildManager.CanBuild)
        {
            return;
        }

        if (_tower != null)
        {
            Debug.Log("Tower purchase area clicked.");
            return;
        }
        _buildManager.BuildTowerOn(this);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_buildManager.HasMoney)
        {
            _rend.material.color = hoverColor;
        }
        else
        {
            _rend.material.color = noMoneyColor;
        }

        if (!_buildManager.CanBuild)
        {
            return;
        }

        if (_buildManager.HasMoney)
        {
            _rend.material.color = hoverColor;
        }        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       _rend.material.color = _startColor;
    }
}