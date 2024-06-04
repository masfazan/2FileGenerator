using Newtonsoft.Json;

namespace Model
{
    public class Radar
    {
        public static readonly string INSERT = "INSERT INTO Radar (concessionaria, ano_do_pnv_snv, tipo_de_radar, rodovia, uf, km_m, municipio, tipo_pista, sentido, situacao, data_da_inativacao, latitude, longitude, velocidade_leve)";
        public static readonly string UPDATE = "UPDATE Radar SET concessionaria = @concessionaria, ano_do_pnv_snv = @ano_PNV_SNV, tipo_de_radar = @tipo_Radar, rodovia = @rodovia, uf = @uf, km_m = @km_m, municipio = @municipio, " +
            "tipo_pista = @tipo_Pista, sentido = @sentido, situacao = @situacao, data_da_inativacao = @data_Inativacao, latitude = @latitude, longitude = @longitude, velocidade_leve = @velocidade_Leve WHERE Id = @Id";
        public static readonly string DELETE = "DELETE FROM Radar WHERE Id = @Id";
        public static readonly string GETALL = "SELECT Id, concessionaria, ano_do_pnv_snv, tipo_de_radar, rodovia, uf, km_m, municipio, tipo_pista, sentido, situacao, data_da_inativacao, latitude, longitude, velocidade_leve FROM Radar";
        public static readonly string GET = "SELECT Id, concessionaria, ano_do_pnv_snv, tipo_de_radar, rodovia, uf, km_m, municipio, tipo_pista, sentido, situacao, data_da_inativacao, latitude, longitude, velocidade_leve FROM Radar WHERE Id = @Id";
        public static string SELECT = "select concessionaria, ano_do_pnv_snv, tipo_de_radar, rodovia, uf, km_m, municipio, tipo_pista, sentido, situacao, data_da_inativacao, latitude, longitude, velocidade_leve FROM Radar ";



        [JsonProperty("concessionaria")]
        public string concessionaria { get; set; }

        [JsonProperty("ano_do_pnv_snv")]
        public string @ano_PNV_SNV { get; set; }

        [JsonProperty("tipo_de_radar")]
        public string tipo_Radar { get; set; }

        [JsonProperty("rodovia")]
        public string rodovia { get; set; }

        [JsonProperty("uf")]
        public string uf { get; set; }

        [JsonProperty("km_m")]
        public string km_m { get; set; }

        [JsonProperty("municipio")]
        public string municipio { get; set; }

        [JsonProperty("tipo_pista")]
        public string tipo_Pista { get; set; }

        [JsonProperty("sentido")]
        public string sentido { get; set; }

        [JsonProperty("situacao")]
        public string situacao { get; set; }

        [JsonProperty("data_da_inativacao")]
        public List<DateOnly> data_Inativacao { get; set; }

        [JsonProperty("latitude")]
        public string latitude { get; set; }

        [JsonProperty("longitude")]
        public string longitude { get; set; }

        [JsonProperty("velocidade_leve")]
        public string velocidade_Leve { get; set; }
        public string DataDaInativacaoString => data_Inativacao != null ? string.Join(",", data_Inativacao) : null;

        public Radar()
        {

        }
        public Radar(string concessionaria, string ano_PNV_SNV, string tipo_Radar, string rodovia, string uf, string km_m, string municipio, string tipo_Pista, string sentido, string situacao, List<DateOnly> data_Inativacao, string latitude, string longitude, string velocidade_Leve)
        {
            this.concessionaria = concessionaria;
            this.ano_PNV_SNV = ano_PNV_SNV;
            this.tipo_Radar = tipo_Radar;
            this.rodovia = rodovia;
            this.uf = uf;
            this.km_m = km_m;
            this.municipio = municipio;
            this.tipo_Pista = tipo_Pista;
            this.sentido = sentido;
            this.situacao = situacao;
            this.data_Inativacao = data_Inativacao;
            this.latitude = latitude;
            this.longitude = longitude;
            this.velocidade_Leve = velocidade_Leve;
        }

        public override string ToString()
        {

            return $"concessionaria {concessionaria}\n, ano_do_pnv_snv{ano_PNV_SNV}\n, tipo_de_radar{tipo_Radar}\n, rodovia {rodovia}\n, " +
            $"uf{uf}\n, km_m{km_m}\n, municipio{municipio}\n, tipo_pista{tipo_Pista}\n, " +
            $"sentido{sentido}\n, situacao{situacao}\n, data_da_inativacao{data_Inativacao}\n, latitude{latitude}\n, longitude{longitude}\n, velocidade_leve{velocidade_Leve}\n";
        }
    }
}
