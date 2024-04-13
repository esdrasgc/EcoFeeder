using UnityEngine;

public class colobus : Animal
{
    protected override void Start()
    {
        base.Start();
        speed = 3.0f;  // Velocidade específica para Animal1
        // teste rotacionando na direção do player 
        transform.LookAt(playerTransform);


    }

    

}