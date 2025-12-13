using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10f;
    [SerializeField] Transform tip;

    private Rigidbody rb;
    private bool inAir = false;
    private Vector3 lastPosition = Vector3.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        PullInteraction.PullActionReleased += Release;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Release(float value)
    {
        PullInteraction.PullActionReleased -= Release;
        gameObject.transform.parent = null;
        inAir = true;
        SetPhysics(true);

        Vector3 force = transform.forward * value * speed;
        rb.AddForce(force, ForceMode.Impulse);
        StartCoroutine(RotateWithVelocity());

    }

    private IEnumerator RotateWithVelocity()
    {
        yield return new WaitForFixedUpdate();
        while (inAir)
        {
            Quaternion newRotation = Quaternion.LookRotation(rb.linearVelocity, transform.up);
            transform.rotation = newRotation;
            yield return null;
        }
    }

    private void FixedUpdate()
    {
        if (inAir) 
        {
            //CheckCollision();
            lastPosition = tip.position;
        }

    }

    private void SetPhysics(bool physics) 
    {
        rb.useGravity = physics;
        rb.isKinematic = !physics;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (inAir && !collision.transform.TryGetComponent(out ArrowSpawner spawner))
        {
            rb.interpolation = RigidbodyInterpolation.None;
            transform.parent = collision.transform;
            if (collision.transform.TryGetComponent(out Rigidbody body))
            {
                body.AddForce(rb.linearVelocity, ForceMode.Impulse);
            }
            Stop();
        }
    }
    private void CheckCollision()
    {
        print("SeeingIfIHit");
        if (Physics.SphereCast(tip.position, 0.1f,tip.rotation.eulerAngles, out RaycastHit hit,0.1f)) 
        {
            rb.interpolation = RigidbodyInterpolation.None;
            transform.parent = hit.transform;
            if (hit.transform.TryGetComponent(out Rigidbody body))
            {
                body.AddForce(rb.linearVelocity, ForceMode.Impulse);
            }
            Stop();
        }
    }

    private void Stop()
    {
        inAir = false;
        SetPhysics(false);
    }


}
