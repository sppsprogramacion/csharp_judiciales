using CapaPresentacion.Validaciones.NuevoInterno.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.NuevoInterno.Validacion
{
    public class CrearInternoValidation : AbstractValidator<NuevoInternoDatos>
    {
        public CrearInternoValidation()
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
                .NotEmpty().WithMessage("El alias es obligatorio.")
                .Length(1, 200).WithMessage("El alias debe tener maximo 200 caracteres.");
            RuleFor(x => x.txtProntuario)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para prontuario.")
                .Must(BeAnInteger).WithMessage("El prontuario debe ser un numero entero.");
            RuleFor(x => x.txtDni)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para dni de visita.")
                .Must(BeAnInteger).WithMessage("El dni de visita debe ser un numero entero.");
            RuleFor(x => x.cmbSexo)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Debe ingresar un valor para sexo.")
                .NotEmpty().WithMessage("Debe ingresar un valor para sexo.")
                .Must(BeAnInteger).WithMessage("El sexo debe ser valido.");
            RuleFor(x => x.txtTalla)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe ingresar un valor para talla.")
                .Must(BeAnInteger).WithMessage("El talla debe ser un numero entero.");
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
    }
}
