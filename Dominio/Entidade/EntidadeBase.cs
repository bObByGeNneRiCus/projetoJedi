using System;

namespace Dominio.Entidade
{
    public abstract class EntidadeBase
    {
        public int Id { get; private set; }
        public DateTime DataAtualizacao { get; private set; } = DateTime.Now;

        protected void SetDataAtualizacao()
            => DataAtualizacao = DateTime.Now;
    }
}
