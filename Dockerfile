FROM dotnetcore:builder as Build

#Argumentos
ARG CONFIGURATION="Release"

#Criando variaveis de ambientes com os argumentos, necessário para rodar o CI (entrypoint)
ENV CONFIGURATION=$CONFIGURATION

#Criando estrutura final de pasta
RUN mkdir /app \ 
&& mkdir /packages \ 
&& mkdir /TestResults

WORKDIR /src
COPY . .
RUN dotnet restore TJMT.Docker.DotNet.Samples.sln -v m
RUN dotnet build TJMT.Docker.DotNet.Samples.sln -c ${CONFIGURATION} --no-restore -v m
RUN dotnet publish src/TJMT.Docker.DotNet.Samples/TJMT.Docker.DotNet.Samples.csproj -c ${CONFIGURATION} -o /app                  

FROM dotnetcore:runtime as final
COPY --from=Build /app /app
COPY --from=Build /TestResults /TestResults
COPY --from=Build /packages /packages

WORKDIR /app
ENTRYPOINT dotnet TJMT.Docker.DotNet.Samples.dll