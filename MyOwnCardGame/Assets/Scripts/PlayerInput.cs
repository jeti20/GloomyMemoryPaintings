using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//placed on GameManager
public class PlayerInput : MonoBehaviour
{//odpowiedzialny za mo¿liwoœæ klikania w karty
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.instance.HasPicked() && !GameManager.instance.GameIsOver())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //strzelamy z kamery do pozycji w której nacisnelismy myszk¹

            //jeœli raycast uderzy³ kartê to bierzemy skrypt "Card" z tego obiektu i metodê FlipOpen i ustawiamy j¹ na true, a w skrypcie Card, jesli flip Open jest true to odpala animacje
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.gameObject);

                Card currentCard = hit.transform.GetComponent<Card>();
                currentCard.FlipOpen(true);
                GameManager.instance.AddCardtoPickedList(currentCard);
            }
        }
    }
}
