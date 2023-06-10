using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIController : MonoBehaviour
{
    public TextMeshProUGUI LivesText;

    public List<GameObject> LivesIcons = new List<GameObject>();
    
    public void UpdateLivesIcons(int _value) 
    {
       for (int i = LivesIcons.Count -1 ; i >= 0 ; i --)
       {
            LivesIcons[i].SetActive(i >= _value);
       } 

    }




    public List<GameObject> GetLivesIcons()
    {
    return LivesIcons;
    }

    private void Start() 
    {
    // HideGameOver();
      // HidePausePanel();
       // ShowStartGame();
    }


    public void UpdateLivesIcons2() 
    {
        LivesIcons.RemoveAt(LivesIcons.Count - 1); // Remove a life icon

    /*   //LivesIcons.Count =  LivesIcons.Count - 1;
       for (int i = 0; i < LivesIcons.Count; i++)
       {
            LivesIcons[i].SetActive(i < -1);
       } 
       */

         if (LivesIcons.Count <= 1)
        {
            //GameController.ShowGameOver();
    
          }

    }

}
