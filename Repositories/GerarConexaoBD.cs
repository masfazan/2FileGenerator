using Microsoft.Data.SqlClient;
using MongoDB.Driver;

namespace Repositories
{
    public class GerenciadorConexaoBD
    {
        private static GerenciadorConexaoBD instancia;
        private static readonly object objinstancia = new object();

        private MongoClient clienteMongo;
        private SqlConnection conexaoSQL;

        private GerenciadorConexaoBD()
        {
            clienteMongo = new MongoClient("mongodb://root:Mongo%402024%23@localhost:27017");
            conexaoSQL = new SqlConnection("Server=127.0.0.1; Database=DBRadar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=True");
            //variáveis que vão manter a conexão
        }
        public static GerenciadorConexaoBD Instancia
        {
            get
            {
                lock (objinstancia) //objeto garante que abra a instância apenas 1 vez
                {
                    if (instancia == null)
                    {
                        instancia = new GerenciadorConexaoBD();
                    }
                    return instancia;
                }
            }
        }

        public MongoClient obterClientMongo()
        {
            if (clienteMongo == null)
            {
                clienteMongo = new MongoClient("mongodb://root:Mongo%402024%23@localhost:27017");
            }
            return clienteMongo;
        }

        public SqlConnection obterConexaoSQL()
        {
            if (conexaoSQL == null)
            {
                conexaoSQL = new SqlConnection("Server=127.0.0.1; Database=DBRadar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=True");
            }
            return conexaoSQL;
        }
        public void FecharConexao()
        {
            clienteMongo.Cluster.Dispose(); //Cluster.Dispose encerra a conexão, liberar recursos
            conexaoSQL.Close();
        }

    }
}
