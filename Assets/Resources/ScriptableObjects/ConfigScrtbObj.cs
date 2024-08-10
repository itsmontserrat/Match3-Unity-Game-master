using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConfigScrtbObj", menuName = "ConfigScrtbObj")]
public class ConfigScrtbObj : ScriptableObject
{
    public List<Object> normalObj;
    public List<Object> fishObj;
    public GameObject prefab;
    public List<BonusObject> bonusObj;

}

[Serializable]
public class Object 
{
    public ObjName name;
    public Sprite sprite;

}

public enum ObjName
{
     PREFAB_NORMAL_TYPE_ONE,
     PREFAB_NORMAL_TYPE_TWO,

    PREFAB_NORMAL_TYPE_THREE,

     PREFAB_NORMAL_TYPE_FOUR,

     PREFAB_NORMAL_TYPE_FIVE,

    PREFAB_NORMAL_TYPE_SIX,

     PREFAB_NORMAL_TYPE_SEVEN
}

[Serializable]
public class BonusObject
{
    public string name;
    public Sprite sprite;

}