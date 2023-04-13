using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public string maxStarOfLevel;
    public string FirstPlay;
    public int countOfStar;
    public int countOfLevel;

    


    public GameObject ZeroStars;
    public GameObject TwoStars;
    public GameObject ThreeStars;
    public void Start()
    {   
        int firstPlay;
        firstPlay = PlayerPrefs.GetInt(FirstPlay);
        if (firstPlay == 0)
        {
            countOfStar = 0;
            
        }
        else
        {
            
            countOfStar = PlayerPrefs.GetInt(maxStarOfLevel);
        }
    //    SaveStarCount();
        SetStarPrefab();
    }

    private void SaveStarCount()
    {
   //     Debug.Log("u enter to save ");
        PlayerPrefs.SetInt(maxStarOfLevel, countOfStar);
        if (PlayerPrefs.GetInt(FirstPlay) == 0)
        {
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
    }

    private void SetStarPrefab()
    {

        switch (countOfStar)
        {
            case (0):
             //    Debug.Log("start count of stars(0) " + countOfStar);

                ZeroStars.SetActive(true);
                TwoStars.SetActive(false);
                ThreeStars.SetActive(false);
                return;
            case (2):
          //      Debug.Log("start count of stars(2) " + countOfStar);

                ZeroStars.SetActive(false);
                TwoStars.SetActive(true);
                ThreeStars.SetActive(false);
                return;
            case (3):
          //      Debug.Log("start count of stars(3) " + countOfStar);

                ZeroStars.SetActive(false);
                TwoStars.SetActive(false);
                ThreeStars.SetActive(true);
                return;
        }
    }

    //if touch botton
    public void StarGenerated()
    {
    //    Debug.Log("Old count of star = " + countOfStar);
        int star = Random.Range(2, 4);
        if (star > countOfStar)
        {
            countOfStar = star;

            switch (star)
            {
                case (2):
                    countOfStar = 2;
          //          Debug.Log("new Count of star = (2) " + countOfStar);

                    ZeroStars.SetActive(false);
                    TwoStars.SetActive(true);
                    SaveStarCount();
                    return;
                case (3):
                    countOfStar = 3;
             //       Debug.Log("new Count of star = (3) " + countOfStar);

                    ZeroStars.SetActive(false);
                    TwoStars.SetActive(false);
                    ThreeStars.SetActive(true);
                    SaveStarCount();
                    return;
            }
            
            
        }
    }

 
}
