using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoGatilho : MonoBehaviour
{
    [SerializeField]

    private Rigidbody rb;



    private void Start()
    {

        rb = GetComponent<Rigidbody>();

    }



    private void OnTriggerExit(Collider col)
    {

        if (col.CompareTag("Player"))
        {

            rb.useGravity = true;
            Destroy(gameObject, 0.5f);
            CriaChao.chaoNumCena--;

        }

    }

}

