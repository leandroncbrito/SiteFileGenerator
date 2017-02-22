# SiteFileGenerator

##Templates

Arquivos de templates possuem o modelo de arquivo a ser gerado, utilizando-se dos parâmetros #namespace#, #pagename# e #pagenameptbr

## Parâmetros

<b>[string]$namespace</b><br>
Namespace a aplicação escrito em capital case. Ex: MyProject

<b>[string]$pagename</b><br>
Nome da página a ser criada em capital case. Ex: MyPage

<b>[string]$pagenameptbr</b><br>
Nome da página a ser criada em português. Ex: minha página

## Execução

.\SiteFileGenerator.ps1

## Saída

Os arquivos serão criados dentro da pasta output seguindo estrutura de pastas mvc
