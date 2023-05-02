using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float runSpeed;
    public float gotHayDestroyDelay;
    public bool hitByHay;
    public float dropDestroyDelay;
    public Collider myCollider;
    public Rigidbody myRigidBody;
    private SheepSpawner sheepSpawner;



    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other){
        
        if (other.CompareTag("Hay") && !hitByHay){
            Destroy(other.gameObject);
            HitByHay();
        }
        else if(other.CompareTag("SheepDrop")){
            Debug.Log("El objeto Sheep ha colisionado con SheepDrop");
            Drop();
        }
    }

    private void HitByHay(){
        sheepSpawner.RemoveSheepFromList (gameObject);
        hitByHay = true;
        runSpeed = 0;
        Destroy(gameObject, gotHayDestroyDelay);

    }

    private void Drop(){
        sheepSpawner.RemoveSheepFromList (gameObject);
        Debug.Log("El objeto Sheep ha caído");
        myRigidBody.isKinematic = false;
        myCollider.isTrigger = false;
        Destroy(gameObject, dropDestroyDelay);

    }

    public void SetSpawner(SheepSpawner spawner){
        sheepSpawner = spawner;

    }
}
