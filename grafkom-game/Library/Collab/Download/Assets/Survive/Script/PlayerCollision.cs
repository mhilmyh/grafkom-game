using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerScript script;

    void OnCollisionEnter(Collision other) 
    {
        if( other.collider.tag == "Enemy" )
        {
            script.enabled = false;
        }
    }
}
