using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectWebApplicatie.Models;

namespace ProjectWebApplicatie.Logic
{
    public class ShoppingCartActions
    {
        public string ShoppingCartId { get; set; }

        private ProjectWebApplicatieContextDB db = new ProjectWebApplicatieContextDB();

        public const string CartSessionId = "CardId";
    }
}