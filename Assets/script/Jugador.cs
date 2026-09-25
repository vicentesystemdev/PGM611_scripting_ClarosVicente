using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
namespace logica_de_jugador{
    public class Jugador : MonoBehaviour
    {
        public float velocidad = 3f;
        public float fuerzaSalto = 4.5f;

        private Rigidbody2D rb;
        private Animator animator;
        private float movimiento;
        private bool enSuelo = false;

        public Transform comprobadorPiso;
        public float radioComprobadorPiso = 0.1f;
        public LayerMask layerPiso;
        private int cantAbejas = 0;
        public TMP_Text textoAbejas;
        
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
                rb = GetComponent<Rigidbody2D>();
                animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            movimiento = Input.GetAxisRaw("Horizontal");
            // Girar personaje según dirección
            if (movimiento != 0)
            {
                transform.localScale = new Vector3(
                Mathf.Sign(movimiento),
                transform.localScale.y,
                transform.localScale.z
                );
            }    
            animator.SetFloat("Velocidad", Mathf.Abs(movimiento));
            animator.SetFloat("VelocidadVertical", rb.linearVelocity.y);
            animator.SetBool("estaEnPiso", enSuelo);
            // Espacio = salto
            if (Input.GetButtonDown("Jump") && enSuelo)
            {
                rb.linearVelocity = new Vector2(
                    rb.linearVelocity.x,
                    fuerzaSalto
                );
            }

        }
        void FixedUpdate()
        {
            enSuelo = Physics2D.OverlapCircle(
             comprobadorPiso.position,
             radioComprobadorPiso,
             layerPiso
             ) != null;
            rb.linearVelocity = new Vector2(
                movimiento * velocidad,
                rb.linearVelocity.y
            );
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("abejita"))
             {
                Destroy(collision.gameObject);
                cantAbejas++;
                textoAbejas.text = "x " + cantAbejas;
             }
             if (collision.transform.CompareTag("puerquito"))
            {
                SceneManager.LoadScene(
                    SceneManager.GetActiveScene().name
                 );
             }
            
        }
        // CARACOL: usa colisión normal
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("caracol"))
        {
             foreach (ContactPoint2D contacto in collision.contacts)
            {
            // El jugador cayó encima del caracol
                    if (contacto.normal.y > 0.5f && rb.linearVelocity.y <= 0)
                {
                 Destroy(collision.gameObject);

                    // Pequeño rebote después del pisotón
                      rb.linearVelocity = new Vector2(
                     rb.linearVelocity.x,
                     fuerzaSalto * 0.6f
                    );

                  break;
                 }
             }
            }
        }


    }
}
public class Enemigo 
{
    

}
#region Mundo
namespace herramientas {
        namespace calculos{
            using logica_de_jugador;
            public class Ejemplo {
                public void metodoEjemplo(){
                    Jugador j;
                }
            }
        }
        namespace conectividad{
            public partial class herramientas{
                
            }

        }
}    

namespace vicente
{
    namespace test
    {
        using herramientas.calculos;

        public class Prueba{
        public void metodoTest(){
            Ejemplo e;
            }
        }    
    }
}

#endregion