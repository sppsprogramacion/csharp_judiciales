using CapaPresentacion.DomicilioEditar.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaPresentacion.DomicilioEditar.Validacion
{
    public class DomicilioInternoEditarValidacion : AbstractValidator<DomicilioInternoEditarDatos>
    {
        public DomicilioInternoEditarValidacion()
        {
            RuleFor(x => x.cmbPais)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para pais.")
                .NotEmpty().WithMessage("Debe ingresar un valor para pais.");
            RuleFor(x => x.cmbProvincia)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para provincia.")
                .NotEmpty().WithMessage("Debe ingresar un valor para provincial.");
            RuleFor(x => x.cmbDepartamento)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para departamento.")
                .NotEmpty().WithMessage("Debe ingresar un valor para departamento.")
                .Must(BeAnInteger).WithMessage("departamento debe ser valido.");
            RuleFor(x => x.cmbMunicipio)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para municipio.")
                .NotEmpty().WithMessage("Debe ingresar un valor para municipio.")
                .Must(BeAnInteger).WithMessage("municipio debe ser valido.");
            RuleFor(x => x.txtCiudad)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("ciudad es obligatorio.")
                .Length(1, 100).WithMessage("ciudad debe tener maximo 100 caracteres.");
            RuleFor(x => x.txtBarrio)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("barrio es obligatorio.")
                .Length(1, 100).WithMessage("barrio debe tener maximo 100 caracteres.");
            RuleFor(x => x.txtDireccion)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("direccion es obligatorio.")
                .Length(1, 100).WithMessage("direccion debe tener maximo 100 caracteres.");
            RuleFor(x => x.txtNumDomicilio)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("numero domicilio es obligatorio.")
                .Must(BeAnInteger).WithMessage("numero domicilio debe ser un numero.");
            RuleFor(x => x.cmbZonaResidencia)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para zona residencia.")
                .NotEmpty().WithMessage("Debe ingresar un valor para zona residencia.");
            RuleFor(x => x.txtTelefono)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("telefono es obligatorio.")
                .Length(1, 30).WithMessage("telefono debe tener maximo 100 caracteres.");

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
