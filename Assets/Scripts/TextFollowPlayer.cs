using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;  // Referência ao Transform do jogador
    public Vector3 offset = new Vector3(0, 2, 0);  // Offset para posicionar o texto acima do jogador

    void Update()
    {
        if (player != null)
        {
            // Calcula a nova posição baseada na posição do jogador e aplica o offset
            Vector3 newPos = player.position + offset;
            newPos.y = transform.position.y;  // Mantém a altura do texto constante, ignorando a altura do jogador
            transform.position = newPos;
        }
    }
}
