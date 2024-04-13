using UnityEngine;
using UnityEngine.UI;
// Alan: Ainda não consegui usar no unity esse código.
public class PlayerShooting : MonoBehaviour
{
    public GameObject[] projectiles;  // Array dos prefabs dos tiros
    public Transform shootingPoint;  // Ponto de onde os tiros serão lançados
    public Text colorIndicator;  // Referência ao Texto UI do indicador de cor

    private int currentProjectileIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))  // Trocar para a cor anterior
        {
            currentProjectileIndex--;
            if (currentProjectileIndex < 0)
                currentProjectileIndex = projectiles.Length - 1;
            UpdateColorIndicator();
        }

        if (Input.GetKeyDown(KeyCode.H))  // Trocar para a próxima cor
        {
            currentProjectileIndex++;
            if (currentProjectileIndex >= projectiles.Length)
                currentProjectileIndex = 0;
            UpdateColorIndicator();
        }

        if (Input.GetKeyDown(KeyCode.Space))  // Atirar
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(projectiles[currentProjectileIndex], shootingPoint.position, Quaternion.identity);
    }

    void UpdateColorIndicator()
    {
        colorIndicator.text = projectiles[currentProjectileIndex].name;  // Assumindo que o nome do prefab é a cor
    }

    void Start()
    {
        UpdateColorIndicator();  // Inicializar o indicador de cor ao iniciar
    }
}
