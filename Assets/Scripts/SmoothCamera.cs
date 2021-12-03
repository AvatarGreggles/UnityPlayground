 using UnityEngine;
 using System.Collections;
 
 public class SmoothCamera : MonoBehaviour {
     

      [SerializeField] float  minPosition  = -20.0f; // bottom border
    [SerializeField] float maxPosition  = 20.0f; //  top border

     public float dampTime = 0.15f;
     private Vector3 velocity = Vector3.zero;
     public Transform target;


     private void Awake() {
   
     }
 
     // Update is called once per frame
     void FixedUpdate () 
     {
         if (target)
         {
             Vector3 point = Camera.main.WorldToViewportPoint(target.position);
             Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
             Vector3 destination = transform.position + delta;
             
             transform.position = Vector3.SmoothDamp(new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minPosition, maxPosition), transform.position.z), destination, ref velocity, dampTime);
         }
     
     }
 }
