# Simulador de Crédito – Backend & Frontend

Bem‑vindo(a) ao **Simulador de Crédito**! Este repositório contém **dois projetos** separados – um **Backend** em .NET 9 e um **Frontend** em React – que trabalham juntos para demonstrar o fluxo completo de simulação de taxa de crédito.

---

## 🚀 Tecnologias principais

| Camada       | Principais ferramentas                                                                          |
| ------------ | ----------------------------------------------------------------------------------------------- |
| **Backend**  | .NET 9 • ASP.NET Core Web API • EF Core 9 • SqlServer • Repository Pattern • Clean Architecture |
| **Testes**   | xUnit                                                                                           |
| **Frontend** | React • JavaScript • Axios • HTML • CSS                                                         |

> **Dica:** o projeto segue uma estrutura limpa, fácil de entender e expandir.

---

## 🛠️ Como executar

### 1. Clonar o repositório

```bash
 git clone https://github.com/Kalebe-Fernandes/Simulador-Kalebe.git
 cd simulador-credito
```

### 2. Backend (.NET 9)

```bash
 cd backend
 # restaurar pacotes
 dotnet restore
 # aplicar migrations e criar DB (SqlServer)
 dotnet ef database update
 # rodar a API
 dotnet run
```

> A API sobe por padrão em `https://localhost:44328` (Execute com IIS Express).

### 3. Frontend (React)

```bash
 cd ../frontend
 npm install
 npm start
```

> O app React estará em `http://localhost:3000`.

---

## 🔍 Detalhes implementados

### Backend

- **Clean Architecture** dividida em `Core` (entidades), `Application` (regras de negócio), `Infrastructure` (persistência) e `API` (exposição HTTP).
- **Repository Pattern** para abstrair o EF Core.
- **Endpoints REST**:
  - `GET /api/modalidades`
  - `GET /api/tipos-pessoa`
  - `GET /api/produtos?tipoPessoa=PF`
  - `GET /api/segmento?tipoPessoa=PF&renda=4500`
  - `GET /api/taxa?tipoPessoa=PF&modalidade=XYZ&produto=ABC&segmento=PF2`
- Banco **SqlServer** com migrations automáticas.
- **xUnit**: testes unitários da camada de Controllers.

### Frontend

- **React** com hooks (`useState`, `useEffect`).
- **Axios** para consumo da API.
- **Debounce** no campo de renda.
- **Mensagens de validação** sob cada campo.
- **Auto‑cálculo**: busca o segmento automaticamente e, se tudo válido, calcula a taxa.
- **Layout responsivo** em CSS puro.
- Projeto iniciado com `create-react-app` para facilitar a configuração e execução.

---

## 🙋‍♂️ Autor

**Kalebe Fernandes** – [LinkedIn](https://www.linkedin.com/in/kalebe-fernandes-012a371ba/)

Sinta‑se à vontade para conectar, trocar ideias ou abrir issues/PRs — sua colaboração é muito bem‑vinda!

---

## 📄 Licença

Este projeto está licenciado sob os termos da [MIT License](LICENSE).
