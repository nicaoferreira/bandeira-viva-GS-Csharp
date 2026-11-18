# Bandeira Viva — Backend C#/.NET

Backend acadêmico da CitizenTech **Bandeira Viva**, proposta para apoiar moradores, trabalhadores e banhistas de São Vicente (SP) com informações mais compreensíveis sobre as condições de balneabilidade.

## Integrantes

- Luiz Felipe Motta da Silva - RM 559126
- Nicolas Lorenzo Ferreira da Silva - RM 557962
- Pedro Henrique Faim dos Santos - RM 557440

## Problema e proposta

O projeto piloto considera a Praia do Itararé (Posto 2) e a Praia do Gonzaguinha. A proposta reúne registros de qualidade da água e relatos comunitários para facilitar a consulta das condições das praias.

Este backend é uma primeira implementação funcional. Os dados iniciais são demonstrativos; não representam medições oficiais em tempo real da CETESB, CEMADEN, INMET ou Marinha.

## Tecnologias

- C# e ASP.NET Core Web API (.NET 10)
- Entity Framework Core 10
- SQLite
- LINQ
- Injeção de dependência
- Programação assíncrona com `async`/`await`
- Swagger
- xUnit

## Estrutura

```text
src/
  BandeiraViva.Api/
    Controllers/
    Data/
    DTOs/
    Interfaces/
    Models/
    Services/
tests/
  BandeiraViva.Tests/
```

## Pré-requisitos

- .NET 10 SDK
- Visual Studio 2022 atualizado com suporte ao .NET 10, ou Visual Studio 2026
- Git (para publicar no GitHub)

Verifique a instalação:

```bash
dotnet --version
```

## Como executar

Na pasta raiz do repositório:

```bash
dotnet restore
dotnet run --project src/BandeiraViva.Api
```

A API inicia nos endereços exibidos no terminal. Em ambiente Development, a documentação Swagger fica disponível em `/swagger`.

O banco SQLite `bandeira-viva.db` é criado automaticamente na primeira execução, com dois pontos de praia demonstrativos.

## Como executar os testes

```bash
dotnet test
```

## Endpoints

| Método | Endpoint | Finalidade |
|---|---|---|
| GET | `/` | Verificar se a API está online |
| GET | `/api/beaches` | Listar praias ativas |
| GET | `/api/beaches/{id}` | Consultar uma praia |
| GET | `/api/waterreadings/beach/{beachId}` | Consultar medições de uma praia |
| POST | `/api/waterreadings` | Registrar medição e classificar o resultado |
| GET | `/api/anonymousreports/beach/{beachId}` | Consultar relatos de uma praia |
| POST | `/api/anonymousreports` | Registrar relato sem identificação pessoal |

### Exemplo — registrar medição

`POST /api/waterreadings`

```json
{
  "beachId": 1,
  "turbidityNtu": 8.5,
  "temperatureCelsius": 24.2,
  "enterococciPer100Ml": 75,
  "source": "Simulação acadêmica"
}
```

### Exemplo — registrar relato anônimo

`POST /api/anonymousreports`

```json
{
  "beachId": 1,
  "description": "Presença de resíduos próximos à faixa de areia.",
  "category": "Resíduos"
}
```

## Conceitos da disciplina demonstrados

- **POO:** entidades de domínio, serviços e responsabilidades separadas.
- **Interfaces:** contratos para os serviços e classificador.
- **Injeção de dependência:** registro e resolução de serviços no contêiner do ASP.NET Core.
- **Web API REST:** controllers, rotas HTTP e códigos de resposta.
- **EF Core:** `DbContext`, entidades e persistência SQLite.
- **LINQ:** filtros, ordenação e consultas sobre os conjuntos de dados.
- **Async/Await:** operações assíncronas de acesso ao banco.
- **Testes unitários:** testes do classificador de condições.

## Observações sobre a classificação

O classificador usa um limite simplificado de referência de 100 UFC/100mL para demonstrar a regra no protótipo. Isso **não constitui uma classificação oficial de balneabilidade** e não substitui os critérios, períodos de amostragem e regras da CETESB. A aplicação deve deixar essa limitação clara ao cidadão.

## Privacidade

O endpoint de relatos não solicita nome, e-mail, telefone ou outros identificadores pessoais. Não inclua dados pessoais no texto do relato.

## Evidências de funcionamento


1. Print da API executando.
<img width="1919" height="988" alt="image" src="https://github.com/user-attachments/assets/36d076ef-ded8-41ca-b980-04d0c712d8fa" />

2. GET – Listar todas as praias
<img width="1919" height="991" alt="image" src="https://github.com/user-attachments/assets/752d16b5-b5ed-447c-8463-7b01e782e67b" />
 
3. GET – Consultar praia por ID
<img width="1919" height="995" alt="image" src="https://github.com/user-attachments/assets/69047b79-0950-4bb6-b73a-06341f1f372b" />

4. POST – Cadastrar leitura da água
<img width="1919" height="1031" alt="image" src="https://github.com/user-attachments/assets/646aa005-f40e-4e76-a9a6-fd634a119c7e" />

5. GET – Consultar histórico de leituras da praia
<img width="1919" height="1029" alt="image" src="https://github.com/user-attachments/assets/26b0a340-fe4b-4728-bc61-9e4d9fbeeab9" />

6. POST – Registrar denúncia anônima
<img width="1919" height="1029" alt="image" src="https://github.com/user-attachments/assets/b25ef9b5-18bb-46f8-9d83-fddb8bd9c123" />

7. GET – Consultar denúncias por praia
<img width="1919" height="1031" alt="image" src="https://github.com/user-attachments/assets/5a05f38a-238d-49ee-b558-565101ff1f5b" />


## Evoluções previstas

- Integração com fontes públicas de meteorologia, marés e histórico de balneabilidade.




- Recebimento de dados do dispositivo ESP32.
- Integração com o aplicativo mobile.
- Integração com o modelo de Machine Learning da equipe.
- Migrações formais do Entity Framework Core para evolução do banco de dados.





## Prompts

```bash
Olá. preciso de ajuda para refinar meu README de um trabalho de C#
```
