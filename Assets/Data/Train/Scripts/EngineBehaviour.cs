using UnityEngine;

public class EngineBehaviour : MonoBehaviour
{

    [SerializeField]
    protected float speedLimit = 500f;
   // [SerializeField]
    //protected float startPower = 100f;
    [SerializeField]
    protected float maxPower = 500f;
    protected float currentPower;
    [SerializeField]
    protected ForceMode forceMode = ForceMode.VelocityChange;

    public float input = 0f;

    private Rigidbody rb;

    private void OnValidate()
    {
        rb ??= GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb ??= GetComponent<Rigidbody>();
        //SetCurrentPower(startPower);

    }

    public void SetCurrentPower(float newPower)
    {
        currentPower = newPower;
        return;
        float absPower = Mathf.Abs(newPower);
        float sign = Mathf.Sign(newPower);
        if (absPower > maxPower)
        {
            currentPower = newPower * sign;
            return;
        }
        currentPower = 0f;        
    
    }
    private void Update()
    {
        input = Input.GetAxis("Vertical");
       // input = 1f;

    /*    if (Input.GetKey(KeyCode.Q))
        {
            currentPower += 10f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            currentPower -= 10f;
        }*/

 //       var force = transform.forward * currentPower * input * Time.fixedDeltaTime;

        //     rb.AddForce(force, forceMode);
    }

    float curremtSpeed = 0f;
    public void FixedUpdate()
    {
        EngineFixedUpdate();
    }
    
    public void EngineFixedUpdate()
    {
        if (input == 0f)
         {
             return;
         }
//        curremtSpeed += maxPower * input * Time.deltaTime;
        currentPower += maxPower * input * Time.deltaTime;
         if (currentPower > maxPower)
        {
            currentPower = maxPower;
        }
        var force = transform.forward * currentPower;

        //rb.velocity += force;
        if (rb.velocity.magnitude < speedLimit)
        {
            rb.AddForce(force, forceMode);
        }
//        Debug.Log($"input = {input} forward = {transform.forward} force = {force}");
  //      Debug.Log($"position = {rb.position}rb.velocity = {rb.velocity} magnitude = {rb.velocity.magnitude}");
    }
    /* */
}
