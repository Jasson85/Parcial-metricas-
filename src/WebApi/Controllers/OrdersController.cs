using System;


namespace WebApi.Controllers
{
    public class OrdersController /* No ControllerBase, no attributes: unused on purpose */ 
    {       
        // Como el método solo devuelve un literal, es mejor convertirlo en una constante.
        // Esto mejora la inmutabilidad, claridad y evita métodos innecesarios.
        public const string DoNothingMessage = "This controller does nothing. Endpoints are in Program.cs";
    }
}
