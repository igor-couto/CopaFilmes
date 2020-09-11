# Copa do Mundo de Filmes 🏆🎬

A copa do mundo de filmes é um sistema web onde o usuário pode realizar competições entre filmes selecionados dentro de uma determinada lista.
Ao selecionar os filmes participantes, disputas acontecem entre os filmes baseadas em sua nota e um campeão é definido.

## Backend

O projeto de backend consiste em uma Web API desenvolvida utilizado C# com o framework .NET Core 3.1. O projeto pode ser encontrado na pasta backend nesse mesmo repositório.

### Como executar

1. Entre na pasta `/backend`
2. Execute o comando de terminal `dotnet rurestore` para instalar as dependências NuGet do projeto
3. Execute o comando de terminal `dotnet run`

### Executando os testes

1. Entre na pasta `/backend`
2. Execute o comando de terminal `dotnet rurestore` para instalar as dependências NuGet do projeto
3. Execute o comando de terminal `dotnet run`

## Frontend

O projeto de frontend foi contruido em ReactJs e se encontra na pasta backend/ neste mesmo repositório.

### Como executar

1. Entre na pasta `/frontend`
2. Execute o comando de terminal `yarn install` para instalar as dependências NPM do projeto
3. Execute o comando de terminal `yarn start` para iniciar a aplicação
4. Acesse o endereço que irá aparecer no terminal para abrir a aplicação em seu navegador

# Melhorias

Existem alguns pontos que poderiam ser aperfeiçoados neste sistema.

- Implementar uma notificação para o usuário em caso de erro
- Implementar um componente de loading para mostrar quando o sistema está buscando os filmes ou realizando o campeonato
- Criar Botão para voltar e realizar um novo campeonato
- Permitir que mais filmes sejam selecionados ao invés de sempre 8
- Fazer testes no frontend
- Testes de interface com alguma ferramenta como Selenium
