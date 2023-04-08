using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Switcher : MonoBehaviour
{
    public  GameObject buttonOn;
    public  GameObject buttonOff;


    private void Start()
    {
        if (buttonOn == null)
        {
            buttonOn = GetComponent<GameObject>();
        }
    }
    public void TurnOff()
    {
        if (buttonOff != null)
        {
            buttonOff.SetActive(false);
        }
        else
        {
            Debug.LogWarning("buttonOff = 0");
        }
    }

    public void TurnOn()
    {
        if (buttonOn != null)
        {
            buttonOn.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("buttonOn = 0");
        }
    }

}
