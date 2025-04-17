# Desafio técnico de desenvolvedor senior .NET para empresa Eclipseworks
"Este código é um desafio técnico realizado para a Eclipseworks, referente à vaga de Desenvolvedor .NET Sênior.
[Eclipseworks](https://eclipseworks.com.br/)
## Descrição técnica
- C#
- Arquitetura limpa (Clean Architecture)
- Dot Net 9
- Web Api
- ORM - Entity Framework
- SQL Server
- AutoMapper
- JWT
## Observações sobre projeto
A aplicação tem como objetivo gerenciar projetos com controle de tarefas.

Todas as nomenclaturas de variáveis e métodos seguem o padrão em inglês.


## Detalhamaneto das camadas

### Eclipseworks.API
– Interface responsável por expor as chamadas dos endpoints.

### Eclipseworks.Application

### Eclipseworks.Domain

### Eclipseworks.Infra.Data

### Eclipseworks.Infra.Encryption
- Camada responsável por gerar a criptografia dos dados.

### Eclipseworks.Infra.IoC
A camada é usada para registrar e gerenciar as dependências entre os componentes da aplicação, como repositórios, serviços, validadores, handlers, entre outros. 
Ela centraliza a configuração da injeção de dependência, facilitando a manutenção e promovendo o baixo acoplamento entre as camadas.

### Eclipseworks.Infra.Jwt
- Camada responsável pela geração de JSON Web Tokens.