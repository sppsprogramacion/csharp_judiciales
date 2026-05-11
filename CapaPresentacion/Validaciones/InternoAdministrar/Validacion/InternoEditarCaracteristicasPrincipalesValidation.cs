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
    public class InternoEditarCaracteristicasPrincipalesValidation : AbstractValidator<InternoAdministarDatos>
    {
        public InternoEditarCaracteristicasPrincipalesValidation()
        {
            
            RuleFor(x => x.cmbSexo)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para sexo.")
                .NotEmpty().WithMessage("Debe ingresar un valor para sexo.")
                .Must(BeAnInteger).WithMessage("El sexo debe ser valido.");
            RuleFor(x => x.txtTalla)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para talla.")
                .Must(BeADecimal).WithMessage("El talla debe ser un numero decimal con hasta 2 decimales.");
            RuleFor(x => x.cmbPiel)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para piel.")
                .NotEmpty().WithMessage("Debe ingresar un valor para piel.");
            RuleFor(x => x.cmbOjosColor)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para ojos color.")
                .NotEmpty().WithMessage("Debe ingresar un valor para ojos color.");
            RuleFor(x => x.cmbOjosTamanio)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para ojos tamaño.")
                .NotEmpty().WithMessage("Debe ingresar un valor para ojos tamaño.");
            RuleFor(x => x.cmbNarizForma)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para nariz forma.")
                .NotEmpty().WithMessage("Debe ingresar un valor para nariz forma.");
            RuleFor(x => x.cmbNarizTamanio)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para nariz tamaño.")
                .NotEmpty().WithMessage("Debe ingresar un valor para nariz tamaño.");
            RuleFor(x => x.cmbPeloTipo)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para pelo tipo.")
                .NotEmpty().WithMessage("Debe ingresar un valor para pelo tipo.");
            RuleFor(x => x.cmbPeloColor)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para pelo color.")
                .NotEmpty().WithMessage("Debe ingresar un valor para pelo color.");
            RuleFor(x => x.txtMarcasCorporales)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(500).WithMessage("parientes debe tener maximo 1000 caracteres.");

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

