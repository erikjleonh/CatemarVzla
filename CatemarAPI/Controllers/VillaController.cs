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
    public class VillaController : ControllerBase
    {
        [HttpGet("url")]
        public IActionResult GetContacts(string url)
        {
            Respuesta oRespuesta = new();
            try
            {
                WebRequest oRequest = WebRequest.Create(url);
                WebResponse oResponse = oRequest.GetResponse();
                StreamReader sr = new StreamReader(oResponse.GetResponseStream());
                List<PlaceholderDto> contact = JsonConvert.DeserializeObject<List<PlaceholderDto>>(sr.ReadToEnd().Trim());                
                oRespuesta.Exito = 1;
                oRespuesta.Mensaje = "Get:(200)";
                oRespuesta.Data = contact;
            }
            catch (HttpRequestException ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
            
        }
       
        [HttpGet("urlOne")]
        public IActionResult GetContact(string url)
        {
            Respuesta oRespuesta = new();
            try
            {
                WebRequest oRequest = WebRequest.Create(url);
                WebResponse oResponse = oRequest.GetResponse();
                StreamReader sr = new StreamReader(oResponse.GetResponseStream());
                PlaceholderDto contact = JsonConvert.DeserializeObject<PlaceholderDto>(sr.ReadToEnd().Trim());
                oRespuesta.Exito = 1;
                oRespuesta.Mensaje = "Get:(200)";
                oRespuesta.Data = contact;

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);

        }
       
    }
}
