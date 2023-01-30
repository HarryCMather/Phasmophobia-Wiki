# Pull down the .NET SDK base image for building the application:
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build-project

# Install Git CLI, allowing the source files to be downloaded:
RUN apk update && apk add git

# Clone the latest master source files from GitHub:
RUN git clone https://github.com/HarryCMather/Phasmophobia-Wiki

# Build and publish the project, outputting the build files into the "/Output" folder:
RUN dotnet publish "./Phasmophobia-Wiki/Phasmophobia Wiki/Phasmophobia Wiki.csproj" --configuration Release --output /Output


# Pull down the .NET ASPNET runtime image for running the application:
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS run-project

# Change directory to the folder which will contain the built applications files:
WORKDIR /Output

# Copy the built files from the 'build-project' image step into the 'run-project' step:
COPY --from=build-project /Output /Output

# Start the web application:
ENTRYPOINT ["dotnet", "Phasmophobia Wiki.dll"]
