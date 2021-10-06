using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionMoviment : MonoBehaviour
{
    private bool eLadoDireito;
    [SerializeField]
    private float velocidade;
    // Start is called before the first frame update
    void Start()
    {
        eLadoDireito = true;
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
     
        
    }

       private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Limite"){
                MudarDirecao();
            }
        }

    private void Mover()
    {
        transform.Translate(PegarDirecao() * velocidade * Time.deltaTime);
    }

    //métodos

    private Vector2 PegarDirecao()
    {
       return eLadoDireito ? Vector2.right : Vector2.left;
    }

    private void MudarDirecao(){
        eLadoDireito = !eLadoDireito;
        this.transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
    }

}
