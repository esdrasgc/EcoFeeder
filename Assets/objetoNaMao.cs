using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetoNaMao : Player
{
    // Start is called before the first frame update

    public GameObject[] prefabs;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.B))
        {
            if(selecionado == 5){
                selecionado = 0;
            }else{
                selecionado++;
            }
        
        }
        for(int i = 0; i < prefabs.Length; i++){
            if (selecionado == i){
                prefabs[i].SetActive(true);
            }else{
                prefabs[i].SetActive(false);
            }
        }

       
        
        
    }
}
