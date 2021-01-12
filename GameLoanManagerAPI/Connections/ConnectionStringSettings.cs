using Microsoft.Extensions.Configuration;

namespace GameLoanManagerCore.Connections
{
    public class ConnectionStringSettings
    {
        /// <summary>
        /// não utilizar dentro da logica APENAS PARA TESTES UNITARIOS
        /// </summary>
        public static ConnectionStringSettings ConnectionsSSO_TOTEST()
        {
            
            return new ConnectionStringSettings(
                ".\\localhost,1401",
                "GameLoanManagerDB",
                "sa",
                 "1401",
                 "Castelo307#",
                 false,
                 false,
                 "Data Source=.\\localhost,1401;Initial Catalog=GameLoanManagerDB;Persist Security Info=True;User ID=sa;Password=Castelo307#;"
            );
        }

        public string Server { get; set; }
        public string Catalog { get; set; }
        public string User_ID { get; set; }
        public string Porta { get; set; }
        public string Password { get; set; }
        public bool LocalHost { get; set; }
        public bool Certificate { get; set; }
        public string ConexaoRedis { get; set; }

        public string ConnectionString =>
                     @$"Server=tcp:{Server}{(LocalHost ? @"\SQLEXPRESS" : "")},{Porta};
                        Initial Catalog={Catalog};
                        Persist Security Info=False;
                        User ID={User_ID};
                        Password ={Password};
                        MultipleActiveResultSets =False;
                        Encrypt=True;
                        TrustServerCertificate={(Certificate ? "True" : "False")};
                        Connection Timeout=30;"
                    ;

        public ConnectionStringSettings(IConfiguration config)
        {
            Server = config.GetValue<string>("ConnectionString:Server");
            Porta = config.GetValue<string>("ConnectionString:Port");
            Catalog = config.GetValue<string>("ConnectionString:Catalog");
            User_ID = config.GetValue<string>("ConnectionString:User_ID");
            Password = config.GetValue<string>("ConnectionString:Password");
            ConexaoRedis = config.GetValue<string>("ConnectionString:ConexaoRedis");
            LocalHost = config.GetValue<string>("ConnectionString:LocalHost") == "true" ? true : false;
            Certificate = config.GetValue<string>("ConnectionString:Certificate") == "true" ? true : false;
        }

        public ConnectionStringSettings(string server, string catalog, string user_ID, string porta, string password, bool localHost, bool certificate, string conexaoRedis)
        {
            Server = server;
            Catalog = catalog;
            User_ID = user_ID;
            Porta = porta;
            Password = password;
            LocalHost = localHost;
            Certificate = certificate;
            ConexaoRedis = conexaoRedis;
        }
    }
}
