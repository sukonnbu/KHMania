using UnityEngine;

public class Note : MonoBehaviour
{
    public float initialSpeed = 3f;
    private float _speed;

    public void SetState(bool isFalling)
    {
        if (isFalling)
        {
            _speed = initialSpeed;
            // show note
        }
        else
        {
            _speed = 0f;
            // hide note & animation
        }
    }

    void Update()
    {
        transform.position += new Vector3(0, -10, 0) * (_speed * Time.deltaTime);
    }
}
