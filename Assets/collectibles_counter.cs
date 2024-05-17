using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class collectibles_counter : MonoBehaviour
{
    public float _Plant_Collectible;
    [SerializeField] private TextMeshProUGUI compteur;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        compteur.text = _Plant_Collectible.ToString("0");


    }
}
