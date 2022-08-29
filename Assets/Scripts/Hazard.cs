
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Vector3 destination;
    [SerializeField] private float verticalNum;
    [SerializeField] private bool Vertical;
    private Vector3 _current;

    void Start()
    {
        _current = transform.position;
        destination = _current;
        if (Vertical)
        {
            destination.x += verticalNum;
        }
        else
        {
            destination.y += verticalNum;
        }
    }
    
    void Update()
    {
        transform.position = Vector3.Lerp(_current ,destination, Mathf.PingPong(speed * Time.time,1f));
    }
}
