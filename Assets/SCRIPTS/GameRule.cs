using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton for easy access

    private CardView[] flippedCards = new CardView[2];
    private int flipIndex = 0;

    void Awake()
    {
        Instance = this;
    }

    public void RegisterFlippedCard(CardView card)
    {
        if (card.IsMatched() || card.IsFaceUp()) return;   //如果已經配對或是被翻開，那就不用記錄了

        card.FlipFront();
        flippedCards[flipIndex] = card;
        flipIndex++;

        if (flipIndex == 2)
        {
            StartCoroutine(CheckMatch()); //「協同程序」（Coroutine）讓程式「暫停一下」，過一段時間再繼續做事 
        }
    }

    IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(0.8f);

        CardView card1 = flippedCards[0];
        CardView card2 = flippedCards[1];

        if (card1.GetCardID() == card2.GetCardID())
        {
            card1.SetMatched();
            card2.SetMatched();
            card1.Hide();
            card2.Hide();
        }
        else
        {
            card1.FlipBack();
            card2.FlipBack();
        }

        flippedCards[0] = null;
        flippedCards[1] = null;
        flipIndex = 0;
    }
}
