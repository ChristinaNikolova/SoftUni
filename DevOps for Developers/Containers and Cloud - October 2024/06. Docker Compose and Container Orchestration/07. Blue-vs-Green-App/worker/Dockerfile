FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS builder

# Create a working directory
WORKDIR /Worker

# Copy the .csproj file and restore
COPY /src/Worker/Worker.csproj .
RUN dotnet restore

# Copy source files to the image
COPY /src .

# Build the project
RUN dotnet build "./Worker.csproj" -c Release -o /app/build

# Specify app image
FROM mcr.microsoft.com/dotnet/core/runtime:3.1

# Specify working directory for this stage
WORKDIR /Worker

# Tell Docker what command to run when our image is executed inside a container
ENTRYPOINT [ "dotnet", "Worker.dll" ]

# Copy the /out directory from the build stage into the runtime image
COPY --from=builder /app/build .