using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorativeMovement : MonoBehaviour
{
    public float speed;

    void Start()
    {
        StartCoroutine(Fade());
    }
    void Update()
    {
        transform.position += transform.up * (Time.deltaTime * speed);
    }
    IEnumerator Fade(){
        Color c = GetComponent<Renderer>().material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.05f)
        {
            c.a = alpha;
            GetComponent<Renderer>().material.color = c;
            yield return new WaitForSeconds(0.2f);
        }
        Destroy(this);
    }
}
