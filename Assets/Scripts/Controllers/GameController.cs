using UnityEngine;
using UnityEngine.UI;

public class GameController: MonoBehaviour
{
    private int catPoints = 0;
    private int sealPoints = 0;

    public Text catDisplay;
    public Text sealDisplay;




    public int CatPoints
    {
        get { return catPoints; }
        set { catDisplay.text = value.ToString(); }

    }

    public int SealPoints
    {
        get { return sealPoints; }
        set {
            sealDisplay.text = value.ToString();

        }
    }

    public void IncrementCatPoints(int amount)
    {
        catPoints += amount;
        catDisplay.text = catPoints.ToString();
        BumperController.SpawnRandomObs();

        Debug.Log("Cat points: " + CatPoints);
    }

    public void IncrementSealPoints(int amount)
    {
        sealPoints += amount;
        sealDisplay.text = sealPoints.ToString();
        BumperController.SpawnRandomObs();


        Debug.Log("Seal points: " + SealPoints);

    }
}
