using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using URandom = UnityEngine.Random;

public class Utils
{
    public static NormalItem.eNormalType GetRandomNormalType()
    {
        Array values = Enum.GetValues(typeof(NormalItem.eNormalType));
        NormalItem.eNormalType result = (NormalItem.eNormalType)values.GetValue(URandom.Range(0, values.Length));

        return result;
    }

    public static NormalItem.eNormalType GetRandomNormalTypeExcept(NormalItem.eNormalType[] types)
    {
        List<NormalItem.eNormalType> list = Enum.GetValues(typeof(NormalItem.eNormalType)).Cast<NormalItem.eNormalType>().Except(types).ToList();

        int rnd = URandom.Range(0, list.Count);
        NormalItem.eNormalType result = list[rnd];

        return result;
    }

    public static FishItem.eFishType GetRandomFishTypeExcept(FishItem.eFishType[] types)
    {
        List<FishItem.eFishType> list = Enum.GetValues(typeof(FishItem.eFishType)).Cast<FishItem.eFishType>().Except(types).ToList();

        int rnd = URandom.Range(0, list.Count);
        FishItem.eFishType result = list[rnd];

        return result;
    }

    public static FishItem.eFishType GetRandomFishType()
    {
        Array values = Enum.GetValues(typeof(FishItem.eFishType));
        FishItem.eFishType result = (FishItem.eFishType)values.GetValue(URandom.Range(0, values.Length));

        return result;
    }
}
