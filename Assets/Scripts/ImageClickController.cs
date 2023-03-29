using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageClickController : MonoBehaviour
{
    public Button button1Des;
    public Button button2Des;

    public Button button1Apc;
    public Button button2Apc;

    private bool state = false;
    private string nomButton = "";

    void Start(){
    button1Apc.gameObject.SetActive(false);
    button2Apc.gameObject.SetActive(false);
    }

    public void OnClickButton1(Button buttondes){
        Debug.Log("Se ha hecho clic en el" + buttondes.name);
        nomButton = buttondes.name;
        state = true;
    }

    public void OnClickButton2(){
        if (state){
            switch(nomButton){
                case "LevelBtn":
                    button1Apc.gameObject.SetActive(true);
                break;
                case "LevelBtn (1)":
                    button2Apc.gameObject.SetActive(true);
                break;
            }
            state = false;
            nomButton = "";
        }
    }
}
