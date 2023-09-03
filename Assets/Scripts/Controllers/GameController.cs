using UnityEngine;

public static class GameController
{
    private static int catPoints = 0;
    private static int sealPoints = 0;

    public static int CatPoints
    {
        get { return catPoints; }
    }

    public static int SealPoints
    {
        get { return sealPoints; }
    }

    public static void IncrementCatPoints(int amount)
    {
        catPoints += amount;
        Debug.Log("Cat points: " + CatPoints);
    }

    public static void IncrementSealPoints(int amount)
    {
        sealPoints += amount;
        Debug.Log("Seal points: " + SealPoints);

    }
}
