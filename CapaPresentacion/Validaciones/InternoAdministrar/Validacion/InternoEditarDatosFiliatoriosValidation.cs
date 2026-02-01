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
    public class InternoEditarDatosFiliatoriosValidation : AbstractValidator<InternoAdministarDatos>
    {
        public InternoEditarDatosFiliatoriosValidation()
        {

            RuleFor(x => x.cmbNacionalidad)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para nacionalidad.")
                .NotEmpty().WithMessage("Debe ingresar un valor para nacionalidad.");
            RuleFor(x => x.cmbProvinciaNacimiento)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para provincia nacimiento.")
                .NotEmpty().WithMessage("Debe ingresar un valor para provincia nacimiento.");
            RuleFor(x => x.cmbDepartamentoNacimiento)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para departamento nacimiento.")
                .NotEmpty().WithMessage("Debe ingresar un valor para departamento nacimiento.")
                .Must(BeAnInteger).WithMessage("El departamento nacimiento debe ser valido.");
            RuleFor(x => x.txtCiudadNacimiento)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("La ciudad es obligatoria.")
                .Length(1, 100).WithMessage("La ciudad debe tener maximo 100 caracteres.");
            RuleFor(x => x.dtpFechaNacimiento.ToString())
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("La fecha de naciminto es obligatoria");
            RuleFor(x => x.cmbEstadoCivil)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para estado civil.")
                .NotEmpty().WithMessage("Debe ingresar un valor para estado civil.")
                .Must(BeAnInteger).WithMessage("El departamento nacimiento debe ser valido.");
            RuleFor(x => x.cmbZonaResidencia)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para zona residencia.")
                .NotEmpty().WithMessage("Debe ingresar un valor para zona residencia.");
            RuleFor(x => x.txtTelefono)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El telefono es obligatorio.")
                .Length(1, 100).WithMessage("El telefono debe tener maximo 100 caracteres.");
            RuleFor(x => x.txtPadre)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(200).WithMessage("padre debe tener maximo 100 caracteres.");
            RuleFor(x => x.txtMadre)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(200).WithMessage("madre debe tener maximo 200 caracteres.");
            RuleFor(x => x.txtParientes)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(500).WithMessage("parientes debe tener maximo 500 caracteres.");
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
