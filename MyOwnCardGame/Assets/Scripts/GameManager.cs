using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private bool picked; //set this ture if we have 2 cards picked
    int pairs;
    int pairCounter;
    bool gameOver = false;
    [SerializeField] bool hideMatches;
    

    public GameObject winPnel;

    List<Card> pickedCards = new List<Card>();


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        winPnel.SetActive(false);
  
    }

    public void AddCardtoPickedList(Card card)
    {
        if (pickedCards.Contains(card))
        {
            return;
        }

        pickedCards.Add(card);
        if (pickedCards.Count == 2)
        {
            picked = true;

            //check if we have a match
            StartCoroutine(CheckMatch());
        }
    }

    IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(1);
        if (pickedCards[0].GetCardId() == pickedCards[1].GetCardId())
        {
            //we have a match
            if (hideMatches) //matche znikaj� po matchu
            {
                pickedCards[0].gameObject.SetActive(false);
                pickedCards[1].gameObject.SetActive(false);
            }
            else//karty nie znikaj� i pozostaj� ods�oni�te je�li pasuj� do sibie (wy�aczenie boxcolidera sprawia ze nasz rycast nie moze kolidowa� z tym obiektem). 
            {
                pickedCards[0].GetComponent<BoxCollider>().enabled = false;
                pickedCards[1].GetComponent<BoxCollider>().enabled = false;
            }
            
            pairCounter++;
            CheckforWin();
            Debug.Log("takie same");
        }
        else
        {
            pickedCards[0].FlipOpen(false);
            pickedCards[1].FlipOpen(false);

            Debug.Log("inne");
            yield return new WaitForSeconds(1);
        }
        
        //Clean up
        picked = false;
        pickedCards.Clear();

    }

    void CheckforWin()
    {
        if (pairs == pairCounter)
        {
            winPnel.SetActive(true);

            Debug.Log("Win");
        }
    }



    public bool HasPicked()
    {
        return picked;
    }

    //metoda wywo�ywana w game manager jako jeden z warunk�w kt�ry musi by� false, �eby mo�na by�o klikn��. Po sko�czeniu czasu zmienia si� na false wi�c nie mo�na ju� klika�
    public bool GameIsOver()
    {
        return gameOver;
    }

    public void SetPairs(int pairAmount)
    {
        pairs = pairAmount;
    }

}
