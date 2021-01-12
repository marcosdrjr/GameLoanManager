using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Nancy.Json;

namespace GameLoanManagerCore.Models
{
    public class RetornoResponses
    {
        public static HttpResponseMessage retornoResponseOk(string mensagem,object data,string observacao="", string codigo = "0000",string aplicacao= "GameLoanManagerCoreAPI")
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Retornos ret = new Retornos();
            HttpRequestMessage Request = new HttpRequestMessage();
            HttpResponseMessage resp = new HttpResponseMessage();
            try
            {
                ret.codigo = codigo;
                ret.titulo = "Web.API.GameLoanManager";
                ret.mensagem = mensagem;
                ret.solucao = "Web.API.GameLoanManager.V0001.0001";
                ret.codAplicacao = aplicacao;
                ret.observacao = observacao;
                ret.data = data;
                resp.StatusCode = HttpStatusCode.OK;
                HttpResponseMessage response = resp;
                string retorno = jss.Serialize(ret);
                response.Content = new StringContent(retorno, Encoding.UTF8, "application/json");
                return response;
            }
            catch (Exception ex)
            {
                ret.codigo = "9099";
                ret.titulo = "Web.API.GameLoanManager";
                ret.mensagem = mensagem;
                ret.solucao = "Web.API.GameLoanManager.V0001.0001";
                ret.codAplicacao = aplicacao;
                ret.observacao = ex.Message.ToString();
                resp.StatusCode = HttpStatusCode.InternalServerError;
                HttpResponseMessage response = resp;
                string retorno = jss.Serialize(ret);
                response.Content = new StringContent(retorno, Encoding.UTF8, "application/json");
                return response;
            }
        }
        public static HttpResponseMessage retornoResponseBadRequest(string mensagem, object data, string observacao = "", string codigo = "0000", string aplicacao = "GameLoanManagerCoreAPI")
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Retornos ret = new Retornos();
            HttpRequestMessage Request = new HttpRequestMessage();
            HttpResponseMessage resp = new HttpResponseMessage();
            try
            {
                ret.codigo = "9098";
                 ret.titulo = "Web.API.GameLoanManager";
                ret.mensagem = mensagem;
                ret.solucao = "Web.API.GameLoanManager.V0001.0001";
                ret.codAplicacao = aplicacao;
                ret.observacao = observacao;
                ret.data = data;
                resp.StatusCode = HttpStatusCode.BadRequest;
                HttpResponseMessage response = resp;
                string retorno = jss.Serialize(ret);
                response.Content = new StringContent(retorno, Encoding.UTF8, "application/json");
                return response;
            }
            catch (Exception ex)
            {
                ret.codigo = "9099";
                ret.titulo = "Web.API.GameLoanManager";
                ret.mensagem = mensagem;
                ret.solucao = "Web.API.GameLoanManager.V0001.0001";
                ret.codAplicacao = aplicacao;
                ret.observacao = ex.Message.ToString();
                resp.StatusCode = HttpStatusCode.InternalServerError;
                HttpResponseMessage response = resp;
                string retorno = jss.Serialize(ret);
                response.Content = new StringContent(retorno, Encoding.UTF8, "application/json");
                return response;
            }
        }
        public static Object retornoResponseGone(string mensagem, object data, string observacao = "", string codigo = "0000", string aplicacao = "GameLoanManagerCoreAPI")
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Retornos ret = new Retornos();
            HttpRequestMessage Request = new HttpRequestMessage();
            HttpResponseMessage resp = new HttpResponseMessage();
            try
            {
                ret.titulo = "Web.API.GameLoanManager";
                ret.mensagem = mensagem;
                ret.solucao = "Web.API.GameLoanManager.V0001.0001";
                ret.codAplicacao = aplicacao;
                ret.observacao = observacao;
                ret.data = data;
                resp.StatusCode = HttpStatusCode.OK;
                //HttpResponseMessage response = resp;
                string retorno = jss.Serialize(ret);
                //response.Content = new StringContent(retorno, Encoding.UTF8, "application/json");
                return retorno;
            }
            catch (Exception ex)
            {
                ret.codigo = "9099";
                ret.titulo = "Web.API.GameLoanManager";
                ret.mensagem = mensagem;
                ret.solucao = "Web.API.GameLoanManager.V0001.0001";
                ret.codAplicacao = aplicacao;
                ret.observacao = ex.Message.ToString();
                resp.StatusCode = HttpStatusCode.InternalServerError;
                HttpResponseMessage response = resp;
                string retorno = jss.Serialize(ret);
                response.Content = new StringContent(retorno, Encoding.UTF8, "application/json");
                return response;
            }
        }
        public static HttpResponseMessage retornoResponseBadGateway(string mensagem, object data, string observacao = "", string codigo = "0000", string aplicacao = "GameLoanManagerCoreAPI")
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Retornos ret = new Retornos();
            HttpRequestMessage Request = new HttpRequestMessage();
            HttpResponseMessage resp = new HttpResponseMessage();

            try
            {
                ret.titulo = "Web.API.GameLoanManager";
                ret.mensagem = mensagem;
                ret.solucao = "Web.API.GameLoanManager.V0001.0001";
                ret.codAplicacao = aplicacao;
                ret.observacao = observacao;
                ret.data = data;
                resp.StatusCode = HttpStatusCode.BadGateway;
                HttpResponseMessage response = resp;
                string retorno = jss.Serialize(ret);
                response.Content = new StringContent(retorno, Encoding.UTF8, "application/json");
                return response;
            }
            catch (Exception ex)
            {
                ret.codigo = "9099";
                ret.titulo = "Web.API.GameLoanManager";
                ret.mensagem = mensagem;
                ret.solucao = "Web.API.GameLoanManager.V0001.0001";
                ret.codAplicacao = aplicacao;
                ret.observacao = ex.Message.ToString();
                resp.StatusCode = HttpStatusCode.InternalServerError;
                HttpResponseMessage response = resp;
                string retorno = jss.Serialize(ret);
                response.Content = new StringContent(retorno, Encoding.UTF8, "application/json");
                return response;
            }
        }
        public static HttpResponseMessage retornoResponseUnauthorized(string mensagem, object data, string observacao = "", string codigo = "0000", string aplicacao = "GameLoanManagerCoreAPI")
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Retornos ret = new Retornos();
            HttpRequestMessage Request = new HttpRequestMessage();
            HttpResponseMessage resp = new HttpResponseMessage();

            try
            {
                ret.titulo = "Web.API.GameLoanManager";
                ret.mensagem = mensagem;
                ret.solucao = "Web.API.GameLoanManager.V0001.0001";
                ret.codAplicacao = aplicacao;
                ret.observacao = observacao;
                ret.data = data;
                resp.StatusCode = HttpStatusCode.Unauthorized;
                HttpResponseMessage response = resp;
                string retorno = jss.Serialize(ret);
                response.Content = new StringContent(retorno, Encoding.UTF8, "application/json");
                return response;
            }
            catch (Exception ex)
            {
                ret.codigo = "9099";
                ret.titulo = "Web.API.GameLoanManager";
                ret.mensagem = mensagem;
                ret.solucao = "Web.API.GameLoanManager.V0001.0001";
                ret.codAplicacao = aplicacao;
                ret.observacao = ex.Message.ToString();
                resp.StatusCode = HttpStatusCode.InternalServerError;
                HttpResponseMessage response = resp;
                string retorno = jss.Serialize(ret);
                response.Content = new StringContent(retorno, Encoding.UTF8, "application/json");
                return response;
            }
        }
    }
}
