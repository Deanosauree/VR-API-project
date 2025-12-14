using UnityEngine;
using UnityEngine.Events;

public class VRButton : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private Transform spawnTransform;

    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
        if (spawnTransform == null) 
        { 
            spawnTransform = transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            print(other.gameObject);
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.015f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void SpawnObject(GameObject thisObject)
    {
        print("Ok so I should be spawning" + thisObject);
        GameObject objectInstance = Instantiate(thisObject);
        objectInstance.transform.localPosition = spawnTransform.position;
    }


}
