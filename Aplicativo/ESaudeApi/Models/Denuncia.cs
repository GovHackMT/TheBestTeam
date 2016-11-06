using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ESaudeApi.Models
{
    public class Denuncia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDenuncia { get; set; }

        public int IdDenunciaTipo { get; set; }
        public string CodigoUnidade { get; set; }
        
        [ForeignKey("FkDenunciaXUsuario")]
        public int IdUsuario { get; set; }


        public string Latitude { get; set; }

        public string Longitude { get; set; }
        //public string GeogCol1 { get; set; }
        //public string GeogCol2 { get; set; }
        public string Observacao { get; set; }


        public Usuario Usuario { get; set; }
    }
}
