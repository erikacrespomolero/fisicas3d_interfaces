using UnityEngine;
using TMPro; 

public class CubeCollectorReward : MonoBehaviour {
  public int puntuacion = 0;
  public TextMeshProUGUI textoPuntuacion;
  public int recompensasOtorgadas = 0;
  public TextMeshProUGUI textoRecompensa; 
  public float duracionMensaje = 2f;     
  public AudioSource audioSource;
  public AudioClip musicaRecompensa;
  public ObjectSpawner spawner;
  private float timerMensaje = 0f;
  private bool mostrandoMensaje = false;

  private void Start() {
    ActualizarUI();
    if (textoRecompensa != null)
      textoRecompensa.gameObject.SetActive(false);
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
    ComprobarRecompensa();
  }

  private void ComprobarRecompensa() {
    int recompensasQueTocan = puntuacion / 100;
    while (recompensasOtorgadas < recompensasQueTocan) {
      recompensasOtorgadas++;
      OtorgarRecompensa();
    }
  }

  private void OtorgarRecompensa() {
    Debug.Log($"¡Recompensa #{recompensasOtorgadas}! (alcanzados {recompensasOtorgadas * 100} puntos)");
    if (textoRecompensa != null) {
      textoRecompensa.text = $"¡Recompensa #{recompensasOtorgadas}!";
      textoRecompensa.gameObject.SetActive(true);
      timerMensaje = duracionMensaje;
      mostrandoMensaje = true;
    }
    if (audioSource != null && musicaRecompensa != null)
      audioSource.PlayOneShot(musicaRecompensa);
    if (spawner != null)
      spawner.Llover();
  }

  private void Update() {
    if (mostrandoMensaje) {
      timerMensaje -= Time.deltaTime;
      if (timerMensaje <= 0f) {
        mostrandoMensaje = false;
        if (textoRecompensa != null)
          textoRecompensa.gameObject.SetActive(false);
      }
    }
  }

  private void ActualizarUI() {
    if (textoPuntuacion != null)
      textoPuntuacion.text = $"Puntuación: {puntuacion}";
  }
}