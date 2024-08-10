using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FishItem : Item
{
    public FishItem(GameManager gameManager)
    {
        this.GameManager = gameManager;
    }

    public enum eFishType
    {
        TYPE_ONE,
        TYPE_TWO,
        TYPE_THREE,
        TYPE_FOUR,
        TYPE_FIVE,
        TYPE_SIX,
        TYPE_SEVEN
    }
   

    public eFishType ItemType;

    public void SetType(eFishType type)
    {
        ItemType = type;
    }

    protected override Sprite GetPrefabSprite()
    {
        Sprite prefabSprite = null;
        List<Object> objt = this.GameManager.ScriptableObject.fishObj;

        switch (ItemType)
        {
            case eFishType.TYPE_ONE:
                prefabSprite = objt.FirstOrDefault(o => o.name == (ObjName.PREFAB_NORMAL_TYPE_ONE)).sprite;
                break;
            case eFishType.TYPE_TWO:
                prefabSprite = objt.FirstOrDefault(o => o.name == (ObjName.PREFAB_NORMAL_TYPE_TWO)).sprite;
                break;
            case eFishType.TYPE_THREE:
                prefabSprite = objt.FirstOrDefault(o => o.name == (ObjName.PREFAB_NORMAL_TYPE_THREE)).sprite;
                break;
            case eFishType.TYPE_FOUR:
                prefabSprite = objt.FirstOrDefault(o => o.name == (ObjName.PREFAB_NORMAL_TYPE_FOUR)).sprite;
                break;
            case eFishType.TYPE_FIVE:
                prefabSprite = objt.FirstOrDefault(o => o.name == (ObjName.PREFAB_NORMAL_TYPE_FIVE)).sprite;
                break;
            case eFishType.TYPE_SIX:
                prefabSprite = objt.FirstOrDefault(o => o.name == (ObjName.PREFAB_NORMAL_TYPE_SIX)).sprite;
                break;
            case eFishType.TYPE_SEVEN:
                prefabSprite = objt.FirstOrDefault(o => o.name == (ObjName.PREFAB_NORMAL_TYPE_SEVEN)).sprite;
                break;
        }

        return prefabSprite;
    }

    internal override bool IsSameType(Item other)
    {
        FishItem it = other as FishItem;

        return it != null && it.ItemType == this.ItemType;
    }
}
