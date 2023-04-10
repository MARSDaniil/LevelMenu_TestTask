using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelTable : MonoBehaviour
{
    private static readonly string StarCount = "StarCount";
    private static readonly string FirstPlay = "FirstPlay";


    //public Button[] LevelsGameObject;
    public GameObject[] LevelsGameObject;
    private Level[] LevelsData;

    public int summOfStars;

    public Text countOfStars;

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
        Debug.Log("u enter to save ");
        PlayerPrefs.SetInt(StarCount, summOfStars);
        if (PlayerPrefs.GetInt(FirstPlay) == 0)
        {
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
    }

    private void LateUpdate()
    {
       // countOfStars.text = summOfStars.ToString();
   //     countOfStars.text = LevelsData[0].countOfStar.ToString();
    }

    private void GetStartDataFromLevels()
    {
        for (int i = 0; i < LevelsGameObject.Length; i++)
        {
           // LevelsData[i] = LevelsGameObject[i].GetComponent<Level>();
            LevelsData[i] = LevelsGameObject[i].gameObject.GetComponent<Level>();
            if (LevelsData[i] != null)
            {
                Debug.Log("LevelData[" + i + "] = not null");
            }
            
            //Debug.Log("count of Star = " + LevelsData[i].countOfStar);
        }
    }
}
