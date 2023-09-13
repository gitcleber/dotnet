# Montando um Ambiente de Desenvolvimento .Net em container Docker
## WSL2 + Docker + Container C# .NET

## Sumário

1. [Instalação do WSL 2](#instalação-do-wsl-2)
2. [Instalando o DOCKER](#2-instalando-o-docker)
3. [Criando um container .NET com OH-my-ZSH](#3-criando-um-container-net-com-oh-my-zsh)
4. [Docker File & Docker Compose](#4-docker-file--docker-compose)







## Instalação do WSL 2

Execute o comando:

```
wsl --install
```
Este comando irá instalar o `Ubuntu` como o Linux padrão. 


Crie um arquivo chamado `.wslconfig` na raiz da sua pasta de usuário `(C:\Users\<seu_usuario>)` e defina estas configurações... ou sal a gosto:

```txt
[wsl2]
memory=8GB
processors=4
swap=2GB
```

# 2. Instalando o DOCKER
## 2.1  os repositórios
Seguir a instalação direto no site do Docker clicando aqui [Instalação do Docker](https://docs.docker.com/engine/install/ubuntu/)

# 3. Criando um container .NET com OH-my-ZSH

```bash
docker run -dit --name restapinet6 -p 5000:5000 -p 5001:5001 -v $(pwd):/app/ mcr.microsoft.com/dotnet/sdk:6.0 /bin/bash -c "apt-get update && apt-get install -y zsh && wget https://raw.githubusercontent.com/ohmyzsh/ohmyzsh/master/tools/install.sh && echo | sh install.sh && chsh -s $(which zsh) | echo && wget https://packages.microsoft.com/config/debian/11/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && dpkg -i packages-microsoft-prod.deb && rm packages-microsoft-prod.deb && apt-get update && apt-get install -y dotnet-sdk-5.0 && useradd -r -u 1000 -d /app dotnet && zsh"
```

Caso você deseje usar esse container, é necessário que gere uma nova imagem para aí sim, criar e usar o container. Tudo isso baseado no código docker acima. 
Após a execução do comando acima, execute o comando de commit do docker passando o Id do container que foi criado e o nome da imagem da sua escolha. 

Verificando o id do container

```bash
docker ps -a
```
Criando a nova imagem (remova os caracteres <>)
```bash
docker commit <id do container> <novo nome da imagem>
```

Para verificar as imagem que você criou
```bash
docker images
```

Rodando um novo container
```bash
docker run -dit --name <novo nome do container> <nome da imagem que você criou no passo anterior> zsh
```

Agora é possível entrar no container pelo comando exec.

```bash
docker exec -it <nome do container> zsh
```
# 4. Docker File & Docker Compose 
Aqui começa a parte mais interessante, pois trabalhar com o docker apenas na linha de comando pode se tornar algo bem cansativo com o passar do tempo. O uso do docker compose junto com o Dockerfile irá trazer uma grande liberdade e clareza na criação de imagens e containers. 
Para que possamos começar a usar os dois, crie um arquivo com o seguinte nome "docker-compose.yml" e outro arquivo com o nome "Dockerfile", você pode acompanhar todo o código clicando [Dockerfile](https://github.com/allysonreeis/dotnet-wsl-dev/blob/main/Dockerfile) e no [Docker Compose](https://github.com/allysonreeis/dotnet-wsl-dev/blob/main/docker-compose.yml).


# 4. Docker File & Docker Compose 
Aqui começa a parte mais interessante, pois trabalhar com o docker apenas na linha de comando pode se tornar algo bem cansativo com o passar do tempo. O uso do docker compose junto com o Dockerfile irá trazer uma grande liberdade e clareza na criação de imagens e containers. 
Para que possamos começar a usar os dois, crie um arquivo com o seguinte nome "docker-compose.yml" e outro arquivo com o nome "Dockerfile", você pode acompanhar todo o código clicando [Dockerfile](https://github.com/allysonreeis/dotnet-wsl-dev/blob/main/Dockerfile) e no [Docker Compose](https://github.com/allysonreeis/dotnet-wsl-dev/blob/main/docker-compose.yml).

