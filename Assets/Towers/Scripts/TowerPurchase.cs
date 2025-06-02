using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPurchase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler

{
    private Renderer _rend;
    [SerializeField] private Color hoverColor;
    private Color _startColor;
    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
    }
    //public Color hoverColor;
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