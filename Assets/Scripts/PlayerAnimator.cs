using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking"; //to make sure there is no mistake in string later

    [SerializeField] private PlayerController player; //referencinf the other script where isWalking is present
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>(); //referencing animator component
    }

    private void Update()
    {
        animator.SetBool(IS_WALKING, player.IsWalking()); //now with const we get an error if we type the string incorrectly
    }
}
