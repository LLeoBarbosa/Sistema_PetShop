using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MercadoPago;
using MercadoPago.Common;
using MercadoPago.DataStructures.Preference;
using MercadoPago.Resources;
using Microsoft.EntityFrameworkCore;
using Sistema_PetShop.Context;
using Sistema_PetShop.ViewModels;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace Sistema_PetShop.Models
{
    public class MercadoPago
    {
        public MercadoPago()
        {

        }

        public Preference Pagamento(decimal total)
        {

            //DateTime data = Convert.ToDateTime(string.Format("{0:d/M/yyyy}", datavenda));

            //var produto = _aplicacaoDbContext.Produtos_Pedidos.Include(p => p.Produto).Where(pp => pp.NumeroPedido == numpedido && pp.DataVenda == data && pp.ProdutoId == pp.Produto.ProdutoId).ToList();
            #region
            Preference preference = new Preference()
            {
                UserAccessToken = "TEST-148862299385815-111502-ff6688580c895c3d90d310c44f7761f5-672693631",
            };

            Payer payer = new Payer()
            {
                //informações do comprador
                Name = "Leo",
                Surname = "Barbosa",
                Email = "leo@leo.com",
                Phone = new Phone()
                {
                    AreaCode = "11",
                    Number = "4444-4444"
                },

                //identificação pessoal
                Identification = new Identification()
                {
                    Type = "CPF",
                    Number = "19119119100"
                },

                //endereço do comprador
                Address = new Address()
                {
                    StreetName = "Rua E",
                    StreetNumber = int.Parse("123"),
                    ZipCode = "06233200"
                }

            };

            //for (int i = 0; i < 3; i++)
            //{

            preference.Items.Add(

               new Item()
               {
                       //Id = "1234",
                       Title = "Total a pagar:",
                       //Description = "Descrição detalhada",

                       Quantity = 1,
                       //UnitPrice = (decimal)9.29,
                       UnitPrice = total,
                       //CurrencyId = MercadoPago.Common.CurrencyId,
               }

            );

            //}

            BackUrls backUrls = new BackUrls()
            {
                //Success = MercadoPago.Common.AutoReturnType.approved.ToString()
                Success = "https://localhost:44358/status/index",
                Failure = "",
                Pending = "",

            };

            //preference.Items.Add(

            //        new Item()
            //        {
            //            Id = "1234",
            //            Title = "Racao Umida",
            //            Description = "Descrição detalhada",

            //            Quantity = 1,
            //            UnitPrice = (decimal)9.29,
            //            //CurrencyId = MercadoPago.Common.CurrencyId,
            //        }

            //);

            #endregion

            #region
            //***********************************************************************************************************************
            //***********************************************************************************************************************

            //var preference = new Preference
            //{
            //    UserAccessToken = "TEST-148862299385815-111502-ff6688580c895c3d90d310c44f7761f5-672693631",

            //    Items =
            //    {
            //         new Item
            //         {
            //                Id = "1234",
            //                Title = "Racao Umida",
            //                Description = "Descrição detalhada",

            //                Quantity = 1,
            //                UnitPrice = (decimal)9.29,
            //                CurrencyId = CurrencyId.BRL,
            //         }

            //    },

            //    Payer = new Payer
            //    {
            //        Name = "Leo",
            //        Surname = "Barbosa",
            //        Email = "leo@leo.com",
            //        Phone = new Phone
            //        {
            //            AreaCode = "11",
            //            Number = "4444-4444"
            //        },
            //        Identification = new Identification
            //        {
            //            Type = "CPF",
            //            Number = "19119119100"
            //        },
            //        Address = new Address
            //        {
            //            StreetName = "Rua E",
            //            StreetNumber = int.Parse("123"),
            //            ZipCode = "06233200"
            //        }
            //    },
            //    BackUrls = new BackUrls
            //    {
            //        Success = "https://localhost:44358/status/index",
            //        Failure = "",
            //        Pending = "",

            //    }

            //};
            #endregion

            preference.Save();

            return preference;
        }


    }
}
