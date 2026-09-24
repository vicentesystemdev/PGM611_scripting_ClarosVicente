using UnityEngine;

namespace logica_de_jugador{
    public class Jugador : MonoBehaviour
    {
        public float velocidad = 3f;
        public float fuerzaSalto = 4.5f;

        private Rigidbody2D rb;
        private Animator animator;
        private float movimiento;
        private bool enSuelo = false;

        
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
                rb = GetComponent<Rigidbody2D>();
                animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            movimiento = 0;

            // A = atrás
            if (Input.GetKey(KeyCode.A))
            {
                movimiento = -1;
            }

            // S = adelante
            if (Input.GetKey(KeyCode.S))
            {
                movimiento = 1;
            }
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
            // Espacio = salto
            if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
            {
                rb.linearVelocity = new Vector2(
                    rb.linearVelocity.x,
                    fuerzaSalto
                );
            }

        }
        void FixedUpdate()
        {
            rb.linearVelocity = new Vector2(
                movimiento * velocidad,
                rb.linearVelocity.y
            );
        }
        void OnCollisionStay2D(Collision2D collision)
        {
            foreach (ContactPoint2D contacto in collision.contacts)
            {
                if (contacto.normal.y > 0.5f)
                {
                    enSuelo = true;
                }
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            enSuelo = false;
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