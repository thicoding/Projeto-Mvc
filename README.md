# Sistema de Gestão de Compras

## Descrição

Desenvolvendo um sistema web MVC com **ASP.NET Core** para gestão de compras, que oferece autenticação de usuários e suporte a múltiplos idiomas.  
O backend utiliza **ASP.NET Core MVC (SDK 7.0.410)** e o banco de dados **MariaDB**.  
No frontend, são empregadas **Razor Pages, HTML, CSS e JavaScript** para oferecer uma interface limpa e responsiva.

---

## 🛠️ Tecnologias Utilizadas

- **Backend:** ASP.NET Core MVC (SDK 7.0.410)
- **Banco de Dados:** MariaDB
- **Frontend:** Razor Pages, HTML, CSS e JavaScript
- **Segurança:** 
  - Autenticação baseada em Claims
  - Proteção contra XSS e CSRF
- **Configuração:** 
  - Suporte a múltiplos ambientes
  - Uso de User Secrets para gerenciamento de informações sensíveis

---

## 🚀 Instalação e Configuração

### 1. Pré-requisitos

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) instalado na máquina.
- [MariaDB](https://mariadb.org/download/) instalado e configurado.
- Git para clonar o repositório.

### 2. Clonando o Repositório

```bash
git clone git@github.com:thicoding/Projeto-Mvc.git

Após a clonagem, entre no diretório do projeto:

cd Projeto-Mvc

3. Configurando o Banco de Dados

Abra o arquivo appsettings.json (ou utilize User Secrets para informações sensíveis) e configure a string de conexão com seu banco de dados:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MinhaBase;User=root;Password=MinhaSenha;"
  }
}
5. Rodando o Projeto

Para iniciar a aplicação, execute:

dotnet run

Abra o navegador e acesse http://localhost:5000 (ou a porta exibida no terminal) para visualizar a aplicação em execução.
🎨 Demonstração Visual
Tela Inicial

Exibe a página de boas-vindas e login da aplicação.
Página de Compras

Exibe a listagem e o detalhamento dos produtos e compras.
Dashboard Administrativo

Visualização centralizada das métricas e dados do sistema.
<p align="center"> <img src="./assets/dashboard.png" width="600" alt="Dashboard Administrativo"/> </p>

    Nota: Certifique-se de que as imagens estejam na pasta assets ou ajuste os caminhos conforme necessário.

📁 Estrutura do Projeto

A estrutura do repositório é organizada da seguinte forma:

Projeto-Mvc/
│
├── Controllers/         # Lógica dos controladores do sistema
├── Models/              # Definição dos modelos de dados
├── Views/               # Páginas Razor e layouts
├── wwwroot/             # Arquivos estáticos (CSS, JavaScript, imagens)
├── appsettings.json     # Configurações da aplicação
├── Program.cs           # Ponto de entrada e configuração do app
└── README.md            # Documentação do projeto

🤝 Contribuindo

Contribuições são sempre bem-vindas! Para colaborar, siga os passos abaixo:

    Faça um fork do repositório.

    Crie uma branch para sua feature ou correção:

git checkout -b minha-feature

Faça suas alterações e realize um commit com uma mensagem descritiva:

git commit -m "Adiciona nova feature XYZ"

Envie sua branch para o repositório remoto:

    git push origin minha-feature

    Abra um Pull Request descrevendo as alterações realizadas.

📄 Licença

Este projeto está licenciado sob a Licença MIT.
📞 Contato

Para dúvidas, sugestões ou contribuições, entre em contato via seu-email@exemplo.com.


Esta versão detalhada abrange desde os pré-requisitos até a execução da aplicação e contribuições. Basta ajustar os detalhes conforme a necessidade do seu projeto.

