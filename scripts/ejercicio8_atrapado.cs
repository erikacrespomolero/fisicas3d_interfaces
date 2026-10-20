using UnityEngine;
public class GestorAtrapado : MonoBehaviour {
  public AudioSource audioSource;
  public AudioClip musicaAtrapado;
  public Light luzEscena;
  public float intensidadOscura = 0.15f;
  public float velocidadOscurecer = 1.5f;
  private float intensidadObjetivo;
  
  void Start() {
    if (luzEscena != null)
      intensidadObjetivo = luzEscena.intensity; 
  }
  void OnEnable() {
    Perseguidor.OnJugadorAtrapado += Reaccionar;
  }
  void OnDisable() {
    Perseguidor.OnJugadorAtrapado -= Reaccionar;
  }

  private void Reaccionar() {
    if (audioSource != null && musicaAtrapado != null)
      audioSource.PlayOneShot(musicaAtrapado);

    if (luzEscena != null)
      intensidadObjetivo = intensidadOscura;
  }

  void Update() {
    if (luzEscena != null)
      luzEscena.intensity = Mathf.Lerp(luzEscena.intensity, intensidadObjetivo, velocidadOscurecer * Time.deltaTime);
  }
}