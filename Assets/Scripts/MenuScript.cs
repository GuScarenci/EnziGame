using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void LoadMenuScene(){
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void LoadGameScene(){
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    public void ExitGame(){
        Application.Quit();
    }    
}
