using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class IA_detection : MonoBehaviour
{
    [SerializeField] private float Player_Hitbox_LayerMask;
    [SerializeField] private Vector2 Hitbox_size;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enemy_Awakening_Box();

        }

        private void Enemy_Awakening_Box() {

     Collider2D[] Enemey_found = Physics2D.OverlapBoxAll(this.transform.position, Hitbox_size, Player_Hitbox_LayerMask);

     foreach (var Object in Enemey_found) {
         
         if (Object.tag == "Prefab_ia") {

             if (Object.GetComponent<Script_PatrolingAi_Prefab>().Get_Alive()) {

                 Object.GetComponent<Script_PatrolingAi_Prefab>().Assign_Player(this.transform);
}
         }
     }
 }
}
