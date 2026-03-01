using CapaPresentacion.Validaciones.CausaAdministrar.Datos;
using CapaPresentacion.Validaciones.CausaNueva.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.CausaAdministrar.Validacon
{
    public class CausaEstablecerCondenaValidation: AbstractValidator<CausaAdministrarDatos>
    {
        public CausaEstablecerCondenaValidation()
        {
            RuleFor(x => x.cmbTribunalCondena)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para tribunal que condena.")
                .NotEmpty().WithMessage("Debe ingresar un valor para tribunal que condena.")
                .NotEqual("0SINESP").WithMessage("Debe seleccionar un tribunal que condena.");
            RuleFor(x => x.txtPenaAnios)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para pena meses.")
                .NotEmpty().WithMessage("Debe ingresar un valor para pena meses.")
                .Must(BeAnInteger).WithMessage("pena meses debe ser un numero entero.");
            RuleFor(x => x.txtPenaMeses)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para pena dias.")
                .NotEmpty().WithMessage("Debe ingresar un valor para pena dias.")
                .Must(BeAnInteger).WithMessage("pena dias debe ser un numero entero.");
            RuleFor(x => x.txtPenaDias)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para pena dias.")
                .NotEmpty().WithMessage("Debe ingresar un valor para pena dias.")
                .Must(BeAnInteger).WithMessage("pena dias debe ser un numero entero.");
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
