using System;

namespace LojaVirtual.Web.Models
{
    public class Paginacao
    {
        /// <summary>
        /// TOTAL DE ITENS NO BANCO
        /// </summary>
        public int ItensTotal { get; set; }
        /// <summary>
        /// TOTAL DE ITENS POR PAGINA
        /// </summary>
        public int ItensPorPagina { get; set; }
        /// <summary>
        /// QUAL A PAGINA EXIBIDA NO MOMENTO
        /// </summary>
        public int PaginaAtual { get; set; }
        public int TotaPagina
        {
            get
            {
                return (int)Math.Ceiling((decimal)ItensTotal / ItensPorPagina);
            }
        }
    }
}