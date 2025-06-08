
# 💬 Chat Moderno - SignalR

Um sistema de chat em tempo real desenvolvido com ASP.NET Core 7.0 e SignalR, oferecendo conversas públicas e privadas com interface moderna e responsiva.

## 🚀 Funcionalidades

- **Chat Público**: Conversa geral onde todos os usuários podem participar
- **Chat Privado**: Mensagens diretas entre usuários específicos
- **Conexão em Tempo Real**: Utilizando SignalR para comunicação instantânea
- **Interface Moderna**: Design responsivo com Bootstrap 5 e ícones Remix
- **Notificações**: Sistema de notificações para entrada/saída de usuários
- **Lista de Usuários Online**: Visualização em tempo real dos usuários conectados
- **Busca de Usuários**: Funcionalidade para encontrar usuários específicos
- **Indicadores Visuais**: Diferenciação clara entre chats públicos e privados

## 🛠️ Tecnologias Utilizadas

- **Backend**: ASP.NET Core 7.0
- **Real-time**: SignalR
- **Frontend**: HTML5, CSS3, JavaScript (Vanilla)
- **Styling**: Bootstrap 5.3.0
- **Ícones**: Remix Icons, BoxIcons
- **Package Manager**: NuGet

## 📋 Dependências

```xml
<PackageReference Include="Microsoft.AspNetCore.SignalR" Version="1.1.0" />
<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="7.0.0" />
<PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="7.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="7.0.0" />
```

## 🏃‍♂️ Como Executar

### No Replit (Recomendado)

1. **Fork este Repl** ou clone o projeto
2. **Clique no botão "Run"** para iniciar a aplicação
3. **Acesse a aplicação** através da URL fornecida pelo Replit
4. **Digite seu nome** na tela de login para entrar no chat

### Localmente

1. **Clone o repositório**
```bash
git clone [url-do-repositorio]
cd chat-moderno-signalr
```

2. **Restaurar dependências**
```bash
dotnet restore
```

3. **Executar a aplicação**
```bash
dotnet run
```

4. **Acessar no navegador**
```
http://localhost:5000
```

## 🎯 Como Usar

### Entrando no Chat
1. Acesse a aplicação
2. Digite seu nome (mínimo 2 caracteres)
3. Clique em "Entrar no Chat"

### Chat Público
- Por padrão, você estará no chat público
- Todas as mensagens são visíveis para todos os usuários conectados
- Digite sua mensagem e pressione Enter ou clique no botão enviar

### Chat Privado
1. Clique em um usuário na lista de "Usuários Online"
2. O chat privado será aberto automaticamente
3. Suas mensagens serão enviadas apenas para o usuário selecionado
4. Para voltar ao chat público, clique em "Chat Público"

### Funcionalidades Adicionais
- **Buscar Usuários**: Use a barra de pesquisa para encontrar usuários específicos
- **Emoji**: Clique no ícone de emoji para adicionar 😊 às suas mensagens
- **Notificações**: Receba notificações quando usuários entram ou saem do chat

## 🏗️ Estrutura do Projeto

```
📁 Projeto/
├── 📄 main.cs                 # Arquivo principal com configuração e Hub SignalR
├── 📄 main.csproj            # Configurações do projeto .NET
├── 📁 Views/
│   ├── 📁 Home/
│   │   └── 📄 Index.cshtml   # Interface principal do chat
│   └── 📁 Shared/
│       └── 📄 _Layout.cshtml # Layout base (não utilizado)
└── 📄 README.md              # Este arquivo
```

## 🔧 Configuração

A aplicação está configurada para rodar na porta 5000:

```csharp
app.Run("http://0.0.0.0:5000");
```

O hub SignalR está mapeado para `/chatHub`:

```csharp
app.MapHub<ChatHub>("/chatHub");
```

## 📱 Recursos da Interface

### Layout Responsivo
- **Desktop**: Layout com sidebar para usuários e área principal de chat
- **Mobile**: Interface adaptada para telas menores
- **Tablets**: Experiência otimizada para dispositivos médios

### Temas e Cores
- **Chat Público**: Indicador verde com ícone de grupo
- **Chat Privado**: Indicador azul com ícone de usuário
- **Mensagens Enviadas**: Balões azuis à direita
- **Mensagens Recebidas**: Balões cinzas à esquerda

## 🚀 Deploy no Replit

Este projeto está otimizado para deploy no Replit:

1. O arquivo `.replit` já está configurado
2. A porta 5000 está mapeada corretamente
3. As dependências são instaladas automaticamente
4. O projeto é executado com `dotnet run`

## 🤝 Contribuindo

1. Fork o projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.

## 👨‍💻 Autor

Desenvolvido com ❤️ usando ASP.NET Core e SignalR

---

### 🔗 Links Úteis

- [Documentação SignalR](https://docs.microsoft.com/aspnet/core/signalr)
- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [Bootstrap Documentation](https://getbootstrap.com/docs)
- [Replit Documentation](https://docs.replit.com)
