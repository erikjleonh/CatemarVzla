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
                WebRequest oRequest = WebRequest.Create(url);
                oRequest.Headers.Add("Accept", "application/json");
                oRequest.Headers.Add("authorization", "Bearer " + token);//Generico               
                
                WebResponse oResponse = oRequest.GetResponse();
                StreamReader sr = new StreamReader(oResponse.GetResponseStream());               

                ContactoDto contact = JsonConvert.DeserializeObject<ContactoDto>(sr.ReadToEnd().Trim());                
                oRespuesta.Exito = 1;
                oRespuesta.Mensaje = "Get: O k(200)";
                oRespuesta.Data = contact;
                oRespuesta.CantRegistro = contact.results.Count;
            }
            catch (HttpRequestException ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
            
        }
              
    }
}
