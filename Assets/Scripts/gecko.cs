using UnityEngine;

public class gecko : Animal
{

    
    protected override void Start()
    {
        base.Start();
        speed = 3.0f;  // Velocidade específica para Animal1
        alimento = "legume";
    }
    

    

}