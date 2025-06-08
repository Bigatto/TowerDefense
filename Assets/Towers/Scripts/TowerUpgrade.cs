using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerUpgrade : MonoBehaviour, IPointerClickHandler
{
    private GameObject _tower;
    private int _upgradeLevel = 0; //max 2

    private SpriteRenderer _spriteRenderer;
    [SerializeField] private List<Sprite> upgradeSprite;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_upgradeLevel < upgradeSprite.Count -1)
        {
            _upgradeLevel++;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = upgradeSprite[_upgradeLevel];
        }
        Debug.Log("Tower upgrade area clicked.");
    }
}
