#!/usr/bin/env bash

dotnet run --project ./Writer/Writer.Api/Writer.Api.csproj &
dotnet run --project ./Article/Article.Api/Article.Api.csproj &
dotnet run --project ./ApiGateway/OcelotAApiGateway/OcelotAApiGateway.csproj
