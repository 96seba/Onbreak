using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Modelo
{
    public enum EnumActividad
    {
        NoSeleccionado,
        Agropecuario,
        Minera,
        Manufactura,
        Comercio,
        Hoteleria,
        Alimentos,
        Transporte,
        Servicios
    }

    public enum EnumTipo
    {
        NoSeleccionado,
        SPA,
        EIRL,
        Limitada,
        SociedadAnonima
    }

    public enum EnumTipoEvento
    {
        NoSeleccionado,
        CoffeeBreak_LightBreak,
        CoffeeBreak_JournalBreak,
        CoffeeBreak_DayBreak,
        Cocktail_QuickCocktail,
        Cocktail_AmbientCocktail,
        CenasEjecutiva,
        CenasCelebracion
    }


}
