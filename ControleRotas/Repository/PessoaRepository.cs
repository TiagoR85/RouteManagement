using ControleRotas.Context;
using ControleRotas.Models;
using ControleRotas.Repository.Interfaces;
using System;

namespace ControleRotas.Repository
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        private IEnderecoRepository enderecoRepository;
        private ITelefoneRepository telefoneRepository;
        private IEmailRepository emailRepository;
        private IAgendaRepository agendaRepository;

        public PessoaRepository(RouteContext context) : base(context)
        {
            enderecoRepository = new EnderecoRepository(Context);
            telefoneRepository = new TelefoneRepository(Context);
            emailRepository = new EmailRepository(Context);
            agendaRepository = new AgendaRepository(Context);
        }

        public override Pessoa GetById(int id)
        {
            var p = base.GetById(id);
            p.Telefones = telefoneRepository.GetPhoneByPeople(p);
            p.Enderecos = enderecoRepository.GetAdressByPeople(p);
            p.Emails = emailRepository.GetEmailByPeople(p);
            p.Agendas = agendaRepository.GetAll();
            return p;
        }

        public override void SetActive(int id, bool active)
        {
            var entity = base.GetById(id);
            entity.DataExclusao = active ? null : (DateTime?)DateTime.Now;
            base.Save();
        }
    }
}
