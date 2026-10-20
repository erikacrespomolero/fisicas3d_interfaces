using UnityEngine;
public class Perseguidor : MonoBehaviour {
  public delegate void JugadorAtrapadoHandler();
  public static event JugadorAtrapadoHandler OnJugadorAtrapado;
  public Transform jugador; 
  public float velocidad = 4f;
  public float distanciaCaptura = 1.2f; 
  private Rigidbody rb;
  private bool yaAtrapado = false;

  void Awake() {
    rb = GetComponent<Rigidbody>();
  }

  void FixedUpdate() {
    Vector3 direccion = jugador.position - rb.position;
    direccion.y = 0f;
    float distancia = direccion.magnitude;
    if (distancia <= distanciaCaptura) {
      if (!yaAtrapado) {
        yaAtrapado = true;
        Debug.Log("[Perseguidor] ¡Jugador atrapado!");
        OnJugadorAtrapado?.Invoke();
      }
    } else {
      yaAtrapado = false;
      if (distancia > 0.001f) {
        direccion.Normalize();
        rb.MovePosition(rb.position + direccion * velocidad * Time.fixedDeltaTime);
        rb.rotation = Quaternion.LookRotation(direccion);
      }
    }
  }
}