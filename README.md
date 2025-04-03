Sistema de Gestão de Compras


Este projeto é um sistema web MVC desenvolvido com ASP.NET Core para gestão de compras, oferecendo autenticação de usuários e suporte a múltiplos idiomas.


🛠️ Tecnologias Utilizadas


Backend: ASP.NET Core MVC (SDK 7.0.410)

Banco de Dados: MariaDB

Frontend: Razor Pages, HTML, CSS e JavaScript

Segurança: Autenticação baseada em Claims, proteção contra XSS e CSRF

Configuração: Suporte a múltiplos ambientes e uso de User Secrets para informações sensíveis

🚀 Instalação

Siga os passos abaixo para instalar e rodar o projeto:

Clone o repositório:

git clone git@github.com:thicoding/Projeto-Mvc.git

Entre no diretório do projeto:

cd Projeto-Mvc

Configure o banco de dados no arquivo appsettings.json:

"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MinhaBase;User=root;Password=MinhaSenha;"
}

Aplique as migrações do banco de dados:

dotnet ef database update

Rode o projeto:

dotnet run
