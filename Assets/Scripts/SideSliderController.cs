using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideSliderController : MonoBehaviour
{

    public Slider[] sliders;
    public GameObject losePanel;

    public GameObject[] player;
    public GameObject[] itens;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");

        for(int i = 0;i<=2;i++){
            StartCoroutine(SliderController(sliders[i]));
        }
    }

    // Update is called once per frame
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
}


