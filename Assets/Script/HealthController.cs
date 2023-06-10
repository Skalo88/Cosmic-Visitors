using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
 public int playerHealth = 3;
 [SerializeField] private Image[] lives;

 private void  Start()
 {
    UpdateHealth();
 }
    public void UpdateHealth() {
        for (int i = 0; i< lives.Length; i++)
        {
            if (i<playerHealth)
            {
             lives[i].color = Color.red;

            }
            else 
            {
                lives[i].color = Color.black;
            }
        }
    }

}
