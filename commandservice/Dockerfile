# Multi-stage build file

# Stage 1 - Buid project. 
# Stage 1 Output - Image with project build dlls

# Download layer of dotnet sdk files for building src code
FROM mcr.microsoft.com/dotnet/sdk:7.0 as BUILD

# create a workdir. If not specified, cmds below will execute in root folder. 
# Chances are there, files may be overridden
WORKDIR /src

# Copy sln and project first. i.e, without .cs files.
# This will create a layer of dependencies. The purpose of creating this as separate layer is because, these files will have
# less frequency for changes.
# COPY *.sln .
COPY *.csproj .
RUN dotnet restore
# Copy source code files
COPY . .
# Buid the project and output the files into out folder
RUN dotnet publish -c Release -o out
# Stage 2 - Create image with only runtime and app dll.
# Run container using stage 1 image.
# container will have sdk, src and dll's in out folder.
# To create asp.net image:
# 1. Pull run time files
# 2. copy app's dll 

# Download layers of aspnet runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0

# create a working directory
WORKDIR /app

# copy contents from stage 1 Build's /src/out folder to /app directory
COPY --from=BUILD /src/out .

# # run the process dotnet with args configHTTPS.dll
ENTRYPOINT [ "dotnet", "commandservice.dll" ]