# autolog-dotnet-api

Dotnet Minimal Api

## Comands

```bash
# run
dotnet run

# run watch
dotnet watch

# build
dotnet build

# docker run
docker-compose up --build -d
```

## 🗄️ Migrations

Em produção elas são executadas pelo arquivo .github/workflows/ci.yaml
Local são executadas quando a api sobe

### Fluxo

1.  Realizar as alterações nas Models
2.  Criar a migration: `dotnet ef migrations add <name>`
3.  Validar se a migrations foi criada de acordo com as alterações. Validar melhores práticas aqui.
4.  Atualizar banco local: `dotnet ef database update`

## 🚀 Fluxo de Deploy (CI/CD)

A aplicação utiliza um pipeline de integração e entrega contínua (CI/CD) automatizado via **AWS**, projetado para ser eficiente e de baixo custo.

### Arquitetura de Implantação

O fluxo de atualização automática é estruturado da seguinte forma:

1.  **Gatilho (Trigger)**: Sempre que um `push` é realizado na branch `main` do GitHub, um **Webhook** notifica o AWS CodeBuild.
2.  **Orquestração (AWS CodeBuild)**: O CodeBuild inicia o processo. Sua principal função neste projeto é atuar como um gateway de segurança, injetando as variáveis de ambiente (Secrets) e enviando os comandos de execução.
3.  **Comando Remoto (AWS SSM)**: Através do **AWS Systems Manager**, a AWS envia um `Run Command` para o agente instalado dentro da instância EC2. Isso elimina a necessidade de manter a porta 22 (SSH) aberta para o mundo.
4.  **Execução In-Place (EC2)**: A instância EC2 recebe a ordem e executa os seguintes passos internos:
    - Sincroniza o código fonte com o repositório (`git fetch` / `git reset`).
    - Reconstrói a imagem Docker localmente (`docker build`).
    - Reinicia os containers utilizando o `docker-compose.prod.yml`.
    - Remove imagens antigas/suspensas para otimizar o espaço em disco.

### Tecnologias e Serviços

- **GitHub Webhooks**: Gatilho automático.
- **AWS CodeBuild**: Gerenciador do pipeline.
- **AWS Systems Manager (SSM)**: Execução remota de comandos.
- **Docker & Docker Compose**: Containerização e orquestração.
- **Amazon EC2**: Servidor de aplicação (Host).

---

## 🛠 Manutenção e Diagnóstico

Caso precise intervir manualmente no servidor de produção (EC2), siga os passos abaixo:

### Acesso via SSH

```bash
ssh -i "sua-chave.pem" ec2-user@18.233.74.165
```

- Se erro `WARNING: UNPROTECTED PRIVATE KEY FILE!`, então executar comando: `chmod 400 sua-chave.pem`

## Conectar no Banco de Dados PostgreeSQL

- Comando: `sudo docker exec -it autolog_db psql -U postgres -d AUTOLOG_DB`
