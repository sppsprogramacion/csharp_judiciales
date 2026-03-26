using CapaPresentacion.Validaciones.CausaNueva.Datos;
using CapaPresentacion.Validaciones.HistorialProcesalNuevo.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.HistorialProcesalNuevo.Validacion
{
    public class HistorialProcesalNuevoValidation : AbstractValidator<HistorialProcesalNuevoDatos>
    {
        public HistorialProcesalNuevoValidation()
        {            
            RuleFor(x => x.cmbTipoNovedad)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para tipo novedad.")
                .NotEmpty().WithMessage("Debe ingresar un valor para tipo novedad.");
            RuleFor(x => x.txtDetalleNovedad)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El detalle es obligatoria.")
                .MaximumLength(1000).WithMessage("El detalle debe tener maximo 1000 caracteres.");

        }


        private bool BeAnInteger(string numero)
        {
            int numerox;
            try
            {
                numerox = int.Parse(numero);
            }
            catch
            {
                return false;
            }

            return numerox % 1 == 0;
        }

        private bool BeADecimal(string value)
        {
            // Reemplaza coma por punto por si el usuario escribe coma
            value = value.Replace(',', '.');

            // Validar formato: número entero o decimal con 1 o 2 decimales
            return Regex.IsMatch(value, @"^\d+(\.\d{1,2})?$");
        }
    }
}
