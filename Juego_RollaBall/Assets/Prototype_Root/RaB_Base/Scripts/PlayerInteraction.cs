using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Librería para poder referenciar elementos de User Interface
using TMPro;
using UnityEngine.Rendering; //Librería para poder referenciar elementos de Text Mesh Pro       

public class PlayerInteraction : MonoBehaviour
{


    [Header("UI References")]
    public TMP_Text pointsText; //Referencía al texto de UI que quiero que se actualice según los puntos del player

    

    //variables para definir los puntos del jugador
    [Header("Point System Parameters")]
    public int currentPoints;
    public int winPoints;

    //El Respawn
    [Header("Respawn Parameters")]
    public Transform respawnPoint;
    public float respawnFallLimit;
    public GameObject winGoal;


    [Header("Scene Management")]
    public SceneChanger sceneManagerScript;
    public int sceneToLoad;


    private void Update()


    {
        if (currentPoints < 0) { currentPoints = 0; }
        if (transform.position.y <= respawnFallLimit) { Respawn(); }
        if (currentPoints >= winPoints) { winGoal.SetActive(true); }
        UIUpdater();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) {
            currentPoints += 1;
            //Destroy(other.gameObject); //
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("PickDown"))
        {
            currentPoints -= 1;
            //Destroy(other.gameObject); //
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Finish")) {
                WinCall();
            other.gameObject.SetActive(false);
            }
        
    } 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) { Respawn(); }
    }

    void Respawn()
    {
        transform.position = respawnPoint.position;
    }

    void UIUpdater() 
    {
        pointsText.text = "POINTS: " + currentPoints.ToString() + " / " + winPoints.ToString();
    
    }

    void WinCall() 
    {
        //Acción del cambio de escena
        Debug.Log("He ganado");
        sceneManagerScript.SceneLoader(sceneToLoad);

    }



}
