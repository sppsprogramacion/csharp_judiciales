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
    public class HistorialProcesalDaoImplement : IHistorialProcesalDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        public async Task<(DHistorialProcesal, string error)> CrearHistorial(string historialProcesal)
        {
            DHistorialProcesal dataHistorialProcesal = new DHistorialProcesal();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(historialProcesal, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PostAsync(url_base + "/historial-procesal", content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    dataHistorialProcesal = JsonConvert.DeserializeObject<DHistorialProcesal>(contentRespuesta);

                    // Puedes procesar el token o el resultado adicional aquí.
                    // Establecer el usuario actual
                    return (dataHistorialProcesal, null);
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
              
        //BUSCAR X ID HISTORIAL
        public async Task<(DHistorialProcesal, string error)> BuscarHistorialXId(int idHistorial)
        {
            DHistorialProcesal dHistorialProcesal = new DHistorialProcesal();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/historial-procesal/" + idHistorial);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    dHistorialProcesal = JsonConvert.DeserializeObject<DHistorialProcesal>(content);
                    return (dHistorialProcesal, null);
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
        //FIN BUSCAR X ID HISTORIAL.................................................................

        //LISTA HISTORIAL PROCESAL POR ID INGRESO
        public async Task<(List<DHistorialProcesal>, string error)> ListaHistorialXIngreso(int idIgreso)
        {
            //variable token
            string token = SessionManager.Token;
            List<DHistorialProcesal> listaHistorialProcesal = new List<DHistorialProcesal>();

            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/historial-procesal/lista-xingreso?id_ingreso=" + idIgreso);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    listaHistorialProcesal = JsonConvert.DeserializeObject<List<DHistorialProcesal>>(contentRespuesta);
                    return (listaHistorialProcesal, null);
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
        //FIN LISTA HISTORIAL PROCESAL POR ID INGRESO.....................................................

        //LISTA HISTORIAL PROCESAL POR ID_INGRESO Y POR ID_TIPO_HISTORIAL
        public async Task<(List<DHistorialProcesal>, string error)> ListaHistorialXIngresoXTipoHistorial(int idIgreso, int idTipoHistorial)
        {
            //variable token
            string token = SessionManager.Token;
            List<DHistorialProcesal> listaHistorialProcesal = new List<DHistorialProcesal>();

            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/historial-procesal/lista-xingreso-xtipohistorial?id_ingreso=" + idIgreso + "&id_tipo_historial=" + idTipoHistorial);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    listaHistorialProcesal = JsonConvert.DeserializeObject<List<DHistorialProcesal>>(contentRespuesta);
                    return (listaHistorialProcesal, null);
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
        //FIN LISTA HISTORIAL PROCESAL POR ID_INGRESO Y POR ID_TIPO_HISTORIAL


        public Task<(bool, string error)> EditarHistorial(int idCausa, string causa)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, string error)> AnularHistorial(int idCausa, string dataAnular)
        {
            throw new NotImplementedException();
        }
    }
}
