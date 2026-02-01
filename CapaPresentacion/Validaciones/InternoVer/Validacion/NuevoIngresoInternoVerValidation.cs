using CapaPresentacion.Validaciones.NuevoInterno.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.InternoVer.Validacion
{
    public class NuevoIngresoInternoVerValidation : AbstractValidator<NuevoIngresoNuevoIntDatos>
    {
        public NuevoIngresoInternoVerValidation()
        {
            RuleFor(x => x.cmbOrganismoExternoProcedencia)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para organismo externo.")
                .NotEmpty().WithMessage("Debe ingresar un valor para organismo externo.")
                .Must(BeAnInteger).WithMessage("El organismo externo debe ser valido.");
            RuleFor(x => x.txtDetalleProceExterno)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(200).WithMessage("El detalle debe tener maximo 200 caracteres.");
            RuleFor(x => x.txtProntuarioPolicial)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El prontuario policial es obligatorio.")
                .Length(1, 50).WithMessage("El prontuario policial debe tener maximo 50 caracteres.");
            RuleFor(x => x.cmbOrganismoSppsProcesencia)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para organismo procedencia.")
                .NotEmpty().WithMessage("Debe ingresar un valor para organismo procedencia.")
                .Must(BeAnInteger).WithMessage("El organismo procedencia debe ser valido.");
            RuleFor(x => x.txtDetalleProceSpps)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(200).WithMessage("El detalle debe tener maximo 200 caracteres.");
            RuleFor(x => x.cmbEstadoProcesal)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para estado procesal.")
                .NotEmpty().WithMessage("Debe ingresar un valor para estado procesal.");
            RuleFor(x => x.cmbJurisdiccion)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para jurisdiccion.")
                .NotEmpty().WithMessage("Debe ingresar un valor para jurisdiccion.");
            RuleFor(x => x.cmbOtraJurisdiccion)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para otra jurisdiccion.")
                .NotEmpty().WithMessage("Debe ingresar un valor para otra jurisdiccion.");
            RuleFor(x => x.cmbReingreso)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para reingreso.")
                .NotEmpty().WithMessage("Debe ingresar un valor para reingreso.");
            RuleFor(x => x.txtNumeroReingreso)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para numero reingreso.")
                .Must(BeAnInteger).WithMessage("numero reingreso debe ser un numero entero.");
            RuleFor(x => x.cmbTipoDefensor)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para tipo defensor.")
                .NotEmpty().WithMessage("Debe ingresar un valor para tipo defensor.");
            RuleFor(x => x.txtAbogado)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(200).WithMessage("abogado debe tener maximo 200 caracteres.");

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
