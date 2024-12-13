# Projeto de Gerenciamento de Sintomas

## Descrição

Este é um projeto MVC desenvolvido em ASP.NET Core para gerenciar informações sobre sintomas de pacientes. O sistema permite o cadastro, visualização, edição e exclusão de sintomas, além de associar cada sintoma a diferentes tipos e severidades.

## Funcionalidades

- Cadastro de novos sintomas e pacientes.
- Listagem de todos os sintomas registrados.
- Associação de sintomas a diferentes tipos (usando enums).
- Visualização detalhada de cada sintoma e paciente.
- Edição e atualização de informações dos sintomas e de pacientes.
- Exclusão de sintomas e pacientes cadastrados.

## Tecnologias Utilizadas

- **ASP.NET Core MVC**: Framework principal para o desenvolvimento da aplicação.
- **Entity Framework Core**: ORM para interação com o banco de dados.
- **Razor Pages**: Para renderização das views dinâmicas.
- **Bootstrap**: Para estilização e responsividade.

## Estrutura do Projeto

- **Models**: Contém as classes que representam as entidades do sistema, como `Symptom`, `SymptomType` e `SeverityType`.
- **Services**: Contém os métodos para modificações no banco de dados.
- **Controllers**: Inclui os controladores que gerenciam a lógica do sistema, como `SymptomsController`.
- **Views**: Armazena as views da aplicação, como listagens e formulários.

## Requisitos do Sistema

- .NET 6 ou superior.
- Banco de dados relacional MySQL.

## Configuração e Execução

1. Clone o repositório:

   ```bash
   git clone <url-do-repositorio>
   ```

2. Navegue até o diretório do projeto:

   ```bash
   cd <nome-do-projeto>
   ```

3. Configure o banco de dados no arquivo `appsettings.json`:

   ```json
   "ConnectionStrings": {
       "SymptomContext": "<sua-string-de-conexão>"
   }
   ```

4. Aplique as migrações:

   ```bash
   dotnet ef database update
   ```

5. Execute o projeto:

   ```bash
   dotnet run
   ```

6. Acesse no navegador:

   ```
   http://localhost:5000
   ```

## Como Contribuir

1. Faça um fork do repositório.
2. Crie uma branch para sua feature ou correção:
   ```bash
   git checkout -b minha-feature
   ```
3. Commit suas alterações:
   ```bash
   git commit -m "Descrição da minha feature"
   ```
4. Envie sua branch para o repositório remoto:
   ```bash
   git push origin minha-feature
   ```
5. Abra um Pull Request.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

