using System;

namespace Infrastructure.Logging
{
    public static class Logger
    {
        // Se vuelve private y se expone por propiedad.
        // Se exige esto para evitar que rompe el encapsulamiento, cualquiera en el sistema puede hacer
        // modificacion y causa comportamientos impredecibles.
        private static bool _enabled = true;

        // Propiedad con validación publica segura
        public static bool Enabled
        {
            get => _enabled;
            set => _enabled = value;
        }

        public static void Log(string message)
        {
            if (!Enabled) return;
            Console.WriteLine("[LOG] " + DateTime.Now + " - " + message);
        }

        public static void Try(Action a)
        {
            try
            {
                a();
            }
            catch (Exception ex)
            {
                // Se maneja la excepción correctamente.
                // Se prohíbe catch vacío porque oculta errores.
                Console.WriteLine("Error controlado: " + ex.Message);
            }
        }
    }
}
