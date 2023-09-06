using CatemarAPI.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CatemarAPI.Modelos.Response;
using Microsoft.AspNetCore.Http.HttpResults;
using RestSharp;
using CatemarAPI.Modelos.Dto;
using System.Collections.Generic;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System;

namespace CatemarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        [HttpGet("url", Name ="token")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetContacts(string url, string token)
        {
            Respuesta oRespuesta = new();
            try
            {
                //Ejemplo de HubSpot
                //var client = new RestClient("https://api.hubapi.com/crm/v3/objects/contacts?limit=10&archived=false");
                //var request = new RestRequest(Method.GET);
                //request.AddHeader("accept", "application/json");
                //request.AddHeader("authorization", "Bearer YOUR_ACCESS_TOKEN");
                //IRestResponse response = client.Execute(request);
               
                WebRequest oRequest = WebRequest.Create(url);
                oRequest.Headers.Add("Accept", "application/json");
                oRequest.Headers.Add("authorization", "Bearer " + token);//Generico
                //oRequest.Headers.Add("authorization", "Bearer pat-na1-84497662-da71-4b6d-8612-ffb160a4ef46");//LATICON
                
                WebResponse oResponse = oRequest.GetResponse();
                StreamReader sr = new StreamReader(oResponse.GetResponseStream());               

                ContactoDto contact = JsonConvert.DeserializeObject<ContactoDto>(sr.ReadToEnd().Trim());                
                oRespuesta.Exito = 1;
                oRespuesta.Mensaje = "Get: Ok(200)";
                oRespuesta.Data = contact;
                oRespuesta.CantRegistro = contact.results.Count;
            }
            catch (HttpRequestException ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
            
        }
       
        /*[HttpGet("urlOne")]
        public IActionResult GetContact(string url)
        {
            Respuesta oRespuesta = new();
            try
            {
                WebRequest oRequest = WebRequest.Create(url);
                oRequest.Headers.Add("Accept", "application/json");
                oRequest.Headers.Add("authorization", "Bearer pat-na1-84497662-da71-4b6d-8612-ffb160a4ef46");
                WebResponse oResponse = oRequest.GetResponse();
                StreamReader sr = new StreamReader(oResponse.GetResponseStream());
                ContactoDto contact = JsonConvert.DeserializeObject<ContactoDto>(sr.ReadToEnd().Trim());
                oRespuesta.Exito = 1;
                oRespuesta.Mensaje = "Get:(200)";
                oRespuesta.Data = contact;

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);

        }*/
       
    }
}
