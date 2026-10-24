using UnityEngine; 
using UnityEngine.UI;
using TMPro;

public enum MetodoCafe { V60, PrensaFrancesa, AeroPress, Chemex }
public enum PerfilCafe { Fuerte, Equilibrado, Suave }

// Un pedido = qué cliente, qué método y qué perfil de café pide.
public class PedidoCafe
{
    public int cliente;
    public MetodoCafe metodo;
    public PerfilCafe perfil;
}

public class PedidoManager : MonoBehaviour
{
    [Header("Imágenes")]
    [SerializeField] private Sprite[] clientes;        // los 6 clientes 
    [SerializeField] private Sprite[] imagenesMetodo;  // V60, Prensa, AeroPress, Chemex

    [Header("UI del panel")]
    [SerializeField] private Image imgCliente;
    [SerializeField] private Image imgMetodo;
    [SerializeField] private TMP_Text txtMetodo;
    [SerializeField] private TMP_Text txtTiempo;
    [SerializeField] private TMP_Text txtPerfil;

    private static readonly string[] nombresMetodo =
        { "V60", "Prensa Francesa", "AeroPress", "Chemex" };
    private static readonly string[] nombresPerfil =
        { "Café fuerte", "Café equilibrado", "Café suave" };

    // Tiempo objetivo en segundos. Son valores de prueba: se ajustan luego.
    private static readonly int[] segundosMetodo = { 180, 240, 120, 270 };

    public PedidoCafe PedidoActual { get; private set; }

    private void Start()
    {
        NuevoPedido();
    }

    public void NuevoPedido()
    {
        PedidoActual = new PedidoCafe
        {
            cliente = Random.Range(0, clientes.Length),
            metodo = (MetodoCafe)Random.Range(0, 4),
            perfil = (PerfilCafe)Random.Range(0, 3)
        };
        MostrarPedido();
    }

    private void MostrarPedido()
    {
        int m = (int)PedidoActual.metodo;
        int p = (int)PedidoActual.perfil;
        int s = segundosMetodo[m];

        imgCliente.sprite = clientes[PedidoActual.cliente];
        imgMetodo.sprite = imagenesMetodo[m];
        txtMetodo.text = nombresMetodo[m].ToUpper();
        txtTiempo.text = string.Format("Tiempo: {0}:{1:00}", s / 60, s % 60);
        txtPerfil.text = nombresPerfil[p];
    }
}