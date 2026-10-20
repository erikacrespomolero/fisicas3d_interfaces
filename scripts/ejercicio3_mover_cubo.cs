using UnityEngine;
public class CubeController : MonoBehaviour {
  public float velocidad = 8f;
  private Rigidbody rb;
  void Awake() {
    rb = GetComponent<Rigidbody>();
    rb.constraints = RigidbodyConstraints.FreezeRotation;
  }
  void FixedUpdate() {
    float h = Input.GetAxisRaw("Horizontal");
    float v = Input.GetAxisRaw("Vertical");
    Vector3 direccion = new Vector3(h, 0f, v).normalized;
    rb.linearVelocity = new Vector3(direccion.x * velocidad, rb.linearVelocity.y, direccion.z * velocidad);
  }
}