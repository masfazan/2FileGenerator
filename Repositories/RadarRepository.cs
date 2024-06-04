using Microsoft.Data.SqlClient;
using Model;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace Repositories
{

    public class RadarRepository
    {
        string Connection = "Server=127.0.0.1; Database=DBRadar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=True";
        SqlConnection conn;

        public RadarRepository()
        {
            conn = new SqlConnection(Connection);
            conn.Open();
        }

        public bool Insert(Radar radar)
        {
            bool result = false;
            try
            {
                SqlCommand command = new SqlCommand(Radar.INSERT, conn);
                command.Parameters.AddWithValue("@concessionaria", radar.concessionaria);
                command.Parameters.AddWithValue("@ano_do_pnv_snv", radar.ano_PNV_SNV);
                command.Parameters.AddWithValue("@tipo_de_radar", radar.tipo_Radar);
                command.Parameters.AddWithValue("@rodovia", radar.rodovia);
                command.Parameters.AddWithValue("@uf", radar.uf);
                command.Parameters.AddWithValue("@km_m", radar.km_m);
                command.Parameters.AddWithValue("@municipio", radar.municipio);
                command.Parameters.AddWithValue("@tipo_pista", radar.tipo_Pista);
                command.Parameters.AddWithValue("@sentido", radar.sentido);
                command.Parameters.AddWithValue("@situacao", radar.situacao);
                string DataDaInativacaoString = radar.data_Inativacao != null ? string.Join(",", radar.data_Inativacao) : null;
                command.Parameters.AddWithValue("@data_da_inativacao", radar.data_Inativacao);
                command.Parameters.AddWithValue("@latitude", radar.latitude);
                command.Parameters.AddWithValue("@longitude", radar.longitude);
                command.Parameters.AddWithValue("@velocidade_leve", radar.velocidade_Leve);
                command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception)
            {
                return result;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
        public bool Update(Radar radar)
        {
            bool result = false;
            try
            {
                SqlCommand command = new SqlCommand(Radar.UPDATE, conn);
                command.Parameters.AddWithValue("@concessionaria", radar.concessionaria);
                command.Parameters.AddWithValue("@ano_do_pnv_snv", radar.ano_PNV_SNV);
                command.Parameters.AddWithValue("@tipo_de_radar", radar.tipo_Radar);
                command.Parameters.AddWithValue("@rodovia", radar.rodovia);
                command.Parameters.AddWithValue("@uf", radar.uf);
                command.Parameters.AddWithValue("@km_m", radar.km_m);
                command.Parameters.AddWithValue("@municipio", radar.municipio);
                command.Parameters.AddWithValue("@tipo_pista", radar.tipo_Pista);
                command.Parameters.AddWithValue("@sentido", radar.sentido);
                command.Parameters.AddWithValue("@situacao", radar.situacao);
                command.Parameters.AddWithValue("@data_da_inativacao", radar.data_Inativacao);
                command.Parameters.AddWithValue("@latitude", radar.latitude);
                command.Parameters.AddWithValue("@longitude", radar.longitude);
                command.Parameters.AddWithValue("@velocidade_leve", radar.velocidade_Leve);
                command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                SqlCommand command = new SqlCommand(Radar.DELETE, conn);
                command.Parameters.Add(new SqlParameter("@Id", id));
                if (command.ExecuteNonQuery() > 0)
                    result = true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public static void GenerateXML(List<Radar> lista)
        {
            if (lista.Count > 0)
            {
                var ListaRadar = new XElement("Root", from data in lista
                                                      select new XElement("radar",
                                                      new XElement("concessionaria", data.concessionaria),
                                                      new XElement("ano_do_pnv_snv", data.ano_PNV_SNV),
                                                      new XElement("tipo_de_radar", data.tipo_Radar),
                                                      new XElement("rodovia", data.rodovia),
                                                      new XElement("uf", data.uf),
                                                      new XElement("km_m", data.km_m),
                                                      new XElement("municipio", data.municipio),
                                                      new XElement("tipo_pista", data.tipo_Pista),
                                                      new XElement("sentido", data.sentido),
                                                      new XElement("situacao", data.situacao),
                                                      new XElement("data_da_inativacao", data.data_Inativacao),
                                                      new XElement("latitude", data.latitude),
                                                      new XElement("longitude", data.longitude),
                                                      new XElement("velocidade_leve", data.velocidade_Leve)
                                                      ));
                Console.WriteLine(ListaRadar);
            }
            else
            {
                Console.WriteLine("Não existe registro");
            }
        }
        public static void GenerateJson(List<Radar> listaRadar, string JsonSalvo)
        {
            string json = JsonSerializer.Serialize(listaRadar, new JsonSerializerOptions { WriteIndented = true }); //WriteIndented: saída com identação, formatação.
            File.WriteAllText(JsonSalvo, json);
            Console.WriteLine($"Arquivo {JsonSalvo} criado com sucesso.");
        }



    }

}

