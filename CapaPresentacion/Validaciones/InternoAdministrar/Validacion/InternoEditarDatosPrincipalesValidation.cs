using CapaPresentacion.Validaciones.InternoAdministrar.Datos;
using CapaPresentacion.Validaciones.NuevoInterno.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.InternoAdministrar.Validacion
{
    public class InternoEditarDatosPrincipalesValidation : AbstractValidator<InternoAdministarDatos>
    {
        public InternoEditarDatosPrincipalesValidation()
        {

            RuleFor(x => x.txtApellido)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .Length(1, 300).WithMessage("El apellido debe tener maximo 300 caracteres.");
            RuleFor(x => x.txtNombre)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .Length(1, 300).WithMessage("El nombre debe tener maximo 100 caracteres.");
            RuleFor(x => x.txtAlias)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(200).WithMessage("El alias debe tener maximo 200 caracteres.");
            RuleFor(x => x.txtProntuario)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para prontuario.")
                .Must(BeAnInteger).WithMessage("El prontuario debe ser un numero entero.");
            RuleFor(x => x.txtDni)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para dni.")
                .Must(BeAnInteger).WithMessage("El dni debe ser un numero entero.");            
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
