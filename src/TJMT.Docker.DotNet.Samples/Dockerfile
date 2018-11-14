#build stage
FROM tjmt/dotnetcore:builder as build

ENTRYPOINT dotnet src/TJMT.Docker.DotNet.Samples/bin/${CONFIGURATION}/netcoreapp2.1/TJMT.Docker.DotNet.Samples.dll

#publish stage
FROM build as publish
RUN dotnet publish src/TJMT.Docker.DotNet.Samples/TJMT.Docker.DotNet.Samples.csproj -c ${CONFIGURATION} -o /app


#final stage
FROM tjmt/dotnetcore:runtime as final
COPY --from=publish /app /app
WORKDIR /app
ENTRYPOINT dotnet TJMT.Docker.DotNet.Samples.dll