using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPurchase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler

{
    private Renderer _rend;
    [SerializeField] private Color hoverColor;
    private Color _startColor;

    private GameObject _tower;
 

    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        /* if (eventData.button == PointerEventData.InputButton.Left)
         {
             Debug.Log("Left mouse button clicked on the tower purchase area.");

         }*/
        if (_tower != null)
        {
            Debug.Log("Tower purchase area clicked.");
            return;
        }
        GameObject towerToBuild = BuildManager.Instance.GetTowerToBuild();
        _tower = (GameObject) Instantiate(towerToBuild, transform.position, transform.rotation);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _rend.material.color = hoverColor;
        Debug.Log("Mouse entered the tower purchase area.");
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exited the tower purchase area.");
       _rend.material.color = _startColor;
    }

}