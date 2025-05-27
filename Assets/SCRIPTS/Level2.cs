using UnityEngine;
using UnityEngine.U2D;

public class Level2 : MonoBehaviour
{
    //�]�w�v���ܼƹ���4�i�����ϻP1�i�\�P�A�ܫe�x���
    public Sprite d1;
    public Sprite d2;
    public Sprite d3;
    //public Sprite d4;
    public Sprite back;

    //�]�wprefab�C�������e�x
    public GameObject cardPrefab;

    //�إߤ@�Ӥ@���}�C�s�񱵤U�Ӫ�8�i�P�Ad1-d4�U��i
    public Card[] p1 = new Card[6];

    //�إߤ@��GameObject���}�C�Ӻ޲z������8�i�P
    public GameObject[] cards = new GameObject[6];


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SManager.levelScore = 0;
        SManager.levelNO = 6;
        // �e8�i�� d1~d4 �U2�i
        p1[0] = new Card("d1", d1);
        p1[1] = new Card("d1", d1);
        p1[2] = new Card("d2", d2);
        p1[3] = new Card("d2", d2);
        p1[4] = new Card("d3", d3);
        p1[5] = new Card("d3", d3);
        //p1[6] = new Card("d4", d4);
        //p1[7] = new Card("d4", d4);

        //��n��b��������m�i��Щw
        Vector2[] positions = new Vector2[]
     {
        new Vector2(-4, 2), new Vector2(0, 2),
        new Vector2( 4, 2), new Vector2( 0, -2),
        new Vector2(-4,-2),new Vector2(4,-2)
     };

        //�Npositions���������i���m�հ�
        ShufflePositions(positions);

        //�̧ǲ���8�i�P
        for (int i = 0; i < 6; i++)
        {
            CreateCardObject(p1[i], positions[i]);
        }

    }


    //�N�}�C����m�i��մ�
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
        Debug.Log("�إߥd���G" + cardData.id);
    }



}
