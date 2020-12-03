using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_PetShop.Context;

namespace Sistema_PetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        
        private readonly AplicacaoDbContext _aplicacaoDbContext;
            
        public ServiceController(AplicacaoDbContext aplicacaoDbContext)
        {
            _aplicacaoDbContext = aplicacaoDbContext;
        }

        //string url = @"https://ws.sandbox.pagseguro.uol.com.br/v2/checkout?username=itbl.financeiro@outlook.com.br&password=p@gU72&guR0_2081";
        string url = @"https://ws.sandbox.pagseguro.uol.com.br/v2/checkout?";
        
        //string url = @"https://ws.sandbox.pagseguro.uol.com.br/v2/checkout?username=v39732255024308213464@sandbox.pagseguro.com.br&password=bymhc309lwH6d1a9";

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage httpResponseMessage;

        Uri uri;

        string _data = "";

        public void PagSeguro(int numpedido, string datavenda)
        {
            #region
            //        currency: BRL
            //itemId1:0001
            //itemDescription1: Notebook Prata
            //itemAmount1: 100.00
            //itemQuantity1: 1
            //itemWeight1: 1000
            //reference: REF1234
            // senderName:Jose Comprador
            //senderAreaCode: 11
            //senderPhone: 56713293
            //senderCPF: 38440987803
            //senderBornDate: 12 / 03 / 1990
            //senderEmail: email @sandbox.pagseguro.com.br
            //  shippingType:1
            //shippingAddressStreet: Av.Brig.Faria Lima
            //shippingAddressNumber: 1384
            //shippingAddressComplement: 2o andar
            //shippingAddressDistrict: Jardim Paulistano
            //shippingAddressPostalCode: 01452002
            //shippingAddressCity: Sao Paulo
            //shippingAddressState: SP
            // shippingAddressCountry:BRA
            // extraAmount:-0.01
            //redirectURL: http://sitedocliente.com
            //        notificationURL: https://url_de_notificacao.com
            //        maxUses: 1
            //maxAge: 3000
            //shippingCost: 0.00

            //Inicializando a Uri
            #endregion

            DateTime data = Convert.ToDateTime(string.Format("{0:d/M/yyyy}", datavenda));

            var produto = _aplicacaoDbContext.Produtos_Pedidos.Include(p => p.Produto).Where(pp => pp.NumeroPedido == numpedido && pp.DataVenda == data && pp.ProdutoId == pp.Produto.ProdutoId).ToList();

            uri = new Uri(url);

            string email = "itbl.financeiro@outlook.com.br";
            string token = "0E1DD9EDBAA8476197C1826DD230F70E";

            string dados = "email=" + email + "&";
            dados = dados + "token=" + token + "&";
            dados = dados + "encoding=UTF-8&";
            dados = dados + "currency=BRL&";

            for (int i = 0; i < produto.Count; i++)
            {
                dados = dados + "itemQuantity" + (i + 1) + "=" + produto[i].Produto.ItensProdutoPedidos.Last().QTDVendida + "&";

                dados = dados + "itemId" + (i + 1) + "=" + produto[i].Produto.ProdutoId + "&";

                dados = dados + "itemDescription" + (i + 1) + "=" + produto[i].Produto.DescricaoCurta + "&";

                dados = dados + "itemAmount" + (i + 1) + "=" + produto[i].Produto.ItensProdutoPedidos.Last().Valor.ToString().Replace(",", ".") + "&";

            }

            //dados = dados + "itemQuantity1=1&";
            //dados = dados + "itemId1=1&";
            //dados = dados + "itemDescription1=Racao&";
            //dados = dados + "itemAmount1=1.99&";
                       
            dados = dados + "redirectURL=https://localhost:44358/status/index";
           

            using (httpClient)
            {
                //serializando os dados
                XmlSerializer xmlSerializer = new XmlSerializer(dados.GetType());

                httpResponseMessage = new HttpResponseMessage();

                //montando conteudo HTTP
                var stringContent = new StringContent(dados, Encoding.GetEncoding("ISO-8859-1"), "application/x-www-form-urlencoded");
                //var stringContent = new StringContent(kvp.ToString(), Encoding.GetEncoding("ISO-8859-1"), "application/xml");

                //fazendo uma requisição e retornando uma mensagem de resposta (pelo metodo GetAsync)
                Task<HttpResponseMessage> responseMessage = httpClient.PostAsync(url, stringContent);

                //pegando o resultado da requisição
                httpResponseMessage = responseMessage.Result;

                //obtendo o conteudo da mensagem do corpo da requisição
                HttpContent httpContent = httpResponseMessage.Content;

                //fazendo a leitura do conteudo da mensagem (pelo metodo ReadAsStringAsync)
                Task<string> _response = httpContent.ReadAsStringAsync();

                //obtendo o resultado da leitura anterior
                _data = _response.Result;

                httpClient.Dispose();
            }

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(_data);

            var codigoTransaction = xmlDocument.GetElementsByTagName("code")[0];

            if (!codigoTransaction.Equals(""))
            {

            }

            Response.Redirect("https://sandbox.pagseguro.uol.com.br/v2/checkout/payment.html?code=" + codigoTransaction.InnerText);

        }
             
    }
}