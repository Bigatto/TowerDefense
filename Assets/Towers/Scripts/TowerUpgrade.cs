using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerUpgrade : MonoBehaviour, IPointerClickHandler
{
    private int _upgradeLevel = 0; //max 2
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private List<TowerUpgradeData> upgradeData;
    [SerializeField] private Tower tower;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_upgradeLevel < upgradeData.Count - 1)
        {
            _upgradeLevel++;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = upgradeData[_upgradeLevel].upgradeSprite;
            tower.IncreaseFireRate(upgradeData[_upgradeLevel].upgradeRatio);
        }
    }
}

[Serializable]
public class TowerUpgradeData
{
    public Sprite upgradeSprite;
    public float upgradeRatio;      
}