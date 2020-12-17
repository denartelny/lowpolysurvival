using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public int Health;
    public int Water;
    public int Food;
    public int MaxHealth;
    public int MaxWater;
    public int MaxFood;
    public Text StatsText;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Starve", 1, 10);
        InvokeRepeating("NoWater", 1, 10);
        InvokeRepeating("CheckHealth", 1, 10);
        PrintLogs();

    }

    void PrintLogs()
    {
        StatsText.text = "Health: " + Health + " Food: " + Food + " Water: " + Water;
    }

    void CheckHealth()
    {
        if (Food > MaxFood)
        {
            Food = MaxFood;
            Health++;
        }
        if (Water > MaxWater)
        {
            Water = MaxWater;
            Health++;
        }
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
        if (Food < 1)
        {
            Food = 0;

            Health--;
            PrintLogs();

        }
        if (Water < 0)
        {
            Water = 0;
            Health--;
            PrintLogs();
        }

        if (Health < 1)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

   
 

    void Starve()
    {
        Food--;
        PrintLogs();

    }

    void NoWater()
    {

        Water-=2;
        PrintLogs();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag==    "Food")
        {
            Food++;
            Destroy(other.gameObject);
            PrintLogs();

        }
        if (Food > MaxFood)
        {
            Food = MaxFood;
        }
        if (other.gameObject.tag == "Water")
        {
            Water++;
            PrintLogs();
      
        }
   if(Water > MaxWater)
        {
            Water = MaxWater;
        }
    }

    



}

