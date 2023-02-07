using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Animator from Player Object")]
    public Animator PlayerAnimator;

    [SerializeField] 
    private float moveSpeed;

    private float animationSpeed;

    void Update()
    {
        //Detects input from arrow keys or WASD keys
        float xInput = Input.GetAxisRaw("Horizontal");

        if (xInput > 0)
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 90f, 0f), Time.deltaTime * 4f);
        }
        else if (xInput < 0)
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, 270f, 0f), Time.deltaTime * 4f);
        }
        
        transform.position += new Vector3(xInput * moveSpeed * Time.deltaTime, 0f, 0f);

        animationSpeed = Mathf.Lerp(animationSpeed, xInput, Time.deltaTime * 0.5f);

        PlayerAnimator.SetFloat("MoveSpeed", Mathf.Abs(animationSpeed));
    }
}
