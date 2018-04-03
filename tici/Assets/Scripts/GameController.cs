using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

[System.Serializable]
public class Player
{
    public Image panel;
    public Text text;
    public Button button;
}

[System.Serializable]
public class PlayerColor
{
    public Sprite playerImage;
}

public class GameController : MonoBehaviour
{

    public Text[] buttonList;
    public Button[] gridList;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public GameObject restartButton;
    public Player playerX;
    public Player playerO;
    public PlayerColor activePlayerColorX;
    public PlayerColor inactivePlayerColorX;
    public PlayerColor activePlayerColorO;
    public PlayerColor inactivePlayerColorO;
    public Sprite reset;
    public Text counterText;
    public int countdownTime;
    public GameObject darkBackground;
    public Text playerXScore;
    public Text playerOScore;


    private string playerSide;
    private int moveCount;
    private int counter;
    private int xScore;
    private int oScore;

    void Awake()
    {
        SetGameControllerReferenceOnButtons();
        gameOverPanel.SetActive(false);
        moveCount = 0;
        xScore = 0;
        oScore = 0;
        restartButton.SetActive(false);
        darkBackground.SetActive(false);
    }

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public void SetStartingSide(string startingSide)
    {
        playerSide = startingSide;
        if (playerSide == "X")
        {
            SetPlayerColorsX(playerX, playerO);
        }
        else
        {
            SetPlayerColorsO(playerO, playerX);
        }

        StartGame();
    }

    void StartGame()
    {
        SetBoardInteractable(true);
        SetPlayerButtons(false);
        restartCounter();
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        moveCount++;

        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (moveCount >= 9)
        {
            GameOver("draw");
        }
        else
        {
            ChangeSides();
        }
    }

    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
        if (playerSide == "X")
        {
            SetPlayerColorsX(playerX, playerO);
        }
        else
        {
            SetPlayerColorsO(playerO, playerX);
        }
        restartCounter();
    }

    void SetPlayerColorsX(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.sprite = activePlayerColorX.playerImage;
        oldPlayer.panel.sprite = inactivePlayerColorO.playerImage;
    }

    void SetPlayerColorsO(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.sprite = activePlayerColorO.playerImage;
        oldPlayer.panel.sprite = inactivePlayerColorX.playerImage;
    }

    void GameOver(string winningPlayer)
    {
        SetBoardInteractable(false);
        if (winningPlayer == "draw")
        {
            SetGameOverText("It's a Draw!");
            SetPlayerColorsInactive();
        }
        else
        {
            SetGameOverText(winningPlayer + " Wins!");
            if (winningPlayer == "X")
                xScore += 1;
            else
                oScore += 1;
        }
        restartButton.SetActive(true);
        darkBackground.SetActive(true);
        StopAllCoroutines();
    }

    void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    public void RestartGame()
    {
        moveCount = 0;
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        darkBackground.SetActive(false);
        SetPlayerButtons(true);
        SetPlayerColorsInactive();

        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
            gridList[i].image.sprite = reset;
        }
    }

    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    void SetPlayerButtons(bool toggle)
    {
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;
    }

    void SetPlayerColorsInactive()
    {
        playerX.panel.sprite = inactivePlayerColorX.playerImage;
        playerO.panel.sprite = inactivePlayerColorO.playerImage;
    }

    private IEnumerator counting()
    {
        Debug.Log("Starting at  " + counter);
        while (counter > 0)
        {
            yield return new WaitForSeconds(1.0f);
            counter -= 1;
            Debug.Log("counting " + counter);
        }
        ChangeSides();
    }

    private void restartCounter()
    {
        StopAllCoroutines();
        counter = countdownTime;
        StartCoroutine(counting());
    }

    private void Update()
    {
        
        counterText.text = "" + counter;
        playerXScore.text = "" + xScore;
        playerOScore.text = "" + oScore;


    }
        

}

