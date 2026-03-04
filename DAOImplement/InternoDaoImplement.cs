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
using System.IO;

namespace DAOImplement
{
    public class InternoDaoImplement : IInternosDao
    {
        private string url_base = MiConexion.getConexion();
        HttpClient httpClient = new HttpClient();

        //CREAR
        public async Task<(DInterno, string error)> CrearInterno(string interno)
        {
            DInterno dataInterno = new DInterno();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(interno, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PostAsync(url_base + "/internos", content);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    dataInterno = JsonConvert.DeserializeObject<DInterno>(contentRespuesta);

                    // Puedes procesar el token o el resultado adicional aquí.
                    // Establecer el usuario actual
                    return (dataInterno, null);
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
                return (null, $"Error inesperado");
            }
            catch (Exception ex)
            {
                // Manejo de errores (log, mensaje al usuario, etc.)
                Console.WriteLine($"Error: {ex.Message}");
                return (null, $"Error inesperado: {ex.Message}");
            }
        }
        //FIN CREAR..........................................................
                

        //BUSCAR X ID
        public async Task<(DInterno, string error)> BuscarInternoXId(int idInterno)
        {
            DInterno dInterno = new DInterno();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/internos/" + idInterno);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    dInterno = JsonConvert.DeserializeObject<DInterno>(content);
                    return (dInterno, null);
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
        //BUSCAR X ID

        public Task<(List<DInterno>, string error)> ListaInternosTodos()
        {
            throw new NotImplementedException();
        }


        //BUSCAR X APELLIDO
        public async Task<(List<DInterno>, string error)> ListaInternosXApellido(string apellido)
        {
            List<DInterno> listaInternos = new List<DInterno>();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/internos/buscarlista-xapellido?apellido=" + apellido);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    listaInternos = JsonConvert.DeserializeObject<List<DInterno>>(content);
                    return (listaInternos, null);
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
        //FIN BUSCAR XAPELLIDO

        //BUSCAR X APELLIDO en TODAS LAS UNIDADES
        public async Task<(List<DInterno>, string error)> ListaInternosXApellidoGeneral(string apellido)
        {
            List<DInterno> listaInternos = new List<DInterno>();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/internos/buscarlista-xapellido-gral?apellido=" + apellido);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    listaInternos = JsonConvert.DeserializeObject<List<DInterno>>(content);
                    return (listaInternos, null);
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
        //fin BUSCAR X APELLIDO EN TODAS LAS UNIDADES......................................................................

        //BUSCAR X PRONTUARIO
        public async Task<(List<DInterno>, string error)> ListaInternosXProntuario(int prontuario)
        {
            List<DInterno> listaInternos = new List<DInterno>();
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage httpResponse = await this.httpClient.GetAsync(url_base + "/internos/buscarlista-xprontuario?prontuario=" + prontuario);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
                    listaInternos = JsonConvert.DeserializeObject<List<DInterno>>(content);
                    return (listaInternos, null);
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
        //FIN BUSCAR X PRONTUARIO.....................................................

        //EDITAR DATOS PERSONALES
        public async Task<(bool, string error)> EditarDatosPersonales(int id, string datosPErsonales)
        {
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(datosPErsonales, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/internos/update-datos-personales?id_interno=" + id, content);

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
                        return (false, "No se pudo editar");
                    }
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (false, $"Error al editar: {mensaje}");
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
        //FIN EDITAR DATOS PERSONALES.....................................................

        //EDITAR CARACTERISTICAS PERSONALES
        public async Task<(bool, string error)> EditarCaracteristicasPersonales(int id, string caracteristicasPersonales)
        {
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(caracteristicasPersonales, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/internos/update-caracteristicas-personales?id_interno=" + id, content);

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
                        return (false, "No se pudo editar");
                    }
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (false, $"Error al editar: {mensaje}");
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
        //FIN EDITAR CARACTERISTICAS PERSONALES.............................................

        //EDITAR DATOS FILIATORIOS
        public async Task<(bool, string error)> EditarDatosFiliatorios(int id, string datosFiliatorios)
        {
            string token = SessionManager.Token; // Aquí pones tu token real

            try
            {
                // Agregar el token en los headers
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Crear el contenido de la solicitud HTTP
                StringContent content = new StringContent(datosFiliatorios, Encoding.UTF8, "application/json");

                // Enviar la solicitud HTTP POST
                HttpResponseMessage httpResponse = await this.httpClient.PutAsync(url_base + "/internos/update-datos-filiatorios?id_interno=" + id, content);

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
                        return (false, "No se pudo editar");
                    }
                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                    return (false, $"Error al editar: {mensaje}");
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

        //FIN EDITAR DATOS FILIATORIOS.............................................................

        public async Task<(bool, string error)> subirImagen(int id, string rutaImagen, string tipo_foto)
        {
            string token = SessionManager.Token;

            if (!File.Exists(rutaImagen))
                return (false, "No se encontró un archivo de imagen seleccionado.");

            try
            {
                using (var form = new MultipartFormDataContent())
                using (var imageContent = new ByteArrayContent(File.ReadAllBytes(rutaImagen)))
                {
                    imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                    form.Add(imageContent, "file", Path.GetFileName(rutaImagen));

                    // Agregar token a la cabecera
                    this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    string url = $"{url_base}/internos/upload-img-interno?id_interno={id}&tipo_perfil={tipo_foto}";
                    var response = await this.httpClient.PostAsync(url, form);

                    if (response.IsSuccessStatusCode)
                    {
                        return (true, null);
                    }
                    else
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        var mensaje = JObject.Parse(responseContent)["message"]?.ToString();
                        return (false, $"Error al subir la imagen: {mensaje}");
                    }
                }
            }
            catch (HttpRequestException httpRequestException)
            {
                return (false, $"Error en la solicitud: {httpRequestException.Message}");
            }
            catch (Exception ex)
            {
                return (false, $"Error inesperado: {ex.Message}");
            }
        }

        public Task<(bool, string error)> quitarImagen(int id)
        {
            throw new NotImplementedException();
        }

    }
}
