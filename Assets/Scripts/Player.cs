using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Animator from Player Object")]
    public Animator Animator;

    [Header("Sprite Renderer from Sprite Object")]
    public SpriteRenderer PlayerSprite;

    void Update()
    {
        //Detects input from left/right arrow or "A" or "D" keys
        float walkSpeed = Input.GetAxisRaw("Horizontal");

        //Gets transform component from the object this script is attached to
        transform.position += new Vector3(walkSpeed * Time.deltaTime, 0, 0);

        /**
         * If the player walks, the walk animation will play and flip the sprite if the player switch directions.
         * If the player stops moving, the idle animation will play
         */
        if (walkSpeed != 0)
        {
            Animator.Play("Walk");

            if (walkSpeed > 0)
            {
                PlayerSprite.flipX = false;
            }
            else
            {
                PlayerSprite.flipX = true;
            }
        }
        else
        {
            Animator.Play("Idle");
        }
    }
}
