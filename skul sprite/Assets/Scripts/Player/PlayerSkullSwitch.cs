using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkullSwitch : MonoBehaviour
{
    public static PlayerSkullSwitch instance;

    public RuntimeAnimatorController samuraiAnimatorController;
    public RuntimeAnimatorController LittleBoneAnimatorController;

    private Animator playerAnimator;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        samuraiAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimController/Samurai_Controller");
        LittleBoneAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimController/LittleBone_Controller");

        playerAnimator = GetComponent<Animator>();
    }


    public void Switch()
    {
        if (playerAnimator.runtimeAnimatorController == samuraiAnimatorController)
        {
            playerAnimator.runtimeAnimatorController = LittleBoneAnimatorController;
        }
        else
        {
            playerAnimator.runtimeAnimatorController = samuraiAnimatorController;
        }
    }
}
