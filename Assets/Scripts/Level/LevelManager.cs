using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
[SerializeField]
public class LevelTable
{
    
   
    public static int countOfLevel;
    public int countOfStars;
    public int startsForNextTable;

    Level[] levels = new Level[countOfLevel];
    public GameObject[] LevelsOfTable;

    private void setCountOfLevel()
    {
        for(int i = 0; i < levels.Length; i++)
        {
            levels[i].countOfLevel = i;
        }
    }

}
*/
[System.Serializable]
public class A
{
    public int k;
}
[System.Serializable] 
public class Level: MonoBehaviour
{
    public string maxStarOfLevel = "MaxStar";
    public string FirstPlay = "FirstPlay";
    public int countOfStar;
    public int countOfLevel;

    private int firstPlay;


    public GameObject ZeroStars;
    public GameObject TwoStars;
    public GameObject ThreeStars;
    public void SetStartSetting()
    {
        firstPlay = PlayerPrefs.GetInt(FirstPlay);
        if(firstPlay == 0)
        {
            countOfStar = 0;
            PlayerPrefs.SetInt(maxStarOfLevel, countOfStar);
        }   
        else
        {
            countOfStar = PlayerPrefs.GetInt(maxStarOfLevel);
        }
    }

    //if touch botton
    public void StarGenerated()
    {
        Debug.Log("Old count of star = " + countOfStar);
        int star = Random.Range(2, 4);
        if(star > countOfStar)
        {
            countOfStar = star;
            
            switch(star)
                {
                case (2):
                    countOfStar = 2;
                    Debug.Log("new Count of star = (2) " + countOfStar);

                    ZeroStars.SetActive(false);
                    TwoStars.SetActive(true);
                    return;
                case (3):
                    countOfStar = 3;
                    Debug.Log("new Count of star = (3) " + countOfStar);

                    ZeroStars.SetActive(false);
                    TwoStars.SetActive(false);
                    ThreeStars.SetActive(true);
                    return;
            }

        }
    }
}

public class LevelManager : MonoBehaviour
{
    public int lalal; 
    Level level = new Level();


    public void Touch()
    {
        level.StarGenerated();
    }

}
