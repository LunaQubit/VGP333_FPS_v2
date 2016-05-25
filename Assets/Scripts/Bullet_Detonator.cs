using UnityEngine;
using System.Collections;

public class Bullet_Detonator : MonoBehaviour {

    private float lifeSpan = 3.0f;

    void Start () 
    {
	
	}
	
	void Update () 
    {
        lifeSpan = Time.deltaTime;

        if( lifeSpan <= 0 )
        {
            Explode();
        }
	}

    void onCollisionEnter(Collision collision)
    {
        if(gameObject.tag == "Bullet" )
        {
            if( collision.gameObject.tag == "Enemy" )
            {
                Destroy( collision.gameObject );
                Destroy( gameObject );
            }
        }
        if(gameObject.tag == "Rocket" )
        {

        }
       
            
    }

    void Explode()
    {
        Destroy( gameObject );
    }
}
