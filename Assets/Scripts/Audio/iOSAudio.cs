using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iOSAudio : MonoBehaviour
{


#if UNITY_IOS


 private bool isTought;

    private void Start()
    {
        isTought = false;
    }

    private void Update()
    {
        if(isTought == false)
        {
            if(Input.touchCount > 0)
            {
                 AudioListener.volume = 1f;
            }
        }
    }


#endif
}
