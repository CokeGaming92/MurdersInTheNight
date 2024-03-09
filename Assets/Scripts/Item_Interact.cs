
using UnityEngine;
using UnityEngine.Events;


public class Item_Interact : MonoBehaviour
{
    public float maxDistance = 2f;
    public Transform player;
    public bool isClicked;
    public UnityEvent unityEvent, unityEvent2;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnMouseDown()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= maxDistance)
        {
           isClicked = !isClicked;

            if(isClicked)
            {
                unityEvent.Invoke();
            }
            if(!isClicked)
            {
                unityEvent2.Invoke();
            }
        }
       
    }
}
