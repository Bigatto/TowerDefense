using UnityEngine;
using UnityEngine.EventSystems;


public class TowerPurchase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler

{
    private Renderer _rend;
    [SerializeField] private Color hoverColor;
    private Color _startColor;

    private GameObject _tower;
    private BuildManager _buildManager;


    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
        _buildManager = BuildManager.Instance;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        /*if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        } */

        if (_buildManager.GetTowerToBuild() == null)
        {
            return;
        }

        if (_tower != null)
        {
            Debug.Log("Tower purchase area clicked.");
            return;
        }
        GameObject towerToBuild = _buildManager.GetTowerToBuild();
        _tower = (GameObject)Instantiate(towerToBuild, transform.position, transform.rotation);
        _buildManager.SetTowerToBuild(null);
             
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        /*if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }*/

        if (_buildManager.GetTowerToBuild() == null)
        {
            return;
        }
        _rend.material.color = hoverColor;
    }


    public void OnPointerExit(PointerEventData eventData)
    {
       _rend.material.color = _startColor;
    }

}