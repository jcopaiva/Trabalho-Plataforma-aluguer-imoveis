using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebAppES.Models
{
    public class RoleViewModel
    {
        public RoleViewModel() { }

        public RoleViewModel(ApplicationRole role)
        {
            Id = role.Id;
            TipoConta = role.Name;
        }

        public string Id { get; set; }
        [DisplayName("Tipo de Conta")]
        public string TipoConta { get; set; }
    }
}