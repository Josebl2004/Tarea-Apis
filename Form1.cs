using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Tarea_Apis
{
    public partial class Form1 : Form
    {
        private const string OpenWeatherMapApiKey = "e67cfd24461982e4bbc857a848ce7105";
        private const string UnsplashApiKey = "mkccYXaWHMmFM5CqgHlPDIY8Stm7GZyDekE5Ldoij7I";
        private static readonly HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            ConfigurarDataGridViewPais();
        }

        private void ConfigurarDataGridView()
        {
            dataGridViewCiudades.Columns.Add("Ciudad", "Ciudad");
            dataGridViewCiudades.Columns.Add("Temperatura", "Temperatura");
            dataGridViewCiudades.Columns.Add("Clima", "Clima");
            dataGridViewCiudades.Columns.Add("Pais", "País");
            dataGridViewCiudades.Columns.Add("Latitud", "Latitud");
            dataGridViewCiudades.Columns.Add("Longitud", "Longitud");

            dataGridViewCiudades.AllowUserToAddRows = false;
            dataGridViewCiudades.ReadOnly = true;
        }

        private void ConfigurarDataGridViewPais()
        {
            dataGridViewPais.Columns.Add("Nombre", "Nombre del País");
            dataGridViewPais.Columns.Add("CodigoISO", "Código ISO");
            dataGridViewPais.Columns.Add("Capital", "Capital");
            dataGridViewPais.Columns.Add("Region", "Región");
            dataGridViewPais.Columns.Add("Subregion", "Subregión");
            dataGridViewPais.Columns.Add("Poblacion", "Población");

            dataGridViewPais.AllowUserToAddRows = false;
            dataGridViewPais.ReadOnly = true;
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string ciudad = txtCiudad.Text;

            if (string.IsNullOrWhiteSpace(ciudad))
            {
                if (dataGridViewCiudades.SelectedRows.Count > 0)
                {
                    ciudad = dataGridViewCiudades.SelectedRows[0].Cells["Ciudad"].Value?.ToString();
                }
            }

            if (string.IsNullOrWhiteSpace(ciudad))
            {
                MessageBox.Show("Por favor, ingresa una ciudad en el TextBox o selecciona una en el DataGridView.");
                return;
            }

            btnBuscar.Enabled = false;

            try
            {
                var clima = await ObtenerClimaAsync(ciudad);
                if (clima == null || clima.Main == null || clima.Weather == null || clima.Weather.Count == 0 || clima.Sys == null || clima.Coord == null)
                {
                    return;
                }

                AgregarDatosAlDataGridView(ciudad, clima);

                var imagenUrl = await ObtenerImagenAsync(ciudad);
                if (string.IsNullOrEmpty(imagenUrl))
                {
                    return;
                }

                pictureBoxCiudad.Load(imagenUrl);
            }
            catch (HttpRequestException ex)
            {
            }
            catch (JsonException ex)
            {
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dataGridViewCiudades.Rows.Clear();
            pictureBoxCiudad.Image = null;
        }

        private async void btnInfoPais_Click(object sender, EventArgs e)
        {
            string pais = txtCiudad.Text;

            if (string.IsNullOrWhiteSpace(pais))
            {
                MessageBox.Show("Ingresa el nombre de un país para obtener su información.");
                return;
            }

            try
            {
                var informacionPais = await ObtenerCodigoPaisAsync(pais);
                if (string.IsNullOrEmpty(informacionPais))
                {
                    return;
                }

                dataGridViewPais.Rows.Clear();

                var datos = informacionPais.Split(',');
                int rowIndex = dataGridViewPais.Rows.Add();
                var row = dataGridViewPais.Rows[rowIndex];

                foreach (var dato in datos)
                {
                    var keyValue = dato.Split(':');
                    if (keyValue.Length == 2)
                    {
                        string key = keyValue[0].Trim();
                        string value = keyValue[1].Trim();

                        switch (key)
                        {
                            case "Nombre":
                                row.Cells["Nombre"].Value = value;
                                break;
                            case "Código ISO":
                                row.Cells["CodigoISO"].Value = value;
                                break;
                            case "Capital":
                                row.Cells["Capital"].Value = value;
                                break;
                            case "Región":
                                row.Cells["Region"].Value = value;
                                break;
                            case "Subregión":
                                row.Cells["Subregion"].Value = value;
                                break;
                            case "Población":
                                row.Cells["Poblacion"].Value = value;
                                break;
                        }
                    }
                }
            }
            catch (HttpRequestException ex)
            {
            }
            catch (JsonException ex)
            {
            }
            catch (Exception ex)
            {
            }
        }

        private void AgregarDatosAlDataGridView(string ciudad, WeatherResponse clima)
        {
            int rowIndex = dataGridViewCiudades.Rows.Add();
            var row = dataGridViewCiudades.Rows[rowIndex];

            row.Cells["Ciudad"].Value = ciudad;
            row.Cells["Temperatura"].Value = clima.Main.Temp + "°C";
            row.Cells["Clima"].Value = clima.Weather[0].Description;
            row.Cells["Pais"].Value = clima.Sys.Country;
            row.Cells["Latitud"].Value = clima.Coord.Lat;
            row.Cells["Longitud"].Value = clima.Coord.Lon;
        }

        public class WeatherResponse
        {
            public Main Main { get; set; }
            public List<Weather> Weather { get; set; }
            public Sys Sys { get; set; }
            public Coord Coord { get; set; }
        }

        public class Main
        {
            public double Temp { get; set; }
        }

        public class Weather
        {
            public string Description { get; set; }
        }

        public class Sys
        {
            public string Country { get; set; }
        }

        public class Coord
        {
            public double Lat { get; set; }
            public double Lon { get; set; }
        }

        private async Task<WeatherResponse> ObtenerClimaAsync(string ciudad)
        {
            try
            {
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={ciudad}&appid={OpenWeatherMapApiKey}&units=metric&lang=es";
                var respuesta = await client.GetAsync(url);

                if (!respuesta.IsSuccessStatusCode)
                {
                    return null;
                }

                var contenido = await respuesta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeatherResponse>(contenido);
            }
            catch
            {
                return null;
            }
        }

        private async Task<string> ObtenerImagenAsync(string ciudad)
        {
            try
            {
                string url = $"https://api.unsplash.com/search/photos?query={ciudad}&client_id={UnsplashApiKey}";
                var respuesta = await client.GetAsync(url);

                if (!respuesta.IsSuccessStatusCode)
                {
                    return null;
                }

                var contenido = await respuesta.Content.ReadAsStringAsync();
                dynamic datos = JsonConvert.DeserializeObject(contenido);

                if (datos.results.Count == 0)
                {
                    return null;
                }

                return datos.results[0].urls.small;
            }
            catch
            {
                return null;
            }
        }

        private string ConvertirPaisACodigoISO(string pais)
        {
            var paises = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "España", "Spain" },
                { "México", "Mexico" },
                { "Argentina", "Argentina" },
                { "Colombia", "Colombia" },
                { "Perú", "Peru" },
                { "Chile", "Chile" },
                { "Brasil", "Brazil" },
                { "Estados Unidos", "United States" },
                { "Canadá", "Canada" },
                { "Francia", "France" },
                { "Alemania", "Germany" },
                { "Italia", "Italy" },
                { "Japón", "Japan" },
                { "China", "China" },
                { "India", "India" }
            };

            if (paises.ContainsKey(pais))
            {
                return paises[pais];
            }

            return pais;
        }

        private async Task<string> ObtenerCodigoPaisAsync(string pais)
        {
            try
            {
                string url = $"https://restcountries.com/v3.1/name/{pais}";
                var respuesta = await client.GetAsync(url);

                if (!respuesta.IsSuccessStatusCode)
                {
                    return null;
                }

                var contenido = await respuesta.Content.ReadAsStringAsync();
                dynamic datos = JsonConvert.DeserializeObject(contenido);

                var nombre = datos[0].name.common;
                var codigoISO = datos[0].cca2;
                var capital = datos[0].capital[0];
                var region = datos[0].region;
                var subregion = datos[0].subregion;
                var poblacion = datos[0].population;

                return $"Nombre: {nombre}, Código ISO: {codigoISO}, Capital: {capital}, Región: {region}, Subregión: {subregion}, Población: {poblacion}";
            }
            catch
            {
                return null;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
