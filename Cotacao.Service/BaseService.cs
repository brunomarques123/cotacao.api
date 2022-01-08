using Cotacao.Domain.Shared;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Configuration;

namespace Cotacao.Service
{
    public abstract class BaseService
    {
        protected readonly ConfigurationViewModel _configuration;
        protected readonly INotificador _notificador;

        public BaseService(IConfiguration configuration, INotificador notificador)
        {
            _configuration = new ConfigurationViewModel(configuration);
            _notificador = notificador;
        }

        protected void NotificarValidacao(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected void NotificarValidacao(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                NotificarValidacao(error.ErrorMessage);
            }
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : BaseModel
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            NotificarValidacao(validator);

            return false;
        }

    }
}