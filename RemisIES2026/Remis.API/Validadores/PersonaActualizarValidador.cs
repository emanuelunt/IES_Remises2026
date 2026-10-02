using FluentValidation;
using Remis.API.DTOs.Persona;

namespace Remis.API.Validadores
{
    public class PersonaActualizarValidador : AbstractValidator<PersonaActualizarDto>
    {
        public PersonaActualizarValidador()
        {
            // Validacion del ID
            RuleFor(x => x.IdPersona).GreaterThan(0).WithMessage("El ID debe ser mayor a 0.");

            //Validacion del Apellido
            RuleFor(x => x.Apellido).NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no puede tener más de 50 caracteres.");

            //Validacion del Nombre
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            //Validacion del DNI
            RuleFor(x => x.Dni)
                .Matches(@"^\d{7,8}$").When(x => !string.IsNullOrEmpty(x.Dni))
                .WithMessage("El DNI debe contener entre 7 y 8 dígitos.");

            //Validacion del Teléfono
            RuleFor(x => x.Telefono)
                .Matches(@"^\+?\d{1,15}$").When(x => !string.IsNullOrEmpty(x.Telefono))
                .WithMessage("El teléfono debe contener solo dígitos y puede incluir un prefijo '+'.");

            //Validacion del Email
            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
                .WithMessage("El email no tiene un formato válido.");

            //Validacion de la Dirección
            RuleFor(x => x.Direccion)
                .MaximumLength(100).When(x => !string.IsNullOrEmpty(x.Direccion))
                .WithMessage("La dirección no puede superar los 100 caracteres.");

            //Validacion del campo Activo (opcional)
            RuleFor(x => x.Activo)
                .NotNull().WithMessage("El campo Activo es obligatorio.");
        }
    }    
}
