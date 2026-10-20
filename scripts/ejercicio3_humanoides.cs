using UnityEngine;
public class HumanoideObserver : MonoBehaviour {
  public Transform escudoSeleccionado;
  public Transform[] escudosTipo2;
  public float velocidad = 5f;

  private Rigidbody rb;
  private Renderer rend;
  private Transform objetivoActual;
  private bool moviendose = false;

  void Awake() {
    rb = GetComponent<Rigidbody>();
    rend = GetComponentInChildren<Renderer>();
  }
  void OnEnable() {
    NotifierCube.OnColisionHumanoide += Reaccionar;
  }
  void OnDisable() {
    NotifierCube.OnColisionHumanoide -= Reaccionar;
  }

  private void Reaccionar(int tipoHumanoideImpactado) {
    Transform objetivo = null;
    if (tipoHumanoideImpactado == 2 && CompareTag("HumanoideTipo1") && escudoSeleccionado != null) {
      objetivo = escudoSeleccionado;
    } else if (tipoHumanoideImpactado == 1 && CompareTag("HumanoideTipo2")) {
      objetivo = ObtenerEscudoTipo2MasCercano();
    }
    if (objetivo != null) {
      objetivoActual = objetivo;
      moviendose = true;
    }
  }

  private Transform ObtenerEscudoTipo2MasCercano() {
    Transform mejor = null;
    float mejorDist = Mathf.Infinity;
    foreach (Transform escudo in escudosTipo2) {
      if (escudo == null)
        continue;
      float d = Vector3.Distance(rb.position, escudo.position);
      if (d < mejorDist) {
        mejorDist = d;
        mejor = escudo;
      }
    }
    return mejor;
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

  private void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.CompareTag("EscudoTipo1") || collision.gameObject.CompareTag("EscudoTipo2")) {
      if (rend != null)
        rend.material.color = Color.yellow;
    }
  }
}