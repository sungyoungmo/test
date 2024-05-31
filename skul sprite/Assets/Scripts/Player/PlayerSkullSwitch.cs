using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkullSwitch : MonoBehaviour
{
    public static PlayerSkullSwitch instance;

    public RuntimeAnimatorController samuraiAnimatorController;
    public RuntimeAnimatorController knightAnimatorController;

    private Animator playerAnimator;

    void Awake()
    {
        instance = this;
        samuraiAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimController/Samurai_Controller");
        knightAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimController/LittleBone_Controller");

        playerAnimator = GetComponent<Animator>();
    }


    public void Switch()
    {
        if (playerAnimator.runtimeAnimatorController == samuraiAnimatorController)
        {
            playerAnimator.runtimeAnimatorController = knightAnimatorController;
        }
        else
        {
            playerAnimator.runtimeAnimatorController = samuraiAnimatorController;
        }
    }
}
