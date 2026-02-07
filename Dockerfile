# Estágio 1: Build da Aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Instala a ferramenta de migrations globalmente dentro do container de build
RUN dotnet tool install --global dotnet-ef --version 8.0.0
# Adiciona o caminho das ferramentas ao PATH do sistema para que o comando 'dotnet ef' seja reconhecido
ENV PATH="$PATH:/root/.dotnet/tools"

# Copiar arquivos de projeto e restaurar dependências
COPY ["autolog-dotnet-api.csproj", "."]
RUN dotnet restore "autolog-dotnet-api.csproj"

# Copiar o restante do código e compilar
COPY . .
RUN dotnet build "autolog-dotnet-api.csproj" -c Release -o /app/build

# Estágio 2: Publicação
FROM build AS publish
RUN dotnet publish "autolog-dotnet-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Estágio 3: Runtime Final (Imagem Leve)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Variáveis de ambiente padrão
ENV ASPNETCORE_URLS=http://+:80

EXPOSE 80
ENTRYPOINT ["dotnet", "autolog-dotnet-api.dll"]