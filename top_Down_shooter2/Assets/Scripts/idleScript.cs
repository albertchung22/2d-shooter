using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleScript : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(PlayerCombat.instance.isAttacking)
        {
            PlayerCombat.instance.myAnim.Play("atk1");
        }

        if (PlayerCombat.instance.isTaunting)
        {
            PlayerCombat.instance.myAnim.Play("taunt");
        }

        if (PlayerMovement.instance.isWalking)
        {
            PlayerCombat.instance.myAnim.Play("walk");
        }

        if (PlayerCombat.instance.SwayForward)
        {
            PlayerCombat.instance.myAnim.Play("sway_f");
        }

        if (PlayerCombat.instance.SwayBackward)
        {
            PlayerCombat.instance.myAnim.Play("sway_b");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerCombat.instance.isAttacking = false;
        PlayerCombat.instance.isTaunting = false;
        PlayerMovement.instance.isWalking = false;
        PlayerCombat.instance.SwayForward = false;
        PlayerCombat.instance.SwayBackward = false;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
