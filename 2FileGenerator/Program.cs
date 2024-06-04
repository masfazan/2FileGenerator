using Microsoft.Data.SqlClient;
using MongoDB.Driver;
using Repositories;
using Model;
using System.Collections.Generic;


public class Program
{
    public static void Main(string[] args)
    {
        GerenciadorConexaoBD DBconexao = GerenciadorConexaoBD.Instancia;
        MongoClient mongoClient = DBconexao.obterClientMongo();
        SqlConnection conexaoSQL = DBconexao.obterConexaoSQL();

        //recuperar dados SQL
        List<Radar> radares = new SQL().RecuperarSQL();

        //recuperar dados Mongo
        List<Radar> radaresmongo = new MongoDB().RecuperarMongo();

        //gravar dados Csv


        //gravar dados Json 
        RadarRepository.GenerateJson(radares, );

        //gravar Xml
        RadarRepository.GenerateXML(List < Radar > lista);

        DBconexao.FecharConexao();
    }
}