# API de Gerenciamento de Hotel

Bem-vindo à API de Gerenciamento de Hotel! Esta API foi desenvolvida para gerenciar informações relacionadas a um hotel, incluindo avaliações, clientes, hotéis, quartos, reservas e serviços. Ela permite que você crie, leia, atualize e exclua informações associadas a essas entidades.

## Endpoints

### Avaliação

#### Cadastrar uma Avaliação

- **URL:** `POST /Avaliacao/cadastrar`
- **Descrição:** Este endpoint permite cadastrar uma nova avaliação de hotel no sistema.
- **Corpo da Requisição:** Deve conter os detalhes da avaliação, como estrelas, comentário e ID do hotel.
- **Resposta de Sucesso:** Retorna os detalhes da avaliação cadastrada.

#### Listar Avaliações

- **URL:** `GET /Avaliacao/listar`
- **Descrição:** Este endpoint retorna uma lista de todas as avaliações de hotéis disponíveis.

#### Buscar Avaliação por ID

- **URL:** `GET /Avaliacao/buscar/{id}`
- **Descrição:** Este endpoint permite buscar uma avaliação específica com base em seu ID.
- **Resposta de Sucesso:** Retorna os detalhes da avaliação encontrada.

#### Atualizar Avaliação

- **URL:** `PUT /Avaliacao/alterar`
- **Descrição:** Este endpoint permite atualizar as informações de uma avaliação existente no sistema. Você deve fornecer o ID da avaliação e os novos detalhes.
- **Resposta de Sucesso:** Retorna uma resposta de sucesso após a atualização.

#### Excluir Avaliação

- **URL:** `DELETE /Avaliacao/excluir/{id}`
- **Descrição:** Este endpoint permite excluir uma avaliação com base em seu ID.
- **Resposta de Sucesso:** Retorna uma resposta de sucesso após a exclusão.

### Cliente

#### Cadastrar um Cliente

- **URL:** `POST /Cliente/cadastrar`
- **Descrição:** Este endpoint permite cadastrar um novo cliente no sistema.
- **Corpo da Requisição:** Deve conter os detalhes do cliente, como nome, telefone e endereço.
- **Resposta de Sucesso:** Retorna os detalhes do cliente cadastrado.

#### Listar Clientes

- **URL:** `GET /Cliente/listar`
- **Descrição:** Este endpoint retorna uma lista de todos os clientes cadastrados.

#### Buscar Cliente por ID

- **URL:** `GET /Cliente/buscar/{id}`
- **Descrição:** Este endpoint permite buscar um cliente específico com base em seu ID.
- **Resposta de Sucesso:** Retorna os detalhes do cliente encontrado.

#### Atualizar Cliente

- **URL:** `PUT /Cliente/alterar`
- **Descrição:** Este endpoint permite atualizar as informações de um cliente existente no sistema. Você deve fornecer o ID do cliente e os novos detalhes.
- **Resposta de Sucesso:** Retorna uma resposta de sucesso após a atualização.

#### Excluir Cliente

- **URL:** `DELETE /Cliente/excluir/{id}`
- **Descrição:** Este endpoint permite excluir um cliente com base em seu ID.
- **Resposta de Sucesso:** Retorna uma resposta de sucesso após a exclusão.

### Hotel

#### Cadastrar um Hotel

- **URL:** `POST /Hotel/cadastrar`
- **Descrição:** Este endpoint permite cadastrar um novo hotel no sistema.
- **Corpo da Requisição:** Deve conter os detalhes do hotel, como nome, endereço e classificação.
- **Resposta de Sucesso:** Retorna os detalhes do hotel cadastrado.

#### Listar Hotéis

- **URL:** `GET /Hotel/listar`
- **Descrição:** Este endpoint retorna uma lista de todos os hotéis cadastrados.

#### Buscar Hotel por ID

- **URL:** `GET /Hotel/buscar/{id}`
- **Descrição:** Este endpoint permite buscar um hotel específico com base em seu ID.
- **Resposta de Sucesso:** Retorna os detalhes do hotel encontrado.

#### Atualizar Hotel

- **URL:** `PUT /Hotel/alterar`
- **Descrição:** Este endpoint permite atualizar as informações de um hotel existente no sistema. Você deve fornecer o ID do hotel e os novos detalhes.
- **Resposta de Sucesso:** Retorna uma resposta de sucesso após a atualização.

#### Excluir Hotel

- **URL:** `DELETE /Hotel/excluir/{id}`
- **Descrição:** Este endpoint permite excluir um hotel com base em seu ID.
- **Resposta de Sucesso:** Retorna uma resposta de sucesso após a exclusão.

### Quarto

#### Cadastrar um Quarto

- **URL:** `POST /Quarto/cadastrar`
- **Descrição:** Este endpoint permite cadastrar um novo quarto em um hotel.
- **Corpo da Requisição:** Deve conter os detalhes do quarto, como tipo, preço e disponibilidade.
- **Resposta de Sucesso:** Retorna os detalhes do quarto cadastrado.

#### Listar Quartos

- **URL:** `GET /Quarto/listar`
- **Descrição:** Este endpoint retorna uma lista de todos os quartos disponíveis em hotéis.

#### Buscar Quarto por ID

- **URL:** `GET /Quarto/buscar/{id}`
- **Descrição:** Este endpoint permite buscar um quarto específico com base em seu ID.
- **Resposta de Sucesso:** Retorna os detalhes do quarto encontrado.

#### Atualizar Quarto

- **URL:** `PUT /Quarto/alterar`
- **Descrição:** Este endpoint permite atualizar as informações de um quarto existente no sistema. Você deve fornecer o ID do quarto e os novos detalhes.
- **Resposta de Sucesso:** Retorna uma resposta de sucesso após a atualização.

#### Excluir Quarto

- **URL:** `DELETE /Quarto/excluir/{id}`
- **Descrição:** Este endpoint permite excluir um quarto com base em seu ID.
- **Resposta de Sucesso:** Retorna uma resposta de sucesso após a exclusão.

### Reserva

#### Cadastrar uma Reserva

- **URL:** `POST /Reserva/cadastrar`
- **Descrição:** Este endpoint permite cadastrar uma nova reserva em um hotel.
- **Corpo da Requisição:** Deve conter os detalhes da reserva, como data, ID do cliente, ID do quarto e horário.
- **Resposta de Sucesso:** Retorna os detalhes da reserva cadastrada.

#### Listar Reservas

- **URL:** `GET /Reserva/listar`
- **Descrição:** Este endpoint retorna uma lista de todas as reservas de quartos existentes.

#### Buscar Reserva por ID

- **URL:** `GET /Reserva/buscar/{id}`
- **Descrição:** Este endpoint permite buscar uma reserva específica com base em seu ID.
- **Resposta de Sucesso:** Retorna os detalhes da reserva encontrada.

#### Atualizar Reserva

- **URL:** `PUT /Reserva/alterar`
- **Descrição:** Este endpoint permite atualizar as informações de uma reserva existente no sistema. Você deve fornecer o ID da reserva e os novos detalhes.
- **Resposta de Sucesso:** Retorna uma resposta de sucesso após a atualização.

#### Excluir Reserva

- **URL:** `DELETE /Reserva/excluir/{id}`
- **Descrição:** Este endpoint permite excluir uma reserva com base em seu ID.
- **Resposta de Sucesso:** Retorna uma resposta de sucesso após a exclusão.

### Serviço

#### Cadastrar um Serviço

- **URL:** `POST /Servico/cadastrar`
- **Descrição:** Este endpoint permite cadastrar um novo serviço oferecido por um hotel.
- **Corpo da Requisição:** Deve conter os detalhes do serviço, como nome, preço, disponibilidade, descrição e horário de funcionamento.
- **Resposta de Sucesso:** Retorna os detalhes do serviço cadastrado.

#### Listar Serviços

- **URL:** `GET /Servico/listar`
- **Descrição:** Este endpoint retorna uma lista de todos os serviços disponíveis em hotéis.

#### Buscar Serviço por ID

- **URL:** `GET /Servico/buscar/{id}`
- **Descrição:** Este endpoint permite buscar um serviço específico com base em seu ID.
- **Resposta de Sucesso:** Retorna os detalhes do serviço encontrado.

#### Atualizar Serviço

- **URL:** `PUT /Servico/alterar`
- **Descrição:** Este endpoint permite atualizar as informações de um serviço existente no sistema. Você deve fornecer o ID do serviço e os novos detalhes.
- **Resposta de Sucesso:** Retorna uma resposta de sucesso após a atualização.

#### Excluir Serviço

- **URL:** `DELETE /Servico/excluir/{id}`
- **Descrição:** Este endpoint permite excluir um serviço com base em seu ID.
- **Resposta de Sucesso:** Retorna uma resposta de sucesso após a exclusão.

## Como Usar

- Certifique-se de configurar um ambiente de desenvolvimento com .NET Core e um banco de dados compatível, como SQL Server ou SQLite.

- Clone este repositório e abra o projeto em sua IDE.

- Configure a conexão com o banco de dados no arquivo `appsettings.json` para que a API possa acessar o banco de dados.

- Execute as migrações para criar o esquema do banco de dados usando o comando `dotnet ef database update`.

- Execute o projeto usando `dotnet run` ou sua IDE.

- Use um cliente HTTP, como o Postman, para acessar os endpoints da API e gerenciar as informações relacionadas ao hotel.
