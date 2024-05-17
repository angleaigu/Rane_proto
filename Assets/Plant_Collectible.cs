using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plant_Collectible : MonoBehaviour

{
    [SerializeField] public collectibles_counter collectibe_nb;


    // Start is called before the first frame update
    void Start()
    {
        collectibe_nb._Plant_Collectible = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collectibe_nb._Plant_Collectible++;
            this.gameObject.SetActive(false);
        }

    }
}
