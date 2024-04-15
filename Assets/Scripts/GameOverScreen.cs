using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameOverScreen : MonoBehaviour
{

    public TextMeshProUGUI  pointsText;

    public void Setup(int score)
    {

        pointsText.text = "You fed"+ score.ToString() + " animals!";
    }
}
