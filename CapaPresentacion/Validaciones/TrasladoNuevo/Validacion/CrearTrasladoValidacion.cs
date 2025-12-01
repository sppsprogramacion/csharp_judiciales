using CapaPresentacion.Validaciones.NuevoInterno.Datos;
using CapaPresentacion.Validaciones.TrasladoNuevo.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.TrasladoNuevo.Validacion
{
    public class CrearTrasladoValidacion : AbstractValidator<TrasladoNuevoDatos>
    {
        public CrearTrasladoValidacion()
        {

            RuleFor(x => x.txtIdIngreso)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para Id ingreso.")
                .Must(BeAnInteger).WithMessage("Id ingreso debe ser un numero entero.");
            RuleFor(x => x.cmbOrganismoDestino)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para Organismo destino.")
                .NotEmpty().WithMessage("Debe ingresar un valor para Organismo destino.")
                .Must(BeAnInteger).WithMessage("Organismo destino debe ser valido.");
            RuleFor(x => x.dtpFechaEgreso.ToString())
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Fecha de egreso es obligatoria");            
            RuleFor(x => x.txtDetalleTraslado)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Detalle traslado es obligatorio.")
                .Length(1, 1500).WithMessage("Detalle traslado debe tener maximo 1500 caracteres.");
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
    }
}
