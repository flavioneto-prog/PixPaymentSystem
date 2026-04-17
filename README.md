# 💳 PixPaymentSystem

Sistema de processamento de pagamentos Pix desenvolvido com foco em **arquitetura limpa, design patterns e observabilidade**.

Este projeto simula um fluxo real de pagamentos, aplicando conceitos utilizados em sistemas de **fintechs e bancos digitais**.

---

## 🚀 🚀 Tecnologias utilizadas

* **.NET (C#)**
* **ASP.NET Core (API REST)**
* **Serilog (logging estruturado)**
* **Elasticsearch + Kibana (observabilidade)**
* **Docker / Docker Compose**
* **xUnit + FluentAssertions (testes)**

---

## 🧠 🧱 Arquitetura

O projeto foi estruturado seguindo princípios de **Clean Architecture**, separando responsabilidades em camadas:

```text
src/
├── Application
│   ├── Factories
│   ├── Services
│   ├── Interfaces
│   └── DTOs
│
├── Domain
│   ├── Enums
│   ├── Interfaces
│   └── Pix
│
└── API

tests/
├── Unit
└── Integration
```

---

## 🧩 🔥 Design Patterns aplicados

* ✅ Factory Method
* ✅ Strategy
* ✅ Idempotency

---

## 💳 ⚙️ Funcionalidades

* ✔ Processamento de Pix:

  * Imediato
  * Agendado
  * Recorrente

* ✔ API REST:

  * `POST /pix`
  * `GET /pix/{id}`

* ✔ Idempotência (evita duplicidade de transações)

* ✔ Logging estruturado com Serilog

* ✔ CorrelationId para rastreamento de requisições

* ✔ Observabilidade com Elasticsearch + Kibana

---

## 📊 📈 Observabilidade

Os logs são enviados para o Elasticsearch e visualizados no Kibana, permitindo:

* 📊 Volume de Pix por período
* 💳 Pix por tipo
* ❌ Monitoramento de erros
* 🔎 Rastreamento via CorrelationId

---

## 🧪 🧪 Testes

O projeto possui:

* ✔ Testes unitários
* ✔ Testes de integração

Utilizando:

* xUnit
* FluentAssertions

---

## 🐳 🐳 Executando com Docker

```bash
docker-compose up -d --build
```

### 🔗 Acessos:

| Serviço       | URL                   |
| ------------- | --------------------- |
| API           | http://localhost:8080 |
| Elasticsearch | http://localhost:9200 |
| Kibana        | http://localhost:5601 |

---

## ▶️ ▶️ Executando localmente

```bash
dotnet run --project PixPaymentSystem.API
```

---

## 📬 📬 Exemplo de requisição

### POST /pix

```json
{
  "tipo": "Agendado",
  "valor": 150,
  "dataAgendamento": "2026-05-01T10:00:00"
}
```

### Header (Idempotência)

```text
Idempotency-Key: abc123
```

---

## 🔍 🔍 Logs estruturados (exemplo)

```json
{
  "message": "Pix processado",
  "Tipo": "Agendado",
  "Valor": 150,
  "CorrelationId": "abc-123"
}
```

---

## 🧠 🎯 Objetivo do projeto

Este projeto foi desenvolvido com foco em:

* Arquitetura limpa
* Boas práticas de engenharia
* Simulação de sistemas reais de pagamento
* Observabilidade e rastreabilidade

---

## 🚀 🔥 Próximos passos

* [ ] Integração com banco de dados
* [ ] Idempotência com Redis
* [ ] OpenTelemetry (tracing distribuído)
* [ ] Sistema antifraude (Chain of Responsibility)
* [ ] Autenticação e autorização

---

## 👩‍💻 Autor

Desenvolvido por **Flavio Neto**

---
