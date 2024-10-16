FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

ENV TZ=America/Guatemala
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

#EXPOSE 443

COPY ["ProyectoSeminarioControlNotas.csproj", "./"]
RUN dotnet restore "./ProyectoSeminarioControlNotas.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ProyectoSeminarioControlNotas.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProyectoSeminarioControlNotas.csproj" -c Release -o /app/publish

FROM build AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY octubre.pfx /https/octubre.pfx

ENTRYPOINT ["dotnet", "ProyectoSeminarioControlNotas.dll"]