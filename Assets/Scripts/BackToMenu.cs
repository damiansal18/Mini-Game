using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{

    public GUISkin myskin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnGUI()
    {
        GUI.skin = myskin;

        if (GUI.Button(new Rect(40, 40, 200, 100), "Menu"))
        {
            Application.LoadLevel(2);
        }
    }
}
