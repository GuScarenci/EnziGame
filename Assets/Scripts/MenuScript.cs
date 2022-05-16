using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public static bool teacherIsEnabled = true;
    public static float volumeMusic = 0f;
    public static float volumeGame = 0f;
    
    public Slider volumeMusicController;
    public Slider volumeGameController;
    public GameObject teacherToogle;

    void Start(){
        if ((SceneManager. GetActiveScene () == SceneManager. GetSceneByName ("Menu"))){
            teacherToogle.GetComponent<Toggle>().isOn = teacherIsEnabled;

            volumeMusicController.value = volumeMusic;
            volumeGameController.value = volumeGame;
            FindObjectOfType<AudioManager>().Play("Thermal");

        }
    }
    public void LoadMenuScene(){
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void LoadGameScene(){
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void SetTeacher(){
        teacherIsEnabled = !teacherIsEnabled; 
    }
    public void SetVolumeMusic(){
        volumeMusic = volumeMusicController.value;
        FindObjectOfType<AudioManager>().AudioAdjust();
    }
    public void SetVolumeGame(){
        volumeGame = volumeGameController.value;
        FindObjectOfType<AudioManager>().AudioAdjust();
    }
}
