namespace emailsender.Configuration
{
    public class EmailSettings
    {
        public string Nome { get; set; } = string.Empty;
        
        public string Remetente { get; set; } = string.Empty;
        
        public string Host { get; set; } = string.Empty;
        
        public int Port { get; set; }
        
        public string Usuario { get; set; } = string.Empty;
        
        public string Senha { get; set; } = string.Empty;
    }
}