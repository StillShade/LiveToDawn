using UnityEngine;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform contentParent;
    public List<CardData> cardDataList;
    
    private int currentStep = 1;
    private int maxSteps = 10;
    
    public static Action OnRegenerateRequested;
    public static Action OnStepsCompleted;

    private void OnEnable()
    {
        OnRegenerateRequested += RegenerateCards;
    }

    private void OnDisable()
    {
        OnRegenerateRequested -= RegenerateCards;
    }

    void Start()
    {
        currentStep = 1;
        RegenerateCards();
    }

    public void RegenerateCards()
    {
        // Если шагов больше, чем максимум — завершаем
        if (currentStep > maxSteps)
        {
            OnStepsCompleted?.Invoke();
            return;
        }
        
        // Удаляем старые карточки
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        // Списки для сортировки
        List<CardData> randomCards = new List<CardData>();
        CardData campCard = null;
        CardData nextStepCard = null;

        foreach (var data in cardDataList)
        {
            if (data.name.Contains("CampCard"))
                campCard = data;
            else if (data.name.Contains("NextStepCard"))
                nextStepCard = data;
            else
            {
                if (Random.value <= data.spawnChance)
                    randomCards.Add(data);
            }
        }

        foreach (var data in randomCards)
        {
            CreateCard(data);
        }

        if (campCard != null)
            CreateCard(campCard);

        if (nextStepCard != null)
            CreateCard(nextStepCard);
        
        currentStep++;
    }

    void CreateCard(CardData data)
    {
        var card = Instantiate(cardPrefab, contentParent);
        card.GetComponent<CardUI>().Setup(data, currentStep, maxSteps);
    }
}
