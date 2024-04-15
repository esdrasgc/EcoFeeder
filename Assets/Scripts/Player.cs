using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    public GameObject[] projectilePrefab ; // Prefab do objeto que o jogador vai lançar
    public Animator playerAnimator;
    public int selecionado = 0;
     public float projectileSpeed = 20.0f; 
    private Vector3 playerVelocity;
    public float playerSpeed = 2.0f;
    private float yValue;

    private Vector3 look_direction;

    private int numberHiyts = 0;

    private Rigidbody rb;

    private Boolean playerIsDead = false;

    public String[] animalTags = {"Colobus", "Herring", "Padu", "Sparrow", "Muskrat", "Gecko"};

 void LaunchProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab[selecionado], transform.position + transform.forward, transform.rotation);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        if (projectileRb != null)
        {
            projectileRb.velocity = transform.forward * projectileSpeed;
        }
    }
    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        yValue = transform.position.y;
        look_direction = Vector3.forward;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    
    

    void Update()
    {
        if (playerIsDead) return;
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = move.normalized;
         if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchProjectile();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            if(selecionado == projectilePrefab.Length - 1){
                selecionado = 0;
            }else{
                selecionado++;
            }
        
        }
      
       

        if (move != Vector3.zero)
        {
            controller.Move(move * Time.deltaTime * playerSpeed);
            look_direction = move;
            gameObject.transform.forward = move;
            if (!playerAnimator.GetBool("PlayerIsMoving")) playerAnimator.SetBool("PlayerIsMoving", true);
        }
        else{
            if (playerAnimator.GetBool("PlayerIsMoving")) playerAnimator.SetBool("PlayerIsMoving", false);
            // gameObject.transform.LookAt(look_direction);
            gameObject.transform.forward = look_direction;
          
        }
        
    }

    private void OnCollisionEnter(Collision other) {
        for (int i = 0; i < animalTags.Length; i++)
        {

                if (other.gameObject.tag == animalTags[i])
                {

                // numberHiyts++;
                // Debug.Log("Number of hits: " + numberHiyts);
                print("Player is dead");
                if(!playerAnimator.GetBool("PlayerIsDead")) 
                {
                    print("animating");
                    playerAnimator.SetBool("PlayerIsDead", true);
                    playerAnimator.SetBool("PlayerIsMoving", false);
                    // start coroutine to wait for animation to finish and then destroy player
                    StartCoroutine(WaitForAnimation());
                }
            }

            i++;
        }
    }

    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(2.0f);
        gameObject.SetActive(false);
    }
}