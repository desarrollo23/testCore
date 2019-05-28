using Model;
using System.Collections.Generic;

namespace BL
{
    public static class Logica
    {
        public static List<Pais> ObtenerPaises() => DALC.Data.ObtenerPaises();
        public static bool CrearPais(Pais pais) => DALC.Data.CrearPais(pais);
    }
}
