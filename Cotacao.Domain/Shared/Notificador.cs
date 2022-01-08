using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotacao.Domain.Shared
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes;

        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public void Handle(Notificacao notificacao)
            => _notificacoes.Add(notificacao);

        public List<Notificacao> ObterNotificacoes()
            => _notificacoes;

        public string ObterNotificacoesString()
            => string.Join(Environment.NewLine, _notificacoes.Select(n => n.Mensagem));

        public bool TemNotificacao()
            => _notificacoes.Any();

    }

    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        string ObterNotificacoesString();
        void Handle(Notificacao notificacao);
    }
    public class Notificacao
    {
        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }

        public string Mensagem { get; }
    }
}
