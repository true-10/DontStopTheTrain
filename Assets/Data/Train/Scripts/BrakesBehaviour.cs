using UnityEngine;

public class BrakesBehaviour : MonoBehaviour
{

    [SerializeField]
    protected float power = 100f;

    protected bool input;

    private Rigidbody rb;

    private void OnValidate()
    {
        rb ??= GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb ??= GetComponent<Rigidbody>();

    }

    private void Update()
    {
        input = Input.GetKey(KeyCode.Space);
    }

    public void FixedUpdate()
    {
        if (input == false)
        {
            rb.drag = 1f;
            return;
        }

        rb.drag += power * Time.fixedDeltaTime;

    }

}
