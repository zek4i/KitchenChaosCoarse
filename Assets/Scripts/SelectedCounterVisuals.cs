using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisuals : MonoBehaviour
{
    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject visualGameObject;
    private void Start()
    {
        PlayerController.Instance.onSelectedCounterChanged += Player_onSelectedCounterChanged;
    }

    private void Player_onSelectedCounterChanged(object sender, PlayerController.onSelectedCounterChangedEventArgs e)
    {
        if(e.selectedCounter == clearCounter) //assigning in inspector what is clear counter
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    private void Show()
    {
        visualGameObject.SetActive(true);
    }
    private void Hide()
    {
        visualGameObject?.SetActive(false);
    }
}
