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

## Utilizando Kubernetes
1. Aplicando manifestos
```
kubectl apply -f .\.k8s\namespaces\ -R
kubectl apply -f .\.k8s\deployments\ -R -n finance
kubectl apply -f .\.k8s\services\ -R -n finance
```
