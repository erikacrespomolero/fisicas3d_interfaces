using UnityEngine;
using TMPro; 

public class PlayerCollector : MonoBehaviour {
  public int puntuacion = 0;
  public TextMeshProUGUI textoPuntuacion;
  private void Start() {
    ActualizarUI();
  }
  private void OnEnable() {
    Perseguidor.OnJugadorAtrapado += ResetearPuntuacion;
  }
  private void OnDisable() {
    Perseguidor.OnJugadorAtrapado -= ResetearPuntuacion;
  }

  private void OnTriggerEnter(Collider other) {
    if (other.CompareTag("EscudoTipo1")) {
      SumarPuntos(5);
      Destroy(other.gameObject);
    } else if (other.CompareTag("EscudoTipo2")) {
      SumarPuntos(10);
      Destroy(other.gameObject);
    } 
  }

  private void SumarPuntos(int cantidad) {
    puntuacion += cantidad;
    Debug.Log($"Escudo recogido (+{cantidad}). Puntuación total: {puntuacion}");
    ActualizarUI();
  }

  private void ResetearPuntuacion() {
    Debug.Log("[PlayerCollector] Puntuación reiniciada a 0");
    puntuacion = 0;
    ActualizarUI();
  }

  private void ActualizarUI() {
    if (textoPuntuacion != null)
      textoPuntuacion.text = $"Puntuación: {puntuacion}";
  }
}