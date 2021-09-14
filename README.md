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

## AWS 
1. Obtendo na aws (Precisamos instalar o ([AWS CLI](https://aws.amazon.com/pt/cli/)))
```
aws sts get-caller-identity
```
2. Obtendo credenciais do cluster EKS
```
aws eks --region <REGION> update-kubeconfig --name <NOME_CLUSTER>
```

## Utilizando Kubernetes
1. Criando Secret ACR
```
kubectl create secret docker-registry regcred --docker-server=<your-registry-server> --docker-username=<your-name> --docker-password=<your-pword> \
--namespace=finance
```
2. Criando Secret ECR
```
kubectl create secret docker-registry regcred --docker-server=<your-accountid>.dkr.ecr.<region>.amazonaws.com --docker-username=AWS --docker-password=$(aws ecr get-login-password) --namespace=finance
```

3. Aplicando manifestos
```
kubectl apply -f .\.k8s\namespaces\ -R
kubectl apply -f .\.k8s\deployments\ -R -n finance
kubectl apply -f .\.k8s\services\ -R -n finance
```

4. Alterar entre contextos (clusters)
```
kubectl config get-contexts
kubectl config use-context <context>
```

## Configurando Azure DevOps (Release)
1. Obtendo credenciais cluster kubernetes 
```
kubectl config view --raw
```