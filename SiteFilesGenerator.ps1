param (
	[Parameter(Mandatory=$True)]
	[string]$namespace,

    [Parameter(Mandatory=$True)]
    [string]$pagename,
	
	[Parameter(Mandatory=$True)]
	[string]$pagenameptbr
)

# Validação para nome da página obrigatório #
if (-not($pagename) -or(-not($pagenameptbr)) -or(-not($namespace))) {
    Throw "Preencha todos os parametros"
}

# Nome em minúsculo #
$pagenamelowercase = $pagename.ToLower();

# Função para criar diretórios #
function CreateDirectory
{	
	param([string]$directory)
	If(!(Test-Path $directory)) {	
		New-Item -ItemType Directory -Force -Path $directory 
	}
}

# Função para substituir conteúdo #
function ReplaceContent
{
	param([string]$content)	
	$content -replace '#namespace#', $namespace	`
			-replace '#pagename#', $pagename `
			-replace '#pagenamelowercase#', $pagenamelowercase `
			-replace '#pagenameptbr#', $pagenameptbr;
}


### Caminho dos arquivos de destino ###
$rootpath = ".\output";

# front-end #
$target = "$rootpath\wwwroot\app";
$targetroute = "$target\routes\$pagenamelowercase";
$targetcontroller = "$target\controllers\$pagenamelowercase";
$targetmodel = "$target\models\$pagenamelowercase";
$targethtml = "$target\templates\$pagenamelowercase";

# back-end #
$targetcontrollerback = "$rootpath\$namespace\Controllers";
$targetbusinessback = "$rootpath\$namespace.Business";
$targetibusinessback = "$rootpath\$namespace.IBusiness";
$targetrepositoryback = "$rootpath\$namespace.Repository.EntityFramework";
$targetirepositoryback = "$rootpath\$namespace.IRepository";

### Conteúdo dos arquivos de template ###
# front-end #
$routecontent = Get-Content -Path ".\templates\route.js" -Raw;
$controllercontent = Get-Content -Path ".\templates\controller.js" -Raw;
$modelcontent = Get-Content -Path ".\templates\model.js" -Raw;
$htmlcontent = Get-Content -Path ".\templates\list.html" -Raw;

# back-end #
$controllerbackcontent = Get-Content -Path ".\templates\Controller.cs" -Raw;
$businessbackcontent = Get-Content -Path ".\templates\Business.cs" -Raw;
$ibusinessbackcontent = Get-Content -Path ".\templates\IBusiness.cs" -Raw;
$repositorybackcontent = Get-Content -Path ".\templates\Repository.cs" -Raw;
$irepositorybackcontent = Get-Content -Path ".\templates\IRepository.cs" -Raw;

# Apaga pasta Output #
If (Test-Path $rootpath) {	
	Remove-Item -Recurse -Force $rootpath;
}

### Cria diretórios ###
# front-end #
CreateDirectory -directory $targetroute;
CreateDirectory -directory $targetcontroller;
CreateDirectory -directory $targetmodel;
CreateDirectory -directory $targethtml;

# back-end #
CreateDirectory -directory $targetcontrollerback;
CreateDirectory -directory $targetbusinessback;
CreateDirectory -directory $targetibusinessback;
CreateDirectory -directory $targetrepositoryback;
CreateDirectory -directory $targetirepositoryback;

### Troca o conteúdo parametrizado ###
# front-end #
ReplaceContent -content $routecontent | Set-Content "$targetroute\$pagenamelowercase.route.js";
ReplaceContent -content $controllercontent | Set-Content "$targetcontroller\$pagenamelowercase.controller.js";
ReplaceContent -content $modelcontent | Set-Content "$targetmodel\$pagenamelowercase.model.js";
ReplaceContent -content $htmlcontent | Set-Content "$targethtml\list.html";

# back-end #
ReplaceContent -content $controllerbackcontent | Set-Content ("$targetcontrollerback\$pagename"+"Controller.cs");
ReplaceContent -content $businessbackcontent | Set-Content ("$targetbusinessback\$pagename"+"Business.cs");
ReplaceContent -content $ibusinessbackcontent | Set-Content ("$targetibusinessback\$pagename"+"IBusiness.cs");
ReplaceContent -content $repositorybackcontent | Set-Content ("$targetrepositoryback\$pagename"+"Repository.cs");
ReplaceContent -content $irepositorybackcontent | Set-Content ("$targetirepositoryback\I$pagename"+"Repository.cs");