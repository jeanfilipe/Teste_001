# Teste_001.api

## Visão Geral
Este é um projeto de API baseado em .NET, que fornece endpoints para autenticação e gerenciamento de vídeos. A documentação da API pode ser acessada via Swagger.

## Requisitos
- .NET 6 ou superior
- Docker (opcional, caso deseje rodar o projeto em container)
- Banco de dados configurado (caso aplicável)

## Instalação e Execução

1. **Clone o repositório**
```bash
  git clone <URL_DO_REPOSITORIO>
  cd Teste_001.api
```

2. **Restaure as dependências**
```bash
  dotnet restore
```

3. **Compile o projeto**
```bash
  dotnet build
```

4. **Execute a API**
```bash
  dotnet run
```

A API ficará disponível em `https://localhost:7288`.

## Documentação da API (Swagger)
Para acessar a documentação interativa, abra o navegador e acesse:
```
https://localhost:7288/swagger/index.html
```

## Endpoints Principais

### Autenticação
- **Login:** `POST /api/Auth/login`
  - Request Body (Podem ser usados os dados fornecidos.): 
    ```json
    {
      "email": "usuario@gmail.com",
      "password": "123456"
    }
    ```
  - Response: `200 OK`

### Gerenciamento de Vídeos
- **Obter todos os vídeos:** `GET /api/Video`
- **Obter um vídeo por ID:** `GET /api/Video/{id}`
- **Criar um vídeo:** `POST /api/Video`
  - Request Body:
    ```json
    {
      "title": "Título do Vídeo",
      "description": "Descrição do vídeo",
      "author": "Autor",
      "isActive": true,
      "duration": "00:05:30",
      "creationDate": "2025-02-01T12:00:00Z"
    }
    ```
  - Response: `200 OK`
- **Atualizar um vídeo:** `PUT /api/Video/{id}`
- **Deletar um vídeo:** `DELETE /api/Video/{id}`

### Busca de Vídeos
- **Pesquisar vídeos:** `GET /api/Video/search`
  - Parâmetros de query suportados:
    - `title`
    - `maxDuration`
    - `author`
    - `after`
    - `q`

### Importação do YouTube
- **Importar vídeos do YouTube:** `POST /api/YouTube/import`

## Executando via Docker (Opcional)
Caso deseje rodar o projeto em um container, utilize os comandos:
```bash
  docker build -t teste_001_api .
  docker run -p 7288:7288 teste_001_api
```
A API ficará disponível em `http://localhost:7288`.

## Considerações Finais
Certifique-se de que todas as dependências estão corretamente instaladas e configuradas antes de rodar o projeto. Em caso de problemas, verifique os logs da aplicação ou consulte a documentação oficial do .NET.

