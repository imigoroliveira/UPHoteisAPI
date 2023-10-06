# API de Gerenciamento de Hotel

Bem-vindo à API de Gerenciamento de Hotel! Esta API foi desenvolvida para gerenciar informações relacionadas a um hotel, incluindo avaliações, clientes, hotéis, quartos, reservas e serviços. Ela permite que você crie, leia, atualize e exclua informações associadas a essas entidades.


## Como Usar

- Certifique-se de configurar um ambiente de desenvolvimento com .NET Core e um banco de dados compatível, como SQL Server ou SQLite.

- Clone este repositório e abra o projeto em sua IDE.

- Configure a conexão com o banco de dados no arquivo `appsettings.json` para que a API possa acessar o banco de dados.

- Execute as migrações para criar o esquema do banco de dados usando o comando `dotnet ef database update`.

- Execute o projeto usando `dotnet run` ou sua IDE.

- Use um cliente HTTP, como o Postman, para acessar os endpoints da API e gerenciar as informações relacionadas ao hotel.
