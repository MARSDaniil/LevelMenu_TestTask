using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelTable : MonoBehaviour
{
    private static readonly string StarCount = "StarCount";
    private static readonly string FirstPlay = "FirstPlay";

    private static readonly int LenghtOfArr = 8;

    //public Button[] LevelsGameObject;
    public GameObject[] LevelsGameObject = new GameObject[LenghtOfArr];
    private Level[] LevelsData = new Level[LenghtOfArr];

    public int summOfStars;

    public Text countOfStarsText;

    private void Start()
    {
        int firstPlay;
        firstPlay = PlayerPrefs.GetInt(FirstPlay);
        if (firstPlay == 0)
        {
            summOfStars = 0;

        }
        else
        {

            summOfStars = PlayerPrefs.GetInt(StarCount);
        }
        SaveStarCount();


        GetStartDataFromLevels(); //взятие начальных данных  
    }

    private void SaveStarCount()
    {
       // Debug.Log("u enter to save ");
        PlayerPrefs.SetInt(StarCount, summOfStars);
        if (PlayerPrefs.GetInt(FirstPlay) == 0)
        {
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
    }

    private void LateUpdate()
    {
     //   UpdateStarCount();
      //  countOfStarsText.text = summOfStars.ToString();
        //     countOfStars.text = LevelsData[0].countOfStar.ToString();
    
    }

    private void GetStartDataFromLevels()
    {
        for (int i = 0; i < LevelsGameObject.Length; i++)
        {
           // LevelsData[i] = LevelsGameObject[i].GetComponent<Level>();
            LevelsData[i] = LevelsGameObject[i].gameObject.GetComponent<Level>();
            if (LevelsData[i] == null)
            {
                Debug.LogError("LevelData[" + i + "] == null");
            }
            
            //Debug.Log("count of Star = " + LevelsData[i].countOfStar);
        }
    }

    public void UpdateStarCount()
    {
        int countOfStarLocal = 0;
        for (int i = 0; i < LevelsGameObject.Length; i++)
        {
            countOfStarLocal = countOfStarLocal + LevelsData[i].countOfStar;
        }

        summOfStars = countOfStarLocal;
        SaveStarCount();
        countOfStarsText.text = summOfStars.ToString() + "/20";
    }
}
