using UnityEngine;
public class ObservadorNPC : MonoBehaviour {
  public Transform jugador;

  private Rigidbody rb;

  void Awake() {
    rb = GetComponent<Rigidbody>();
  }
  void OnEnable() {
    Perseguidor.OnJugadorAtrapado += MirarAlJugador;
  }
  void OnDisable() {
    Perseguidor.OnJugadorAtrapado -= MirarAlJugador;
  }

  private void MirarAlJugador() {
    Vector3 direccion = jugador.position - rb.position;
    direccion.y = 0f;
    if (direccion.sqrMagnitude > 0.001f)
      rb.rotation = Quaternion.LookRotation(direccion);
  }
}