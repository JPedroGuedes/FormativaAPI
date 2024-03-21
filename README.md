# FormativaAPI - Criação de uma API com validação JWT no C#

O projeto é para uma criação de uma API com C# onde eu preciso criar um crud de uma api contendo as seguintes entidade e atributos: 

LivroModel: Id, Titulo, Genero, AnoPublicacao(int),ISBN, Sinopse;  
AutorModel: Id, Nome, Nacionalidade, DataNascimento(Date Only);   
EditoraModel: Id, Nome, Localizacao, AnoFundacao(int), ICollection<LivroModel>;  
UsuarioModel: Id, Email, Senha;  

EmprestimoModel: Id, DataEmprestimo, DataDevolucao, Status, LivroId,UsuarioId;  
ReservaModel: Id, DataReserva, Status, LivroId, UsuarioId;  
AvaliacaoModel: Id, Pontuacao, Comentario, DataAvaliacao, LivroId, UsuarioId;  


## 🚀 Começando

Para o projeto funcionar além do código precisa da criação do banco de dados, para isso na Microsoft SQL Server Management Studio crie uma consulta e execute os dois códigos a seguir:
```
create database dbFormativaAPI
use database dbFormativaAPI
```
após isso no código dentro do Visual Studio você precisa entrar na aba Ferramentas > Gerenciador de Pacotes do Nuget > Console do Gerenciador de Pacotes, após abrir a aba você digitará o código: 
```
Update-DataBase -Context SistemaBibliotecaDBContex
```

## 📌 Versão

Eu usei [.Net](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0) para controle de versão.

Obrigado até mais 😊
