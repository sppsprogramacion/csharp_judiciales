using CapaDatos;
using CommonCache;
using Conexion;
using DAO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAOImplement
{
    public class CausaDaoImplement : ICausaDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        //CREAR CAUSA
        public async Task<(DCausa, string error)> CrearCausa(string causa)
        {
            DCausa dataCausa = new DCausa();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(causa, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PostAsync(url_base + "/causas", content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    dataCausa = JsonConvert.DeserializeObject<DCausa>(contentRespuesta);

                    // Puedes procesar el token o el resultado adicional aquí.
                    // Establecer el usuario actual
                    return (dataCausa, null);
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
        //FIN CREAR CAUSA........................................................

        public Task<(DCausa, string error)> BuscarCausaXId(int idCausa)
        {
            throw new NotImplementedException();
        }

        //LISTA POR INGRESO
        public async Task<(List<DCausa>, string error)> ListaCausasXIngreso(int idIngreso)
        {
            //variable token
            string token = SessionManager.Token;
            List<DCausa> listaCausas = new List<DCausa>();

            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/causas/buscar-xingreso?id_ingreso=" + idIngreso);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    listaCausas = JsonConvert.DeserializeObject<List<DCausa>>(contentRespuesta);
                    return (listaCausas, null);
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
        //FIN LISTA POR INGRESO

        public Task<(bool, string error)> AnularCausa(int idCausa, string dataAnular)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, string error)> EditarCausa(int idCausa, string causa)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, string error)> EstablecerCondena(int idCausa, string dataCondena)
        {
            throw new NotImplementedException();
        }

        
    }
}
