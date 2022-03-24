using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideSliderController : MonoBehaviour
{

    public Slider[] sliders;
    public GameObject losePanel;

    GameObject[] player;
    public GameObject[] itens;

    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");

        ShowSlider(0);
        CallSliderCoroutine(0);
    }

    void Update()
    {
        
    }

    public void addFill(int sliderIndex){
        if(sliderIndex == 0){
            sliders[0].value += 0.3f;
        } else if(sliderIndex == 1){
            sliders[1].value += 0.3f;
        } else if(sliderIndex == 2){
            sliders[2].value += 0.3f;
        }
    }

    public void CallSliderCoroutine(int sliderIndex){
        StartCoroutine(SliderController(sliders[sliderIndex]));
    }

    IEnumerator SliderController(Slider slider){
        while(slider.value > 0){
            yield return new WaitForSeconds (0.2f);
            slider.value -= 0.003f;
        }
        losePanel.SetActive(true);
        for (int i = 0; i <itens.Length;i++){
            Destroy(itens[i]);
        }
        Destroy(player[0].GetComponent<SpriteRenderer>());
    }

    public void HideSlider(int sliderIndex){
        sliders[sliderIndex].gameObject.SetActive(false);
    }
    public void ShowSlider(int sliderIndex){
        sliders[sliderIndex].gameObject.SetActive(true);
    }
}


