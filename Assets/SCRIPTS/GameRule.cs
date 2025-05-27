using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton for easy access

    private CardView[] flippedCards = new CardView[2];
    private int flipIndex = 0;
    private bool isCheckingMatch = false; //  避免重複點擊的鎖

    void Awake()
    {
        Instance = this;
    }

    public void RegisterFlippedCard(CardView card)
    {
        if (isCheckingMatch) return;                      //  檢查是否正在比對
        if (card.IsMatched() || card.IsFaceUp()) return;  // 已翻開或配對就不處理

        card.FlipFront();
        flippedCards[flipIndex] = card;
        flipIndex++;

        if (flipIndex == 2)
        {
            StartCoroutine(CheckMatch());
        }
    }

    IEnumerator CheckMatch()
    {
        isCheckingMatch = true;   // 鎖定
        yield return new WaitForSeconds(0.8f);

        CardView card1 = flippedCards[0];
        CardView card2 = flippedCards[1];

        if (card1.GetCardID() == card2.GetCardID())
        {
            
            card1.SetMatched();
            card2.SetMatched();
            card1.Hide();
            card2.Hide();
            SManager.levelScore += 2;
        }
        else
        {
            card1.FlipBack();
            card2.FlipBack();
        }

        flippedCards[0] = null;
        flippedCards[1] = null;
        flipIndex = 0;
        isCheckingMatch = false;  //  解鎖
    }
}
