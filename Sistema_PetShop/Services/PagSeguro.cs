using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sistema_PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace Sistema_PetShop.Services
{
    public class PagSeguro : ControllerBase
    {
        string url = @"https://ws.sandbox.pagseguro.uol.com.br/v2/checkout?username=itbl.financeiro@outlook.com.br&password=p@gU72&guR0_2081";

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage httpResponseMessage;

        Uri uri;

        string _data = "";
        public static string Checkout(List<Produto> itens, Cliente comprador)
        {
            string urlCheckout = @"https://ws.sandbox.pagseguro.uol.com.br/v2/checkout?email=itbl.financeiro@outlook.com.br&token=0E1DD9EDBAA8476197C1826DD230F70E&username=itbl.financeiro@outlook.com.br&password=p@gU72&guR0_2081";

            //Conjunto de parâmetros/formData.
            System.Collections.Specialized.NameValueCollection postData = new System.Collections.Specialized.NameValueCollection();

            //postData.Add("email", "itbl.financeiro@outlook.com.br");
            //postData.Add("token", "0E1DD9EDBAA8476197C1826DD230F70E");
            postData.Add("currency", "BRL");

            for (int i = 0; i < itens.Count; i++)
            {
                postData.Add(string.Concat("itemQuantity", i + 1), itens[i].ItensProdutoPedidos[i].QTDVendida.ToString());
                postData.Add(string.Concat("itemId", i + 1), itens[i].ProdutoId.ToString());
                postData.Add(string.Concat("itemDescription", i + 1), itens[i].DescricaoCurta);
                postData.Add(string.Concat("itemAmount", i + 1), itens[i].ItensProdutoPedidos[i].Valor.ToString());

            }

            //Reference.
            postData.Add("reference", "REF1234");

            //Comprador.
            if (comprador != null)
            {
                postData.Add("senderName", comprador.Nome);
                postData.Add("senderAreaCode", "55");
                postData.Add("senderPhone", comprador.TelMovel1);
                postData.Add("senderEmail", comprador.Email);
            }

            //Shipping.
            postData.Add("shippingAddressRequired", "false");

            //Formas de pagamento.
            //Cartão de crédito e boleto.
            //postData.Add("acceptPaymentMethodGroup", "CREDIT_CARD,BOLETO");

            //String que receberá o XML de retorno.
            string xmlString = null;

            //Webclient faz o post para o servidor de pagseguro.
            using (WebClient wc = new WebClient())
            {
                //Informa header sobre URL.
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                //Faz o POST e retorna o XML contendo resposta do servidor do pagseguro.
                var result = wc.UploadValues(urlCheckout, postData);

                //Obtém string do XML.
                xmlString = Encoding.ASCII.GetString(result);
            }

            //Cria documento XML.
            XmlDocument xmlDoc = new XmlDocument();

            //Carrega documento XML por string.
            xmlDoc.LoadXml(xmlString);

            //Obtém código de transação (Checkout).
            var code = xmlDoc.GetElementsByTagName("code")[0];

            //Obtém data de transação (Checkout).
            var date = xmlDoc.GetElementsByTagName("date")[0];

            //Retorna código do checkout.
            return code.InnerText;
        }

        public static string GeraPagamento(List<Produto> produtos, Cliente cliente)
        {

            HttpResponseMessage httpResponseMessage;

            string link = "";

            int idPS = 0;

            try
            {
                //URI de checkout.


                string uri = @"https://ws.sandbox.pagseguro.uol.com.br/v2/checkout?";

                #region
                ////Conjunto de parâmetros/formData.
                //System.Collections.Specialized.NameValueCollection postData = new System.Collections.Specialized.NameValueCollection();

                //postData.Add("email", "itbl.financeiro@outlook.com.br");
                //postData.Add("token", "0E1DD9EDBAA8476197C1826DD230F70E");
                //postData.Add("username", "itbl.financeiro@outlook.com.br");
                //postData.Add("password", "p@gU72&guR0_2081");
                //postData.Add("currency", "BRL");


                //for (int i = 0; i < produtos.Count(); i++)
                //{
                //    postData.Add("itemQuantity1", "1");
                //    postData.Add("itemId1", produtos[i].ProdutoId.ToString());
                //    postData.Add("itemDescription1", produtos[i].DescricaoCurta.ToString());
                //    postData.Add("itemAmount1", produtos[i].Preco.ToString());
                //}

                //postData.Add("reference", "REF1234");

                //if (cliente != null)
                //{
                //    postData.Add("senderName", cliente.Nome);
                //    postData.Add("senderAreaCode", "55");
                //    postData.Add("senderPhone", cliente.TelMovel1);
                //    postData.Add("senderEmail", cliente.Email);
                //}

                #endregion

                //VarPagSeguro varPagSeguro = new VarPagSeguro();

                var PsData = new Dictionary<string, string>();

                PsData.Add("email", "itbl.financeiro@outlook.com.br");
                PsData.Add("token", "0E1DD9EDBAA8476197C1826DD230F70E");
                PsData.Add("currency", "BRL");

                //string dados = "username=itbl.financeiro@outlook.com.br&password=p@gU72&guR0_2081&currency=BRL&itemId1=0001&itemDescription1=Produto&itemAmount1=29.99&itemQuantity1=1";

                //varPagSeguro.email = "itbl.financeiro@outlook.com.br";
                //varPagSeguro.token = "0E1DD9EDBAA8476197C1826DD230F70E";
                ////varPagSeguro.username = "itbl.financeiro@outlook.com.br";
                ////varPagSeguro.password = "p@gU72&guR0_2081";
                //varPagSeguro.currency = "BRL";

                //List<VarPagSeguroProdutos> VarPagSeguroProdutos = new List<VarPagSeguroProdutos>();

                for (int i = 0; i < produtos.Count; i++)
                {
                    //postData.Add(string.Concat("itemQuantity", i + 1), itens[i].ItensProdutoPedidos[i].QTDVendida.ToString());

                    PsData.Add(string.Concat("itemQuantity", i + 1), produtos[i].ItensProdutoPedidos.Last().QTDVendida.ToString());
                    PsData.Add(string.Concat("itemId", i + 1), produtos[i].ProdutoId.ToString());
                    PsData.Add(string.Concat("itemDescription", i + 1), produtos[i].DescricaoCurta);
                    PsData.Add(string.Concat("itemAmount", i + 1), produtos[i].ItensProdutoPedidos.Last().Valor.ToString());

                    //varPagSeguro.itemQuantity1.Add(produtos[i].ItensProdutoPedidos.Last().QTDVendida.ToString());

                    //varPagSeguro.itemId1.Add(produtos[i].ProdutoId.ToString());

                    //varPagSeguro.itemDescription1.Add(produtos[i].DescricaoCurta);

                    //varPagSeguro.itemAmount1.Add(produtos[i].ItensProdutoPedidos.Last().Valor.ToString());

                }

                //varPagSeguro.itemQuantity1 = produtos;
                //varPagSeguro.itemId1 = "1";
                //varPagSeguro.itemDescription1 = "teste";
                //varPagSeguro.itemAmount1 = "itemAmount1=29.00&";
                //varPagSeguro.type = "0";


                if (cliente != null)
                {
                    //varPagSeguro.senderName = cliente.Nome;
                    //varPagSeguro.senderAreaCode = "55";
                    //varPagSeguro.senderPhone = cliente.TelMovel1;
                    //varPagSeguro.senderEmail = cliente.Email;
                }

                if (cliente != null)
                {
                    PsData.Add("senderName", cliente.Nome);
                    PsData.Add("senderAreaCode", "55");
                    PsData.Add("senderPhone", cliente.TelMovel1);
                    PsData.Add("senderEmail", cliente.Email);
                }

                PsData.Add("reference", "REF1234");
                PsData.Add("shippingAddressStreet", "Rua E.");
                PsData.Add("shippingAddressNumber", "1000");
                PsData.Add("shippingAddressComplement", "Apt");
                PsData.Add("shippingAddressDistrict", "Azul");
                PsData.Add("shippingAddressPostalCode", "26500000");
                PsData.Add("shippingAddressCity", "Maxima");
                PsData.Add("shippingAddressState", "RJ");
                PsData.Add("shippingAddressCountry", "BRA");


                //varPagSeguro.reference = "REF1234";
                ////varPagSeguro.shippingType = "1";
                //varPagSeguro.shippingAddressStreet = "Rua E.";
                //varPagSeguro.shippingAddressNumber = "1000";
                //varPagSeguro.shippingAddressComplement = "Apt";
                //varPagSeguro.shippingAddressDistrict = "Azul";
                //varPagSeguro.shippingAddressPostalCode = "26500000";
                //varPagSeguro.shippingAddressCity = "Maxima";
                //varPagSeguro.shippingAddressState = "RJ";
                //varPagSeguro.shippingAddressCountry = "BRA";

                //currency = "BRL",
                //itemId1 = "000",
                //itemDescription1 = "Produto",
                //itemAmount1 = valor.Replace(",", "."),
                //itemQuantity1 = "1",
                //reference = "REF1234",
                //senderName = nome,
                //senderAreaCode = "55",
                //senderPhone = telefone,
                //senderEmail = "c59578576240073283800@sandbox.pagseguro.com.br",
                ////shippingAddressRequired = false,
                //shippingType = "1",
                //shippingAddressStreet = "Rua E.",
                //shippingAddressNumber = "1000",
                //shippingAddressComplement = "Apt",
                //shippingAddressDistrict = "Azul",
                //shippingAddressPostalCode = "26500000",
                //shippingAddressCity = "Maxima",
                //shippingAddressState = cliente.Uf,
                //shippingAddressCountry = "BRA",
                //type = "1",
                //Response.AppendHeader()

                var authData = string.Format("{0}:{1}", "itbl.financeiro@outlook.com.br", "p@gU72&guR0_2081");

                var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

                //String que receberá o XML de retorno.
                string xmlString = null;

                HttpClientHandler clientHandler = new HttpClientHandler();

                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using (HttpClient httpClient = new HttpClient(clientHandler))
                {

                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

                    httpResponseMessage = new HttpResponseMessage();

                    //XmlSerializer xmlSerializer = new XmlSerializer(varPagSeguro.GetType());

                    //var stringContent = new StringContent(xmlSerializer.ToString(), Encoding.GetEncoding("ISO-8859-1"), "application/x-www-form-urlencoded");

                   // Task<HttpResponseMessage> httpReponseMessage = httpClient.PostAsync(uri, stringContent);

                    //httpResponseMessage = httpReponseMessage.Result;

                    HttpContent httpContent = httpResponseMessage.Content;

                    Task<string> _response = httpContent.ReadAsStringAsync();

                    //xmlString = Encoding.ASCII.GetString(_result);
                    var varpagseguro = JsonConvert.DeserializeObject<List<VarPagSeguro>>(_response.Result);

                    //_response.Result

                    //idPS = Convert.ToInt32(varpagseguro[0]);

                }



                //Cria documento XML.
                XmlDocument xmlDoc = new XmlDocument();

                //Carrega documento XML por string.
                //xmlDoc.LoadXml(_result);

                //Obtém código de transação (Checkout).
                var code = xmlDoc.GetElementsByTagName("id")[0];

                //Monta a URL para pagamento.                
                if (!code.InnerText.Equals(""))
                {
                    //dados.CodigoAcesso = code.InnerText;

                    link = string.Concat("https://sandbox.pagseguro.uol.com.br/v2/checkout/payment.html?code=90ef16fba14c479e8fb0165bc5d7572e", code.InnerText);
                }

            }
            catch (Exception e)
            {
                link = "";
                //dados.CodigoAcesso = "";
                return e.Message;
            }

            return link;
        }

        public void PaymentPagSeguro()
        {      
                
            //Inicializando a Uri
            uri = new Uri(url);

            string email = "itbl.financeiro@outlook.com.br";
            string token = "0E1DD9EDBAA8476197C1826DD230F70E";

            string dados = "email=" + email + "&";
            dados = dados + "token=" + token + "&";
            dados = dados + "currency=BRL&";
            dados = dados + "itemQuantity1=1&";
            dados = dados + "itemId1=1&";
            dados = dados + "itemDescription1=Xbox&";
            dados = dados + "itemAmount1=1999.99";        


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
