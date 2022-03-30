using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float angleZ;

    public float translationForce = 1.0f;
    public float rotationForce = 100.0f;

    SpriteRenderer spriteRenderer;
    public Sprite[] playerSprites;
    public int type = 0;
    public int helperType = 0;
    public int level;

    void Start(){
         rb = GetComponent<Rigidbody2D>();
         spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update(){
        Move();

        if(type >= 0 ){
            if(level > 1){
                if (Input.GetKeyDown("e")){
                    ChangePlayer(0);
                }else if (Input.GetKeyDown("r")){
                    ChangePlayer(2);
                }else if (Input.GetKeyDown("t")){
                    ChangePlayer(4);
                }
            }
        }
    }

    void Move(){
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * translationForce;

        float rotation = Input.GetAxis("Horizontal") * rotationForce * -1;
        if(Input.GetAxis("Vertical")<0){
            //rotation *= -1;
        }


        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis

        //transform.Translate(0, translation, 0);
        rb.AddForce(transform.up * translation);
        float maxSpeed = 10;
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        // Rotate around our y-axis
        //transform.Rotate(0, 0, rotation);
        rb.AddTorque(rotation);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        angleZ = Quaternion.Angle(Quaternion.Euler(new Vector3(0,0,0)),transform.rotation);
        //float angleZ = this.transform.eulerAngles.z;
        //Debug.Log("JOAO " + angleZ);

    }

    public void ChangePlayer(int helper){
        //int helperType = 0;
        if (helper == 0){
            spriteRenderer.sprite = playerSprites[0];
            type = 0;
        }else if (helper == 2){
            spriteRenderer.sprite = playerSprites[1];
            type = 1;
        }else if (helper == 4){
            spriteRenderer.sprite = playerSprites[2];
            type = 2;
        }else if (helper == -1){
            spriteRenderer.sprite = playerSprites[type + 3];
            helperType = type;
            type = -1;
        }else if(helper == -2){
            type = helperType;
            spriteRenderer.sprite = playerSprites[type];
        }
    }

    void OnCollision2D(Collision2D other){
        PushObjects(other);
    }

    void PushObjects(Collision2D other){
        Vector3 forceDirection = other.gameObject.transform.position - transform.position;
        forceDirection.y = 0;
        forceDirection.Normalize();
        Rigidbody2D otherRB = other.gameObject.GetComponent<Rigidbody2D>();
        otherRB.AddForceAtPosition(forceDirection*3,transform.position,ForceMode2D.Impulse);
    }

}
