 using UnityEngine;
 using System.Collections;
 
 public class HoldItems : MonoBehaviour {
 
 
     public float speed = 10;
     public bool canHold = true;
     public GameObject object;
     public Transform pickLocation;
 
    void Update()
   {
       if (Input.GetMouseButtonDown(0))
       {
           if (!canHold)
		   {
               throw_drop();
			{
		   else
		   {
               Pickup();
		   }
	   }
  
       if (!canHold && ball)
           ball.transform.position = guide.position;
       
   }
 
     //We can use trigger or Collision
     void OnTriggerEnter(Collider col)
     {
        if (col.gameObject.tag == "ball")
		{
            if (!ball) // if we don't have anything holding
			{				
                ball = col.gameObject;
			}
		}
	 }
 
     //We can use trigger or Collision
     void OnTriggerExit(Collider col)
     {
         if (col.gameObject.tag == "ball")
         {
            if (canHold)
			{
                ball = null;
			}
		 }
     }
 
 
     private void Pickup()
     {
        if (!ball)
		{
            return;
		}
         //We set the object parent to our guide empty object.
         ball.transform.SetParent(guide);
 
         //Set gravity to false while holding it
         ball.GetComponent<Rigidbody>().useGravity = false;
 
         //we apply the same rotation our main object (Camera) has.
         ball.transform.localRotation = transform.rotation;
         //We re-position the ball on our guide object 
         ball.transform.position = guide.position;
 
         canHold = false;
     }
 
     private void throw_drop()
     {
         if (!ball)
             return;
 
         //Set our Gravity to true again.
         ball.GetComponent<Rigidbody>().useGravity = true;
          // we don't have anything to do with our ball field anymore
          ball = null; 
         //Apply velocity on throwing
         guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;
 
         //Unparent our ball
         guide.GetChild(0).parent = null;
         canHold = true;
     }
 }