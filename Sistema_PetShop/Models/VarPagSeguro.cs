using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_PetShop.Models
{
    public class VarPagSeguro
    {


        public VarPagSeguro()
        {
            this.varPagSeguro_Produtos = new List<VarPagSeguro>();
        }

        public string email;
        public string token;
        public string currency;

        public List<string> itemId1 = new List<string>();
        public List<string> itemDescription1 = new List<string>();
        public List<string> itemAmount1 = new List<string>();
        public List<string> itemQuantity1 = new List<string>();
                
        public string reference;
        public string senderName;
        public string senderAreaCode;
        public string senderPhone;
        public string senderCPF;
        public string senderBornDate;
        public string senderEmail;
        public string shippingType;
        public string shippingAddressStreet;
        public string shippingAddressNumber;
        public string shippingAddressComplement;
        public string shippingAddressDistrict;
        public string shippingAddressPostalCode;
        public string shippingAddressCity;
        public string shippingAddressState;
        public string shippingAddressCountry;
        public bool shippingAddressRequired;
        public string extraAmount;
        public string redirectURL;
        public string type;
        public string username;
        public string password;

        public List<VarPagSeguro> varPagSeguro_Produtos;


    }
}
