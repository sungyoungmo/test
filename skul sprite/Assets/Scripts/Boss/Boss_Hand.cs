using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Hand : MonoBehaviour
{
    public static Boss_Hand instance;

    readonly int Attack = Animator.StringToHash("Attack");
    readonly int Slide = Animator.StringToHash("Slide");
    readonly int Magic = Animator.StringToHash("Magic");


    public GameObject Left_Hand;
    public GameObject Right_Hand;
    GameObject chosenHand;

    Vector2 startPosition;
    Vector2 settingPosition;
    Vector2 EndPosition;

    bool isSetting = false;
    bool move = false;

    float moveDuration = 2.0f;
    float elapsedTime = 0.0f;





    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        startPosition = this.transform.position;

        Left_Hand.GetComponent<BoxCollider2D>().enabled = false;
        Right_Hand.GetComponent<BoxCollider2D>().enabled = false;

    }


    void FixedUpdate()
    {
        
        if (move)
        {

            elapsedTime += Time.deltaTime;
            float t = elapsedTime / moveDuration;

            if (chosenHand == Right_Hand)
            {
                if (!isSetting)
                {
                    Right_Hand.transform.position = Vector2.Lerp(startPosition, settingPosition, t);
                    Left_Hand.transform.position = Vector2.Lerp(-startPosition, -settingPosition, t);

                    if (Vector2.Distance(Right_Hand.transform.position, settingPosition) < 0.01f || t >= 1.0f)
                    {
                        isSetting = true;
                        elapsedTime = 0.0f;
                    }

                }
                else
                {
                    Right_Hand.transform.position = Vector2.Lerp(settingPosition, EndPosition, t);

                    Right_Hand.GetComponent<BoxCollider2D>().enabled = true;


                    if (Vector2.Distance(Right_Hand.transform.position, EndPosition) < 0.01f || t >= 1.0f)
                    {
                        elapsedTime = 0.0f;
                        isSetting = false;
                        move = false;
                    }
                }

            }
            else
            {
                if (!isSetting)
                {
                    Left_Hand.transform.position = Vector2.Lerp(startPosition, settingPosition, t);
                    Right_Hand.transform.position = Vector2.Lerp(-startPosition, -settingPosition, t);
                    

                    if (Vector2.Distance(Left_Hand.transform.position, settingPosition) < 0.01f || t >= 1.0f)
                    {
                        isSetting = true;
                        elapsedTime = 0.0f;
                    }

                }
                else
                {
                    Left_Hand.transform.position = Vector2.Lerp(settingPosition, EndPosition, t);

                    Left_Hand.GetComponent<BoxCollider2D>().enabled = true;

                    if (Vector2.Distance(Left_Hand.transform.position, EndPosition) < 0.01f || t >= 1.0f)
                    {
                        elapsedTime = 0.0f;
                        isSetting = false;
                        move = false;
                    }
                }
            }
        }
        else
        {
            Left_Hand.GetComponent<BoxCollider2D>().enabled = false;
            Right_Hand.GetComponent<BoxCollider2D>().enabled = false;

            Left_Hand.transform.position = new Vector2(5, 0);
            Right_Hand.transform.position = new Vector2(-5, 0);
        }

    }

    public void Hand_Choose()
    {
        int randValue = Random.Range(1, 3);

        switch (randValue)
        {
            case 1:
                chosenHand = Right_Hand;
                startPosition = Right_Hand.transform.position;
                settingPosition = new Vector2(-20, 0);
                EndPosition = new Vector2(18, 0);


                break;
            case 2:
                chosenHand = Left_Hand;
                startPosition = Left_Hand.transform.position;
                settingPosition = new Vector2(20, 0);
                EndPosition = new Vector2(-18, 0);


                break;
            default:
                break;
        }

        StartCoroutine(HandMotion());
    }

    IEnumerator HandMotion()
    {
        move = true;

        Right_Hand.GetComponent<Animator>().SetBool(Slide, true);
        Left_Hand.GetComponent<Animator>().SetBool(Slide, true);

        yield return new WaitForSeconds(4.0f);

        Right_Hand.GetComponent<Animator>().SetBool(Slide, false);
        Left_Hand.GetComponent<Animator>().SetBool(Slide, false);

        move = false;

    }


    


}
