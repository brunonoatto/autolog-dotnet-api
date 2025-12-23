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

## Migrations

Em produção elas são executadas pelo arquivo .github/workflows/ci.yaml
Local são executadas quando a api sobe

```bash
# add
dotnet ef migrations add <name>

# update database
dotnet ef database update
```

## AWS

- Certificado em downloads, mover para um local seguro
- Acessar console da instância em PROD: `ssh -i autolog-key.pem ec2-user@18.233.74.165`
