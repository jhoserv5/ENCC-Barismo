using UnityEngine;
using UnityEngine.InputSystem;

public class LiquidoVisual : MonoBehaviour
{
    [SerializeField] float velocidad = 0.5f;
    [SerializeField] float nivelMaximo = 1.1f;

    float nivel = 0f;
    Renderer rend;

    void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        if (kb.upArrowKey.isPressed)
            nivel += velocidad * Time.deltaTime;

        if (kb.downArrowKey.isPressed)
            nivel -= velocidad * Time.deltaTime;

        nivel = Mathf.Clamp(nivel, 0f, nivelMaximo);

        rend.material.SetFloat("_Nivel", nivel);
    }
}