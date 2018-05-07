using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(PlayerManager))]
[RequireComponent (typeof(PlayerController))]
[RequireComponent(typeof(AudioSource))]

public class LanzarCorazon : MonoBehaviour
{
    PlayerManager Manager;
    PlayerController Controller;

    Animator anim;
    public AudioClip lanzamiento;
    AudioSource Audio;

    public GameObject corazon;
    public KeyCode tecla;

    Vector3 pos;
        
    // Use this for initialization
    void Start()
    {
        Manager = GetComponent<PlayerManager>();
        Controller = GetComponent<PlayerController>();
        Audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        Lanzar(Manager);
    }

    void Lanzar(PlayerManager Manager)
    {
        if (Input.GetKeyDown(tecla) && Manager.tieneCorazon)
        {
            switch(Controller.ultimaTecla)
            {
                case KeyCode.W:
                case KeyCode.UpArrow:
                    corazon.GetComponent<MoverCorazon>().direccion = Vector3.up;
                    pos = new Vector3(0, 1, 0);
                    anim.SetTrigger("LanzarArriba");
                    break;
                case KeyCode.S:
                case KeyCode.DownArrow:
                    corazon.GetComponent<MoverCorazon>().direccion = Vector3.down;
                    pos = new Vector3(0, -1, 0);
                    anim.SetTrigger("LanzarAbajo");
                    break;
                case KeyCode.D:
                case KeyCode.RightArrow:
                    corazon.GetComponent<MoverCorazon>().direccion = Vector3.right;
                    pos = new Vector3(1, 0, 0);
                    anim.SetTrigger("LanzarDcha");
                    break;
                case KeyCode.A:
                case KeyCode.LeftArrow:
                    corazon.GetComponent<MoverCorazon>().direccion = Vector3.left;
                    pos = new Vector3(-1, 0, 0);
                    anim.SetTrigger("LanzarIzqu");
                    break;
            }
            anim.SetTrigger("Lanzar");
            corazon.transform.position = transform.position + pos;

            Instantiate(corazon);


            Manager.tieneCorazon = false;
        }
    }
}
