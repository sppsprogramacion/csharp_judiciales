using CapaDatos;
using CommonCache;
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
using Conexion;

namespace DAOImplement
{
    public class ZonaResidenciaDaoImplement : IZonaResidencia
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        public DZonaResidencia buscarXId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<(List<DZonaResidencia>, string error)> listaZonaResidenciaTodos()
        {

            //variable token
            string token = SessionManager.Token;
            List<DZonaResidencia> listaZonaResidencia = new List<DZonaResidencia>();

            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/zona-residencia/todos");

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    listaZonaResidencia = JsonConvert.DeserializeObject<List<DZonaResidencia>>(contentRespuesta);
                    return (listaZonaResidencia, null);

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
    }
}
