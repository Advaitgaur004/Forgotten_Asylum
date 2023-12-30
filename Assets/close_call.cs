using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close_call : StateMachineBehaviour
{
    public string gunShootAnimation = "shoots gun_2"; // Set the name of the gun shoot animation
    public string swordAttackAnimation = "sword attack"; // Set the name of the sword attack animation
    public float triggerDistance = 1.0f; // Set the distance threshold for triggering animations

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Code to execute when the state is entered

        // Get references to the player and enemy
        Transform player = GameObject.FindWithTag("sample_target").transform;
        Transform enemy = animator.transform;

        // Calculate the distance between the player and the enemy
        float distance = Vector3.Distance(player.position, enemy.position);

        // Trigger animations based on distance
        if (distance <= triggerDistance)
        {
            animator.SetTrigger(gunShootAnimation);
            animator.SetTrigger(swordAttackAnimation);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Code to execute on each update frame while in the state
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Code to execute when exiting the state
    }
}
