using System;

namespace Dominio.Etidade
{
    public abstract class EntidadeBase
    {
        public int Id { get; private set; }
        public DateTime DataAtualizacao { get; private set; }

        protected void SetDataAtualizacao()
            => DataAtualizacao = DateTime.Now;
    }
}
