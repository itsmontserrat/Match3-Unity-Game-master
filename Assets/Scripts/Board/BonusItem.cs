using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BonusItem : Item
{
    public BonusItem(GameManager gameManager)
    {
        this.GameManager = gameManager;
    }
    public enum eBonusType
    {
        NONE,
        HORIZONTAL,
        VERTICAL,
        ALL
    }

    public eBonusType ItemType;

    public void SetType(eBonusType type)
    {
        ItemType = type;
    }

    protected override Sprite GetPrefabSprite()
    {
        Sprite prefabSprite = null;
        List<BonusObject> objt = this.GameManager.ScriptableObject.bonusObj;
        switch (ItemType)
        {
            case eBonusType.NONE:
                break;
            case eBonusType.HORIZONTAL:
                prefabSprite = objt.FirstOrDefault(o => o.name==("PREFAB_BONUS_HORIZONTAL")).sprite;
                break;
            case eBonusType.VERTICAL:
                prefabSprite = objt.FirstOrDefault(o => o.name == ("PREFAB_BONUS_VERTICAL")).sprite; 
                break;
            case eBonusType.ALL:
                prefabSprite = objt.FirstOrDefault(o => o.name == ("PREFAB_BONUS_BOMB")).sprite;
                break;
        }

        return prefabSprite;
    }

    internal override bool IsSameType(Item other)
    {
        BonusItem it = other as BonusItem;

        return it != null && it.ItemType == this.ItemType;
    }

    internal override void ExplodeView()
    {
        ActivateBonus();

        base.ExplodeView();
    }

    private void ActivateBonus()
    {
        switch (ItemType)
        {
            case eBonusType.HORIZONTAL:
                ExplodeHorizontalLine();
                break;
            case eBonusType.VERTICAL:
                ExplodeVerticalLine();
                break;
            case eBonusType.ALL:
                ExplodeBomb();
                break;

        }
    }

    private void ExplodeBomb()
    {
        List<Cell> list = new List<Cell>();
        if (Cell.NeighbourBottom) list.Add(Cell.NeighbourBottom);
        if (Cell.NeighbourUp) list.Add(Cell.NeighbourUp);
        if (Cell.NeighbourLeft)
        {
            list.Add(Cell.NeighbourLeft);
            if (Cell.NeighbourLeft.NeighbourUp)
            {
                list.Add(Cell.NeighbourLeft.NeighbourUp);
            }
            if (Cell.NeighbourLeft.NeighbourBottom)
            {
                list.Add(Cell.NeighbourLeft.NeighbourBottom);
            }
        }
        if (Cell.NeighbourRight)
        {
            list.Add(Cell.NeighbourRight);
            if (Cell.NeighbourRight.NeighbourUp)
            {
                list.Add(Cell.NeighbourRight.NeighbourUp);
            }
            if (Cell.NeighbourRight.NeighbourBottom)
            {
                list.Add(Cell.NeighbourRight.NeighbourBottom);
            }
        }

        for (int i = 0; i < list.Count; i++)
        {
            list[i].ExplodeItem();
        }
    }

    private void ExplodeVerticalLine()
    {
        List<Cell> list = new List<Cell>();

        Cell newcell = Cell;
        while (true)
        {
            Cell next = newcell.NeighbourUp;
            if (next == null) break;

            list.Add(next);
            newcell = next;
        }

        newcell = Cell;
        while (true)
        {
            Cell next = newcell.NeighbourBottom;
            if (next == null) break;

            list.Add(next);
            newcell = next;
        }


        for (int i = 0; i < list.Count; i++)
        {
            list[i].ExplodeItem();
        }
    }

    private void ExplodeHorizontalLine()
    {
        List<Cell> list = new List<Cell>();

        Cell newcell = Cell;
        while (true)
        {
            Cell next = newcell.NeighbourRight;
            if (next == null) break;

            list.Add(next);
            newcell = next;
        }

        newcell = Cell;
        while (true)
        {
            Cell next = newcell.NeighbourLeft;
            if (next == null) break;

            list.Add(next);
            newcell = next;
        }


        for (int i = 0; i < list.Count; i++)
        {
            list[i].ExplodeItem();
        }

    }
}
