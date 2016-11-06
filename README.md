# E-Saúde MT
Este aplicativo foi desenvolvido para o desafio Hackathon - MT onde visa relatar ao Governo do Estado os principais focos de Dengue e se a situação foi resolvida pelos agentes de saúde.

# Objetivo
O Objetivo do E-Saúde é criar uma conexão entre o cidadão e o Governo do Estado, sendo possível realizar denúncias de localidades com indícios de dengue, fazendo com que o agente de saúde mais próximo se dirija a localidade para realizar os procedimentos necessários de combate do mosquito.

# Licensa de uso
O codigo utilizado na aplicação é Código Proprietario da aplicação.

## Tabela de Conteúdo
 - [Tecnologias Utilizadas](#tecnologias-utilizadas)
 - [Estrutura do Aplicativo](#estrutura-do-aplicativo)

## Tecnologias Utilizadas
1. .Net C# Core
2. Angular.js
3. Cordova e Ionic
4. Javascript
5. Bower
6. Microsoft Azure
7. MSSQL Server

## Estrutura do Aplicativo

```
ESaudeApp/
├── config.xml                         * Arquivo de Configuração do Aplicativo
│
├── plugins/                           * Plugins de camera, geolocalização e dependencias do aplicativo
|
├── resources/						   * Recursos gráficos como logomarca e icones
|
├── scss/                              * Arquivo de Estilo do Ionic
|
├── www/                               * Folder that is copied over to platforms www directory
│   │   
│   ├── js/                            * Contém os Controllers e Factorys Angular.js necessárias para o funcionamento do aplicativo                
│   │
│   ├── css/                           * Arquivos Css
│   │
│   ├── img/                           * Incones e logomarca utilizadas no aplicativo
│   │
│   ├── lib/                           * Dependencias do Angular.js, Ionic, Bower e Cordova.
│   │
│   └── Arquivos*.html                 * Arquivos utilizados na construção das views
|
├── .editorconfig                      * Defines coding styles between editors
├── config.xml                         * Arquivo de configuração do Cordova
├── gulpfile.js                        * Contém as tarefas utilizadas pelo Gulp para compilar o projeto
├── ionic.project                      * Arquivo de configuração do Ionic
├── package.json                       * As dependencias Javascript
├── ESaude.sln						   * Arquivo da Solução utilizada no Visual Studio.
└── README.md                          * Este Arquivo
```
