FROM microsoft/dotnet:3.0.100-preview2-sdk AS build
WORKDIR /app

# Build da aplicacao
COPY . ./
RUN dotnet publish ./sipsa/sipsa.Web -c Release -o out

# Build da imagem
FROM microsoft/dotnet:3.0.0-preview2-aspnetcore-runtime
WORKDIR /app
COPY --from=build /app/out .

# ENV AQUI

EXPOSE 80
ENTRYPOINT ["dotnet", "sipsa.Web.dll"]