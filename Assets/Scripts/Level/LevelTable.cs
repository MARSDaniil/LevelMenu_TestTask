using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelTable : MonoBehaviour
{
    public string StarCount;
    private static readonly string FirstPlay = "FirstPlay";

    private static readonly int LenghtOfArr = 8; // количество уровней на данном экране
    private static readonly int nextLevelStarCount = 20; //количество звезд которое должно быть для открытия следуюшего уровня

    //public Button[] LevelsGameObject;
    public GameObject[] LevelsGameObject = new GameObject[LenghtOfArr];
    private Level[] LevelsData = new Level[LenghtOfArr];

    public int summOfStars;

    public Text countOfStarsText;//вывод количества звезд
    public GameObject OpenNextTable;
    public GameObject CloseNextTable;
    public Button NextTableBotton;

    private void Start()
    {
        GetStartDataFromLevels(); //взятие начальных данных  


        int firstPlay;
        firstPlay = PlayerPrefs.GetInt(FirstPlay);
        if (firstPlay == 0)
        {
            SwitcherBottons(CloseNextTable,OpenNextTable);
            
            summOfStars = 0;

        }
        else
        {
            summOfStars = PlayerPrefs.GetInt(StarCount);
        }
        NextTableBotton.interactable = false;
        UpdateStarCount();


    }


    private void SwitcherBottons(GameObject TurnOn, GameObject TurnOff) //смена значков закрытого и открытого
    {
        TurnOn.SetActive(true);
        TurnOff.SetActive(false);
    }
    private void SaveStarCount()//сохранялка
    {
       // Debug.Log("u enter to save ");
        PlayerPrefs.SetInt(StarCount, summOfStars);
        if (PlayerPrefs.GetInt(FirstPlay) == 0)
        {
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
    }

  

    private void GetStartDataFromLevels() //взятие начальных данных из уровней
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

    public void UpdateStarCount()//обновление звезд
    {
        int countOfStarLocal = 0;
        for (int i = 0; i < LevelsGameObject.Length; i++)
        {
            countOfStarLocal += LevelsData[i].countOfStar;
            //Debug.Log(i + " " + LevelsData[i].countOfStar);
        }
        if(countOfStarLocal >= nextLevelStarCount)
        {
            SwitcherBottons(OpenNextTable,CloseNextTable);
            NextTableBotton.interactable = true;
        }
        summOfStars = countOfStarLocal;
      //  Debug.Log("sum = " + countOfStarLocal);
        SaveStarCount();
        ShowText();
    }

    private void ShowText()
    {
        countOfStarsText.text = summOfStars.ToString() + "/20";
    }
}
