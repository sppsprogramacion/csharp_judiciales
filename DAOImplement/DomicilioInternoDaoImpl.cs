using CapaDatos;
using CommonCache;
using Conexion;
using DAO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAOImplement
{
    public class DomicilioInternoDaoImpl : IDomicilioInternoDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        //CREAR NUEVO
        public async Task<(DDomicilioInterno, string error)> CrearDomicilio(string domicilioInterno)
        {
            DDomicilioInterno dataDomiciclio = new DDomicilioInterno();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(domicilioInterno, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PostAsync(url_base + "/domicilios-interno", content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    dataDomiciclio = JsonConvert.DeserializeObject<DDomicilioInterno>(contentRespuesta);

                    // Puedes procesar el token o el resultado adicional aquí.
                    // Establecer el usuario actual
                    return (dataDomiciclio, null);
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (null, $"Error al crear: {mensaje}");
                }
            }
            catch (HttpRequestException httpRequestException)
            {
                // Capturar errores de la solicitud HTTP
                return (null, $"Error de conexión: {httpRequestException.Message}");
            }
            catch (JsonException jsonException)
            {
                // Capturar errores en la serialización/deserialización de JSON                
                return (null, $"Error inesperado al confirmar");
            }
            catch (Exception ex)
            {
                // Manejo de errores (log, mensaje al usuario, etc.)
                Console.WriteLine($"Error: {ex.Message}");
                return (null, $"Error inesperado: {ex.Message}");
            }
        }
        //FIN CREAR NUEVO...................................................

        //BUSCAR DOMICILIO  POR ID_DOMICILIO
        public async Task<(DDomicilioInterno, string error)> BuscarDomicilioXId(int idDomicilio)
        {
            DDomicilioInterno dDomicilio = new DDomicilioInterno();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/domicilios-interno/" + idDomicilio);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    dDomicilio = JsonConvert.DeserializeObject<DDomicilioInterno>(content);
                    return (dDomicilio, null);
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (null, $"Error en la busqueda: {mensaje}");
                }
            }
            catch (HttpRequestException httpRequestException)
            {
                // Capturar errores de la solicitud HTTP
                return (null, $"Error de conexión: {httpRequestException.Message}");
            }
            catch (JsonException jsonException)
            {
                // Capturar errores en la serialización/deserialización de JSON                
                return (null, $"Error inesperado");
            }
            catch (Exception ex)
            {
                // Manejo de errores (log, mensaje al usuario, etc.)
                Console.WriteLine($"Error: {ex.Message}");
                return (null, $"Error inesperado: {ex.Message}");
            }
        }
        //FIN BUSCAR DOMICILIO  POR ID_DOMICILIO..................................................

        //LISTA DE DOMICILIOS POR IDE_INTERNO
        public async Task<(List<DDomicilioInterno>, string error)> ListaDomiciliosXInterno(int idInterno)
        {
            //variable token
            string token = SessionManager.Token;
            List<DDomicilioInterno> listaDomicilios = new List<DDomicilioInterno>();

            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/domicilios-interno/buscar-xinterno?id_interno=" + idInterno);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    listaDomicilios = JsonConvert.DeserializeObject<List<DDomicilioInterno>>(contentRespuesta);
                    return (listaDomicilios, null);
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (null, $"Error en la busqueda: {mensaje}");
                }
            }
            catch (HttpRequestException httpRequestException)
            {
                // Capturar errores de la solicitud HTTP
                return (null, $"Error de conexión: {httpRequestException.Message}");
            }
            catch (JsonException jsonException)
            {
                // Capturar errores en la serialización/deserialización de JSON                
                return (null, $"Error inesperado");
            }
            catch (Exception ex)
            {
                // Manejo de errores (log, mensaje al usuario, etc.)
                Console.WriteLine($"Error: {ex.Message}");
                return (null, $"Error inesperado: {ex.Message}");
            }
        }
        //FIN LISTA DE DOMICILIOS POR IDE_INTERNO...............................

        //EDITAR
        public async Task<(bool, string error)> EditarDomicilio(int idDomicilio, string domicilioInterno)
        {
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(domicilioInterno, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/domicilios-interno/" + idDomicilio, content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    var dataRespuesta = JsonConvert.DeserializeObject<DResponseEditar>(contentRespuesta);

                    if (dataRespuesta.Affected > 0)
                    {
                        return (true, null);
                    }
                    else
                    {
                        return (false, "No se pudo modificar la el domicilio");
                    }
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (false, $"Error al modificar la causa: {mensaje}");
                }
            }
            catch (HttpRequestException httpRequestException)
            {
                // Capturar errores de la solicitud HTTP
                return (false, $"Error de conexión: {httpRequestException.Message}");
            }
            catch (JsonException jsonException)
            {
                // Capturar errores en la serialización/deserialización de JSON                
                return (false, $"Error inesperado");
            }
            catch (Exception ex)
            {
                // Manejo de errores (log, mensaje al usuario, etc.)
                Console.WriteLine($"Error: {ex.Message}");
                return (false, $"Error inesperado: {ex.Message}");
            }
        }
        //FIN EDITAR...............................................................


        public Task<(bool, string error)> AnularDomicilio(int idDomicilio, string dataAnular)
        {
            throw new NotImplementedException();
        }
    }
}
