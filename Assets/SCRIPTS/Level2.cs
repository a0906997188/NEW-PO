using UnityEngine;
using UnityEngine.U2D;

public class Level2 : MonoBehaviour
{
    //設定影像變數對應4張狗的圖與1張蓋牌，至前台賦值
    public Sprite d1;
    public Sprite d2;
    public Sprite d3;
    //public Sprite d4;
    public Sprite back;

    //設定prefab遊戲物件於前台
    public GameObject cardPrefab;

    //建立一個一維陣列存放接下來的8張牌，d1-d4各兩張
    public Card[] p1 = new Card[6];

    //建立一個GameObject的陣列來管理場景的8張牌
    public GameObject[] cards = new GameObject[6];


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SManager.levelScore = 0;
        SManager.levelNO = 6;
        // 前8張為 d1~d4 各2張
        p1[0] = new Card("d1", d1);
        p1[1] = new Card("d1", d1);
        p1[2] = new Card("d2", d2);
        p1[3] = new Card("d2", d2);
        p1[4] = new Card("d3", d3);
        p1[5] = new Card("d3", d3);
        //p1[6] = new Card("d4", d4);
        //p1[7] = new Card("d4", d4);

        //把要放在場景的位置進行標定
        Vector2[] positions = new Vector2[]
     {
        new Vector2(-4, 2), new Vector2(0, 2),
        new Vector2( 4, 2), new Vector2( 0, -2),
        new Vector2(-4,-2),new Vector2(4,-2)
     };

        //將positions中的元素進行位置調動
        ShufflePositions(positions);

        //依序產生8張牌
        for (int i = 0; i < 6; i++)
        {
            CreateCardObject(p1[i], positions[i]);
        }

    }


    //將陣列的位置進行調換
    void ShufflePositions(Vector2[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int randIndex = Random.Range(i, array.Length);
            Vector2 temp = array[i];
            array[i] = array[randIndex];
            array[randIndex] = temp;
        }
    }

    // 
    void CreateCardObject(Card cardData, Vector2 position)
    {
        GameObject newCard = Instantiate(cardPrefab, position, Quaternion.identity);
        CardView view = newCard.GetComponent<CardView>();
        view.SetCard(cardData, back);
        Debug.Log("建立卡片：" + cardData.id);
    }



}
