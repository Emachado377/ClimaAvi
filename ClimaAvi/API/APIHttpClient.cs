using ClimaAvi.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace ClimaAvi
{

    public class APIHttpClient
    {
        private string baseAPI = "https://localhost:44313/api/";
        public APIHttpClient(string baseAPI)
        {
            this.baseAPI = baseAPI;
        }

        public Guid Put<T>(string action, Guid id, T data)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAPI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                SetarParametrosAutenticacao(client);

                HttpResponseMessage response = client.PutAsJsonAsync(action + id.ToString(), data).Result;
                if (response.IsSuccessStatusCode)
                {
                    var sucesso = response.Content.ReadAsAsync<Guid>().Result;
                    return sucesso;
                }
                else
                {
                    //Se o retorno for token expirado
                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest || response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        var retorno = response.Content.ReadAsStringAsync().Result;
                        if (retorno.ToLower().IndexOf("negada ") > 0 || retorno.ToLower().IndexOf("expired") > 0)
                        {
                            //Autentica novamente
                            var usuario = (User)HttpContext.Current.Session["user"];
                            AuthenticationPost(usuario.Name, usuario.Password);
                            //Repete a solicitacao
                            return Put<T>(action, id, data);
                        }
                        else
                        {
                            throw new Exception(response.Content.ReadAsStringAsync().Result);
                        }
                    }
                    else
                    {
                        throw new Exception(response.Content.ReadAsStringAsync().Result);
                    }
                }
            }
        }

        public Guid Post<T>(string action, T data)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAPI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                SetarParametrosAutenticacao(client);

                HttpResponseMessage response = client.PostAsJsonAsync(action, data).Result;
                if (response.IsSuccessStatusCode)
                {
                    var sucesso = response.Content.ReadAsAsync<Guid>().Result;
                    return sucesso;
                }
                else
                {
                    //Se o retorno for token expirado
                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest || response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        var retorno = response.Content.ReadAsStringAsync().Result;
                        if (retorno.ToLower().IndexOf("negada ") > 0 || retorno.ToLower().IndexOf("expired") > 0)
                        {
                            //Autentica novamente
                            var usuario = (User)HttpContext.Current.Session["user"];
                            AuthenticationPost(usuario.Name, usuario.Password);
                            //Repete a solicitacao
                            return Post<T>(action, data);
                        }
                        else
                        {
                            throw new Exception(response.Content.ReadAsStringAsync().Result);
                        }
                    }
                    else
                    {
                        throw new Exception(response.Content.ReadAsStringAsync().Result);
                    }
                }
            }
        }

        public T Get<T>(string actionUri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAPI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                SetarParametrosAutenticacao(client);

                HttpResponseMessage response = client.GetAsync(actionUri).Result;
                if (response.IsSuccessStatusCode)
                {
                    T sucesso = response.Content.ReadAsAsync<T>().Result;
                    return sucesso;
                }
                else
                {
                    //Se o retorno for token expirado
                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest || response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        var retorno = response.Content.ReadAsStringAsync().Result;
                        if (retorno.ToLower().IndexOf("negada ") > 0 || retorno.ToLower().IndexOf("expired") > 0)
                        {
                            //Autentica novamente
                            var usuario = (User)HttpContext.Current.Session["user"];
                            AuthenticationPost(usuario.Name, usuario.Password);
                            //Repete a solicitacao
                            return Get<T>(actionUri);
                        }
                        else
                        {
                            throw new Exception(response.Content.ReadAsStringAsync().Result);
                        }
                    }
                    else
                    {
                        throw new Exception(response.Content.ReadAsStringAsync().Result);
                    }
                }
            }
        }

        //internal object Post<T>(string v, List<T> users)
        //{
        //    throw new NotImplementedException();
        //}

        public T Delete<T>(string action, Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAPI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                SetarParametrosAutenticacao(client);

                HttpResponseMessage response = client.DeleteAsync(action + id.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    var sucesso = response.Content.ReadAsAsync<T>().Result;
                    return sucesso;
                }
                else
                {
                    //Se o retorno for token expirado
                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest || response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        var retorno = response.Content.ReadAsStringAsync().Result;
                        if (retorno.ToLower().IndexOf("negada ") > 0 || retorno.ToLower().IndexOf("expired") > 0)
                        {
                            //Autentica novamente
                            var usuario = (User)HttpContext.Current.Session["user"];
                            AuthenticationPost(usuario.Name, usuario.Password);
                            //Repete a solicitacao
                            return Delete<T>(action, id);
                        }
                        else
                        {
                            throw new Exception(response.Content.ReadAsStringAsync().Result);
                        }
                    }
                    else
                    {
                        throw new Exception(response.Content.ReadAsStringAsync().Result);
                    }
                }
            }
        }


        public string AuthenticationPost(string username, string password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAPI);
                client.DefaultRequestHeaders.Accept.Clear();
                var request = new HttpRequestMessage(HttpMethod.Post, (this.baseAPI + "token"));
                request.Content = new FormUrlEncodedContent(new Dictionary<string, string> {
                        { "name", username},
                        { "password", password },
                        { "grant_type", "password" }
                    });

                var response = client.SendAsync(request).Result;


                if (response.IsSuccessStatusCode)
                {
                    var payload = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                    var token = payload.Value<string>("access_token");

                    //Salva o usuario, senha e token em memoria
                    User usuario = new User()
                    {
                        Password = password,
                        Name = username,
                        Token = token
                    };
                    HttpContext.Current.Session["user"] = usuario;

                    return token;
                }
                else
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }
            }
        }

        private void SetarParametrosAutenticacao(HttpClient httpClient)
        {
            if (HttpContext.Current.Session["user"] != null)
            {
                var usuario = (User)HttpContext.Current.Session["user"];

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", usuario.Token);
            }
        }
    }
}