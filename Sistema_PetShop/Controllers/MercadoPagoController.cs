using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MercadoPago;
using MercadoPago.DataStructures.MerchantOrder;
using MercadoPago.DataStructures.Preference;
using MercadoPago.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_PetShop.ViewModels;
using Address = MercadoPago.DataStructures.Preference.Address;
using Item = MercadoPago.DataStructures.Preference.Item;
using Payer = MercadoPago.DataStructures.Preference.Payer;

namespace Sistema_PetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MercadoPagoController : ControllerBase
    {

        public void MercPago()
        {                       

            Response.Redirect("https://www.mercadopago.com.br/integrations/v1/web-payment-checkout.js");


        }


    }
}