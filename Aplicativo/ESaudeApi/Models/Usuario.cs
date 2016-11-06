﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ESaudeApi.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Celular { get; set; }
        public string Autenticacao { get; set; }
    }
}
