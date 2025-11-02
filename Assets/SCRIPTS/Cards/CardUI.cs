using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Text nameText;
    public Image iconImage;
    public Text timeText;
    public Text energyText;
    public Image rewardImage;
    
    private Image backgroundImage;
    public Image reverseBackgroundImage;
    
    public Button playButton;
    public Text stepText;

    private CardData currentData;

    public void Setup(CardData data, int currentStep, int maxSteps)
    {
        currentData = data;

        nameText.text = data.cardName;
        iconImage.sprite = data.icon;
        timeText.text = data.time.ToString();
        energyText.text = data.energy.ToString();
        rewardImage.sprite = data.rewardIcon;
        
                
        backgroundImage = GetComponent<Image>();
        backgroundImage.color = data.backgroundColor;
        reverseBackgroundImage.color = data.backgroundColor;

        // Проверяем, NextStep ли это
        if (data.name.Contains("NextStepCard"))
        {
            playButton.onClick.AddListener(OnNextStepPlayClicked);
            stepText.text = $"{currentStep}/{maxSteps}";
        }
        else
        {
            playButton.onClick.RemoveAllListeners(); // на всякий случай
        }
    }

    void OnNextStepPlayClicked()
    {
        Debug.Log("NextStepCard: Play clicked — regenerate cards!");
        CardManager.OnRegenerateRequested?.Invoke();
    }
    
}
