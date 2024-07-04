Desenvolvedor: Daniel Algusto

Tecnologias Utilizadas:

- ASP.NET Core MVC 6.0
- Entity Framework Core 6.0
- SQL Server 2019
- Bootstrap 5
- Chart.js
- Docker

Resumo:

  Este projeto foi desenvolvido como um teste técnico para a empresa TechNation/UneCont. Ele consiste em um sistema web para gerenciamento de notas fiscais, com um dashboard para visualização de indicadores de desempenho e uma lista de notas fiscais com filtros.

Instruções de Configuração e Execução:

1. Clonar o Repositório:
  - https://github.com/Dan-Algusto/TesteTechNation.git

2. Configurar a String de Conexão:
   - Abra o arquivo appsettings.json (ou appsettings.Development.json) na raiz do projeto.
   - Modifique a string de conexão DefaultConnection para apontar para o seu servidor SQL Server local.

3. Criar o Banco de Dados e as Tabelas:
   - Execute o script criar_tabelas.sql (incluído no repositório) para criar as tabelas necessárias no banco de dados.
     
   OBS Caso queira rodar local: Após criar o banco de dados, você precisará executar as migrations do Entity Framework Core para criar as tabelas necessárias. Para isso, execute o seguinte comando no Package Manager Console do Visual Studio:
 - Update-Database

  
4. Executar o Projeto com Docker:
   - Execute o seguinte comando para iniciar os containers do aplicativo e do banco de dados já com a criação da tabela:
     docker-compose up -d



Dashboard Web:

![image](https://github.com/Dan-Algusto/TesteTechNation/assets/94575507/ff3944fd-6627-4aab-a2d4-37228cfe962f)

Dashboard Mobile:


![image](https://github.com/Dan-Algusto/TesteTechNation/assets/94575507/d0ce79e6-4991-44b9-ade5-67c262a74c70)



     
