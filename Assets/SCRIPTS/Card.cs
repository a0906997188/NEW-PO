using UnityEngine;
public class Card
{
    public string id;               // �d�����ѧO�N�X�]�ΨӰt��^
    public Sprite image;            // �������Ϯס]�����ϡ^
    public bool isFaceUp;          //���¤W��ܪ����d�P
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
        Debug.Log(id + " �ثe�O isFaceUp : " + isFaceUp + "�A�t��G" + isMatched);
    }
}

