using UnityEngine;

public class CardView : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Card cardData; //用來記住傳來的物件
    private Sprite image;  //用來記住傳來的影像

    //設定卡片程式的影像
    public void SetCard(Card card, Sprite imageSprite)
    {
        
        cardData = card;
        image = imageSprite;
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateView(); // 初次根據狀態更新畫面
    }

    void OnMouseDown()
    {
        if (!cardData.isFaceUp && !cardData.isMatched)
        {
            GameManager.Instance.RegisterFlippedCard(this);
        }
    }

    void UpdateView()
    {
        if (cardData.isFaceUp)
        {
            spriteRenderer.sprite = cardData.image;
        }
        else
        {
            spriteRenderer.sprite = image;
        }
    }

    public void SetMatched()
    {
        cardData.isMatched = true;
    }
    public bool IsMatched()
    {
        return cardData.isMatched;
    }

    public bool IsFaceUp()
    {
        return cardData.isFaceUp;
    }

    public void FlipFront()
    {
        cardData.isFaceUp = true;
        UpdateView();
    }

    public void FlipBack()
    {
        cardData.isFaceUp = false;
        UpdateView();
    }

    public void Hide()
    {
        cardData.isMatched = true;
        gameObject.SetActive(false);
    }

    public string GetCardID()
    {
        return cardData.id;
    }
}
