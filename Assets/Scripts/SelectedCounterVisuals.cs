using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisuals : MonoBehaviour
{
    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameObjectArray;
    private void Start()
    {
        PlayerController.Instance.onSelectedCounterChanged += Player_onSelectedCounterChanged;
    }

    private void Player_onSelectedCounterChanged(object sender, PlayerController.onSelectedCounterChangedEventArgs e)
    {
        if(e.selectedCounter == baseCounter) //assigning in inspector what is clear counter
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
        foreach(GameObject visualGameObject in visualGameObjectArray)
        {
            visualGameObject.SetActive(true);
        }
        
    }
    private void Hide()
    {
        foreach (GameObject visualGameObject in visualGameObjectArray)
        {
            visualGameObject.SetActive(false);
        }
    }
}
