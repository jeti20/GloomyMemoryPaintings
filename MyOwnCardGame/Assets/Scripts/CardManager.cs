using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//placed on GameManager
public class CardManager : MonoBehaviour
{ //odpowiedzialny za roz³o¿enie kart i wizualizacje ich rozmieszczenia

    [HideInInspector] public int pairAmount;
    public List<Sprite> spriteList = new List<Sprite>();
    

    [SerializeField] float offSet; //odstêp miêdzy kartami
    public GameObject cardPrefab;

    public List<GameObject> cardDeck = new List<GameObject>();
    [HideInInspector] public int width; //nie je
    [HideInInspector] public int height;

    void Start()
    {
        GameManager.instance.SetPairs(pairAmount);
        CreatePlayField();
    }

    // tworzy pole z kartami
    void CreatePlayField()
    {
        List<Sprite> tempSprites = new List<Sprite>();
        tempSprites.AddRange(spriteList);

        for (int i = 0; i < pairAmount; i++)
        {
            int randomSpriteIndex = Random.Range(0, tempSprites.Count); //losowanie randomowego obrazka z puli

            for (int j = 0; j < 2; j++)
            {
                Vector3 pos = Vector3.zero;
                GameObject newCard = Instantiate(cardPrefab, pos, Quaternion.identity);
                newCard.GetComponent<Card>().SetCard(i, tempSprites[randomSpriteIndex]);
                cardDeck.Add(newCard);
            }
            tempSprites.RemoveAt(randomSpriteIndex);
        }

        //tasowanie
        for (int i = 0; i < cardDeck.Count; i++)
        {
            int index = Random.Range(0, cardDeck.Count);
            var temp = cardDeck[i];
            cardDeck[i] = cardDeck[index];
            cardDeck[index] = temp;
        }

        int num = 0;
        //pass out card on field
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Vector3 pos = new Vector3(x * offSet, 0, z * offSet);
                cardDeck[num].transform.position = pos;
                num++;
            }
        }
    }


    private void OnDrawGizmos()
    {
        //pozwala na wizualizacjê jak karty bêd¹ roz³o¿one jeszcze przed startem gry
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Vector3 pos = new Vector3(x * offSet, 0, z * offSet);
                Gizmos.DrawWireCube(pos, new Vector3(1, 0.1f, 1));
            }
        }
        //zakomentowanie poniwa¿ mamy CardManagerEditor i to siê teraz tam robi tylko, ¿e lepiej
        /* if (pairAmount*2 !=  width * height)
         {
             Debug.Log("ERRORL width * height should be pairAmout * 2");
         }
         if (pairAmount > spriteList.Length)
         {
             Debug.Log("To much pairs");
         }*/
    }
}
