using CapaPresentacion.Validaciones.CausaAdministrar.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.CausaAdministrar.Validacon
{
    public class CausaEditarDatosGeneralesValidation : AbstractValidator<CausaAdministrarDatos>
    {
        public CausaEditarDatosGeneralesValidation()
        {
            RuleFor(x => x.txtCausa)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("La causa es obligatoria.")
                .MaximumLength(300).WithMessage("La causa debe tener maximo 300 caracteres.");
            RuleFor(x => x.cmbPrisionReclusion)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para prision/reclusion procedencia.")
                .NotEmpty().WithMessage("Debe ingresar un valor para prision/reclusio.");
            RuleFor(x => x.txtExpediente)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El expediente es obligatorio.")
                .Length(1, 50).WithMessage("El expediente debe tener maximo 50 caracteres.");
            RuleFor(x => x.cmbTipoDelito)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para tipo delito.")
                .NotEmpty().WithMessage("Debe ingresar un valor para tipo delito.")
                .Must(BeAnInteger).WithMessage("prision/reclusio debe ser valido.");
            RuleFor(x => x.cmbEstadoProcesal)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para estado procesal.")
                .NotEmpty().WithMessage("Debe ingresar un valor para estado procesal.");
            RuleFor(x => x.cmbJurisdiccion)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para jurisdiccion.")
                .NotEmpty().WithMessage("Debe ingresar un valor para jurisdiccion.");
            RuleFor(x => x.cmbJuzgado)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para juzgado.")
                .NotEmpty().WithMessage("Debe ingresar un valor para juzgado.")
                .NotEqual("0SINESP").WithMessage("Debe seleccionar un juzgado.");
            RuleFor(x => x.cmbOtroJuzgado)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para Otro Juzgado.")
                .NotEmpty().WithMessage("Debe ingresar un valor para Otro juzgado.");
            RuleFor(x => x.cmbReincidencia)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para reincidencia.")
                .NotEmpty().WithMessage("Debe ingresar un valor para reincidencia.");
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
