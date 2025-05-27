using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton for easy access

    private CardView[] flippedCards = new CardView[2];
    private int flipIndex = 0;
    private bool isCheckingMatch = false; //  �קK�����I������

    void Awake()
    {
        Instance = this;
    }

    public void RegisterFlippedCard(CardView card)
    {
        if (isCheckingMatch) return;                      //  �ˬd�O�_���b���
        if (card.IsMatched() || card.IsFaceUp()) return;  // �w½�}�ΰt��N���B�z

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
        isCheckingMatch = true;   // ��w
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
        isCheckingMatch = false;  //  ����
    }
}
