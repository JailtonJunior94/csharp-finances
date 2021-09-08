## Criando o banco de dados

1. Script
```
CREATE DATABASE [FinanceDB]
GO
  USE [FinanceDB]
GO
SET
  ANSI_NULLS ON
GO
SET
  QUOTED_IDENTIFIER ON
GO
  CREATE TABLE [dbo].[Finance](
    [ID] [uniqueidentifier] NOT NULL,
    [Title] [varchar](150) NOT NULL,
    [Value] [decimal](18, 2) NOT NULL,
    [Type] [varchar](30) NOT NULL,
    [CreatedAt] [datetime2](7) NOT NULL
  ) ON [PRIMARY]
GO   
```

## Microsoft Azure
1. Autenticação no azure (Precisamos instalar o ([Azure CLI](https://docs.microsoft.com/pt-br/cli/azure/install-azure-cli))
```
az login
```
2. Obtendo credenciais do cluster AKS 
```
az aks get-credentials --resource-group $RESOURCE_GROUP --name $NAME
```

## Utilizando Kubernetes
1. Criando Secret ACR
```
kubectl create secret docker-registry regcred --docker-server=<your-registry-server> --docker-username=<your-name> --docker-password=<your-pword>
```

2. Aplicando manifestos
```
kubectl apply -f .\.k8s\namespaces\ -R
kubectl apply -f .\.k8s\deployments\ -R -n finance
kubectl apply -f .\.k8s\services\ -R -n finance
```

3. Habilitando ingress-controller
```
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.0.0/deploy/static/provider/cloud/deploy.yaml
```

## Configurando Azure DevOps (Release)
1. Obtendo credenciais cluster kubernetes 
```
kubectl config view --raw
```