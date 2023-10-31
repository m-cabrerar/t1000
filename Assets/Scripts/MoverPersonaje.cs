using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    public float velocidadBase = 5.0f;
    public float velocidadAumentada = 10.0f;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _animatorSpeed = 1;
    private Rigidbody rb;

    float movimientoHorizontal;
    float movimientoVertical;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (PlayerData.Instance != null)
        {
            transform.position = PlayerData.Instance.playerPosition;
            transform.rotation = PlayerData.Instance.playerRotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        movimientoHorizontal = Input.GetAxis("Horizontal");
        movimientoVertical = Input.GetAxis("Vertical");

        //Calcula vector de movimiento
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical);

        //Apuntar el frente del personaje hacia la dirección del movimiento
        if(movimiento != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movimiento);
        }

        float velocidadActual = Input.GetKey(KeyCode.LeftShift) ? velocidadAumentada : velocidadBase;

        Vector3 velocidadFinal = movimiento.normalized * velocidadActual;
        velocidadFinal.y = rb.velocity.y;
        //Aplica el movimiento al Rigidbody
        rb.velocity = velocidadFinal;

        _animator.SetBool("EstaCaminando", movimientoHorizontal != 0 || movimientoVertical != 0);
        _animator.speed = _animatorSpeed;
    }
}
