using Microsoft.Data.SqlClient;
using Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json;


namespace Repositories
{
    public class MongoDB
    {
        private readonly string sqlConnectionString; //="Server=127.0.0.1; Database=DBRadar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=True";
        private readonly string mongoConnectionString;// = "mongodb://root:Mongo%402024%23@localhost:27017";
        private readonly string mongoDatabaseName;// = "DBRadar";
        private readonly string mongoCollectionName;// = "Radar";
        SqlConnection sqlConnection; //= new SqlConnection(sqlConnectionString);

        public IMongoCollection<Radar> colecao;

        public MongoDB()
        {
            sqlConnectionString = "Server=127.0.0.1; Database=DBRadar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=True";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);
            mongoDatabaseName = "DBRadar";
            mongoCollectionName = "Radar";
            mongoConnectionString = "mongodb://root:Mongo%402024%23@localhost:27017";
            MongoClient mongoClient = new MongoClient(mongoConnectionString);
        }


        public bool TransferirDadosParaMongo()
        {
            try
            {
                var mongoClient = new MongoClient(mongoConnectionString);
                var mongoDatabase = mongoClient.GetDatabase(mongoDatabaseName);
                var mongoCollection = mongoDatabase.GetCollection<Radar>(mongoCollectionName);

                using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString))
                {
                    sqlConnection.Open();
                    //string sqlQuery = "SELECT concessionaria, ano_do_pnv_snv, tipo_de_radar, rodovia, uf, km_m, municipio, tipo_pista, sentido, situacao, data_da_inativacao, latitude, longitude, velocidade_leve FROM Radar";

                    using (SqlCommand sqlCommand = new SqlCommand(Radar.SELECT, sqlConnection))
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var radar = new Radar
                            {
                                concessionaria = reader["concessionaria"].ToString(),
                                ano_PNV_SNV = reader["ano_do_pnv_snv"].ToString(),
                                tipo_Radar = reader["tipo_de_radar"].ToString(),
                                rodovia = reader["rodovia"].ToString(),
                                uf = reader["uf"].ToString(),
                                km_m = reader["km_m"].ToString(),
                                municipio = reader["municipio"].ToString(),
                                tipo_Pista = reader["tipo_pista"].ToString(),
                                sentido = reader["sentido"].ToString(),
                                situacao = reader["situacao"].ToString(),
                                data_Inativacao = new(),//reader["data_Inativacao"].ToString("dd/MM/yyyy"),
                                latitude = reader["latitude"].ToString(),
                                longitude = reader["longitude"].ToString(),
                                velocidade_Leve = reader["velocidade_leve"].ToString()
                            };
                            mongoCollection.InsertOne(radar);
                        }
                    }

                }
                Console.WriteLine("Dados transferidos para o MongoDB com sucesso.");
                return true;
            }
            catch (Exception e)
            {

                Console.WriteLine("Dados não tranferidos, erro: " + e.Message);
                return false;
            }
        }
        public List<Radar> RecuperarMongo()
        {
            List<Radar> listamongo = new List<Radar>();
            try
            {
                var conexao = new MongoClient(mongoConnectionString);
                var database = conexao.GetDatabase(mongoDatabaseName);
                var colecao = database.GetCollection<BsonDocument>("Radar");
                var filter = Builders<BsonDocument>.Filter.Empty;
                var documento = colecao.Find(filter).ToList();
                //return colecao.Find(radar => true).ToList();
                foreach (var document in documento)
                {
                    Radar recmongo = new Radar
                    {
                        concessionaria = document.GetValue("concessionaria").AsString,
                        ano_PNV_SNV = document.GetValue("ano_do_pnv_snv").AsString,
                        tipo_Radar = document.GetValue("tipo_de_radar").AsString,
                        rodovia = document.GetValue("rodovia").AsString,
                        uf = document.GetValue("uf").AsString,
                        km_m = document.GetValue("km_m").AsString,
                        municipio = document.GetValue("municipio").AsString,
                        tipo_Pista = document.GetValue("tipo_pista").AsString,
                        sentido = document.GetValue("sentido").AsString,
                        situacao = document.GetValue("situacao").AsString,
                        data_Inativacao = null,
                        latitude = document.GetValue("latitude").AsString,
                        longitude = document.GetValue("longitude").AsString,
                        velocidade_Leve = document.GetValue("longitude").AsString
                    };
                    listamongo.Add(recmongo);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return listamongo;
        }

    }
}

