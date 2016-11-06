using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ESaudeApi.Models
{
    public class DenunciaMovimento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDenunciaMovimento { get; set; }

        [ForeignKey("FkDenunciaMovimentoXDenuncia")]
        public int IdDenuncia { get; set; }

        [ForeignKey("FkDenunciaMovimentoXUsuario")]
        public int IdUsuario { get; set; }

        [ForeignKey("FkDenunciaMovimentoXDenunciaMovimentoTipo")]
        public int IdDenunciaMovimentoTipo { get; set; }

        public DateTime DataCadastro { get; set; }
        public string Caminho { get; set; }
    }
}
