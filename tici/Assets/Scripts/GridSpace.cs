using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{

    public Button button;
    public Text buttonText;
    public string playerSide;
    public Sprite playerX;
    public Sprite playerO;

    private GameController gameController;

    public void SetGameControllerReference(GameController controller)
    {
        gameController = controller;
    }

    public void SetSpace()
    {
        buttonText.text = gameController.GetPlayerSide();
        if (gameController.GetPlayerSide() == "X")
            button.image.sprite = playerX;
        else
            button.image.sprite = playerO;
        button.interactable = false;
        gameController.EndTurn();
    }
}