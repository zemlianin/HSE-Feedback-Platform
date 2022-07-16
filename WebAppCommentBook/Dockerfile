#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebAppCommentBook/WebAppCommentBook.csproj", "WebAppCommentBook/"]
RUN dotnet restore "WebAppCommentBook/WebAppCommentBook.csproj"
COPY . .
WORKDIR "/src/WebAppCommentBook"
RUN dotnet build "WebAppCommentBook.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAppCommentBook.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAppCommentBook.dll"]
