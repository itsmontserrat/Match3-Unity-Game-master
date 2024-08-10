using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NormalItem : Item
{
    public NormalItem(GameManager gameManager)
    {

        this.GameManager = gameManager; 
    }


    public enum eNormalType
    {
        TYPE_ONE,
        TYPE_TWO,
        TYPE_THREE,
        TYPE_FOUR,
        TYPE_FIVE,
        TYPE_SIX,
        TYPE_SEVEN
    }

    public eNormalType ItemType;

    public void SetType(eNormalType type)
    {
        ItemType = type;
    }

    protected override Sprite GetPrefabSprite()
    {
        Sprite prefabSprite = null;
        List<Object> objt = this.GameManager.ScriptableObject.normalObj;

        switch (ItemType)
        {
            case eNormalType.TYPE_ONE:
                prefabSprite = objt.FirstOrDefault(o => o.name == ObjName.PREFAB_NORMAL_TYPE_ONE).sprite;
                break;
            case eNormalType.TYPE_TWO:
                prefabSprite = objt.FirstOrDefault(o => o.name==(ObjName.PREFAB_NORMAL_TYPE_TWO)).sprite;
                break;
            case eNormalType.TYPE_THREE:
                prefabSprite = objt.FirstOrDefault(o => o.name==(ObjName.PREFAB_NORMAL_TYPE_THREE)).sprite;
                break;
            case eNormalType.TYPE_FOUR:
                prefabSprite = objt.FirstOrDefault(o => o.name == (ObjName.PREFAB_NORMAL_TYPE_FOUR)).sprite;
                break;
            case eNormalType.TYPE_FIVE:
                prefabSprite = objt.FirstOrDefault(o => o.name == (ObjName.PREFAB_NORMAL_TYPE_FIVE)).sprite;
                break;
            case eNormalType.TYPE_SIX:
                prefabSprite = objt.FirstOrDefault(o => o.name == (ObjName.PREFAB_NORMAL_TYPE_SIX)).sprite;
                break;
            case eNormalType.TYPE_SEVEN:
                prefabSprite = objt.FirstOrDefault(o => o.name == (ObjName.PREFAB_NORMAL_TYPE_SEVEN)).sprite;
                break;
        }

        return prefabSprite;
    }

    internal override bool IsSameType(Item other)
    {
        NormalItem it = other as NormalItem;

        return it != null && it.ItemType == this.ItemType;
    }
}
