using UnityEngine;

public class CardView : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Card cardData; //�ΨӰO��ǨӪ�����
    private Sprite image;  //�ΨӰO��ǨӪ��v��

    //�]�w�d���{�����v��
    public void SetCard(Card card, Sprite imageSprite)
    {
        
        cardData = card;
        image = imageSprite;
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateView(); // �즸�ھڪ��A��s�e��
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
