using CapaDatos;
using CommonCache;
using Conexion;
using DAO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAOImplement
{
    public class DepartamentoDaolmpl : IDepartamentoDao
    {//inicio clase
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();
        public DDepartamento buscarDepartamentoXId(int id)
        {
            throw new NotImplementedException();
        }

        async public Task<(List<DDepartamento>, string error)> retornarListaDepartamentoXProvincia(string provincia_id)
        {
            //variable token
            string token = SessionManager.Token;
            List<DDepartamento> listaDepartamento = new List<DDepartamento>();
            try
            {
                //agregar tpken a la cabecera
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(provincia_id, Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponse = await httpClient.GetAsync(url_base + "/departamentos/buscar-xprovincia?id_provincia=" + provincia_id);
                    
                if (httpResponse.IsSuccessStatusCode)
                {
                    //var content = await httpResponse.Content.ReadAsStringAsync();
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    listaDepartamento = JsonConvert.DeserializeObject<List<DDepartamento>>(contentRespuesta);
                    return (listaDepartamento, null);

                        
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




    }//fin clase
}
