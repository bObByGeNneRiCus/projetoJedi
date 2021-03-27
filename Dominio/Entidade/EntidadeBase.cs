using System;
using System.ComponentModel;

namespace Dominio.Entidade
{
    public abstract class EntidadeBase
    {
        public int Id { get; set; }

        [Description("DATA_ATUALIZACAO")]
        public DateTime DataAtualizacao { get; set; } = DateTime.Now;

        protected void SetDataAtualizacao()
            => DataAtualizacao = DateTime.Now;
    }
}
