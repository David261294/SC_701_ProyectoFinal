using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FE.Servicios
{
    public class RecepcionistaServices
    {
        public List<Models.Recepcionista> GetAll()
        {
            List<Models.Recepcionista> aux = new List<Models.Recepcionista>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/Recepcionista").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.Recepcionista>>(auxres);
                }
            }
            return aux;
        }

        public async Task<List<Models.Recepcionista>> GetAllAsync()
        {
            List<Models.Recepcionista> aux = new List<Models.Recepcionista>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/Recepcionista");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.Recepcionista>>(auxres);
                }
            }
            return aux;
        }

        public Models.Recepcionista GetById(int? id)
        {
            Models.Recepcionista aux = new Models.Recepcionista();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage res = await cl.GetAsync("api/Pais/5?"+id);
                HttpResponseMessage res = cl.GetAsync("api/Recepcionista/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Models.Recepcionista>(auxres);
                }
            }
            return aux;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            try
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(Program.baseurl);
                    cl.DefaultRequestHeaders.Clear();
                    cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage res = await cl.DeleteAsync("api/Recepcionista/" + id);

                    if (res.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Updated(int id, Models.Recepcionista Recepcionista)
        {
            try
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(Program.baseurl);
                    var content = JsonConvert.SerializeObject(Recepcionista);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PutAsync("api/Recepcionista/" + id, byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Create(Models.Recepcionista Recepcionista)
        {
            try
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(Program.baseurl);
                    var content = JsonConvert.SerializeObject(Recepcionista);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/Recepcionista", byteContent).Result;

                    if (postTask.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
