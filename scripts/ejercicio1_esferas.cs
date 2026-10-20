using UnityEngine;
public class ObserverSphere : MonoBehaviour {
  public Transform objetivoTipo1;
  public Transform cilindro;
  public float velocidad = 5f;

  private Rigidbody rb;
  private Transform objetivoActual;
  private bool moviendose = false;

  void Awake() {
    rb = GetComponent<Rigidbody>();
  }
  void OnEnable() {
    NotifierCylinder.OnCollisionWithCube += ReactToCollision;
  }
  void OnDisable() {
    NotifierCylinder.OnCollisionWithCube -= ReactToCollision;
  }
  private void ReactToCollision() {
    if (CompareTag("tipo1") && objetivoTipo1 != null) {
      objetivoActual = objetivoTipo1;
      moviendose = true;
    } else if (CompareTag("tipo2") && cilindro != null) {
      objetivoActual = cilindro;
      moviendose = true;
    }
  }
  void FixedUpdate() {
    if (!moviendose || objetivoActual == null)
      return;
    if (Vector3.Distance(rb.position, objetivoActual.position) > 0.1f) {
      rb.MovePosition(Vector3.MoveTowards(rb.position, objetivoActual.position, velocidad * Time.fixedDeltaTime));
    } else {
      moviendose = false;
      objetivoActual = null;
    }
  }
}