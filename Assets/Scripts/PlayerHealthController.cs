using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    //Variables para controlar la vida actual del jugador y el máximo de vida que puede tener
    public int currentHealth, maxHealth;

    //Referencia del SpriteRenderer del jugador
    private SpriteRenderer theSR;

    //La referencia del efecto de muerte del jugador
    public GameObject deathEffect;

    //Hacemos el Singleton de este script
    public static PlayerHealthController sharedInstance;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos la vida del jugador
        currentHealth = maxHealth;
        //Obtenemos el SpriteRenderer del jugador
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    //Método para manejar el daño
    public void DealWithDamage()
    {
    
        if (currentHealth <= 0)
        {

            //Restamos 1 de la vida que tengamos
            currentHealth--; //currentHealth -= 1; currentHealth = currentHealth - 1;

            //Si la vida está en 0 o por debajo (para asegurarnos de tener en cuenta solo valores positivos)
            if (currentHealth <= 0)
            {
                //Hacemos cero la vida si fuera negativa
                currentHealth = 0;

                gameObject.SetActive(false);

                //Instanciamos el efecto de muerte del jugador
                //Instantiate(deathEffect, transform.position, transform.rotation);

                //Llamamos al método que respawnea al jugador
                LevelManager.sharedInstance.RespawnPlayer();
            }
            //Si el jugador ha recibido daño pero no ha muerto

            //Actualizamos la UI
            //UIController.sharedInstance.UpdateHealthDisplay();
        }
    }
   
}

