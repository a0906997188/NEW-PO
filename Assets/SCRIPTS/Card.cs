using UnityEngine;
public class Card
{
    public string id;               // 卡片的識別代碼（用來配對）
    public Sprite image;            // 對應的圖案（狗狗圖）
    public bool isFaceUp;          //面朝上顯示狗的卡牌
    public bool isMatched;        

    public Card(string id, Sprite image)
    {
        this.id = id;
        this.image = image;
        this.isFaceUp = false;
        this.isMatched = false;
    }

    public void Flip()
    {
        isFaceUp = !isFaceUp;
    }

    public void Match()
    {
        isMatched = true;
    }

    public void PrintStatus()
    {
        Debug.Log(id + " 目前是 isFaceUp : " + isFaceUp + "，配對：" + isMatched);
    }
}

