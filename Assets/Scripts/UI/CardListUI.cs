using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardListUI : MonoBehaviour
{
    public List<Card> cards;
    private void Start()
    {
        DisableCardList();
        ShowCardList();
    }
    public void ShowCardList()
    {
        GetComponent<RectTransform>().DOAnchorPosY(448f,6f);
        EnableCardList();
    }
    public void DisableCardList()
    {
        foreach (Card card in cards)
        {
            card.DisableCard();
        }
    }
    void EnableCardList()
    {
        foreach (Card card in cards)
        {
            card.EnableCard();
        }
    }
}
