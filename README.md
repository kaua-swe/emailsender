# emailsender

Serviço em .NET para envio de e-mails via SMTP, utilizando [MailKit](https://github.com/jstedfast/MailKit) e [MimeKit](https://github.com/jstedfast/MimeKit).

## Tecnologias

- .NET 10
- MailKit / MimeKit
- Microsoft.Extensions.Configuration (User Secrets)
- xUnit (testes)

## Estrutura do projeto

```
emailsender/
├── Configuration/   # Classes de configuração (ex: opções de SMTP)
├── Interfaces/      # Contratos dos serviços
├── Services/        # Implementação do serviço de envio de e-mail
├── Properties/      # Configurações do projeto
├── Tests/           # Testes automatizados (xUnit)
├── Program.cs        # Ponto de entrada da aplicação
└── appsettings.json  # Configurações da aplicação
```

## Configuração

As credenciais de SMTP são gerenciadas via **User Secrets** do .NET, para evitar exposição de dados sensíveis.

Para configurar localmente:

```bash
dotnet user-secrets set "Email:Host" "seu-host-smtp"
dotnet user-secrets set "Email:Port" "587"
dotnet user-secrets set "Email:Usuario" "seu-usuario"
dotnet user-secrets set "Email:Senha" "sua-senha"
dotnet user-secrets set "Email:Remetente" "email-remetente"
dotnet user-secrets set "Email:Nome" "Nome do Remetente"
```

## ▶Executando o projeto

```bash
dotnet restore
dotnet build
dotnet run
```

## Rodando os testes

```bash
dotnet test
```

## Licença

Este projeto ainda não possui uma licença definida.