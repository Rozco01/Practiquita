using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageClickController : MonoBehaviour
{
    public Button button1;
    public Button button2;
    private bool state = false;

    void Start(){
    button2.gameObject.SetActive(false);
    }

    public void OnClickButton1(){
        Debug.Log("Se ha hecho clic en el botón 1.");
        state = true;
    }

    public void OnClickButton2(){
        Debug.Log("Se ha hecho clic en el botón 2.");
        if(state){
            button2.gameObject.SetActive(true);
            Destroy(button1.gameObject, 0.5f);
            state = false;
            Debug.Log(state);
        }
    }   
}
