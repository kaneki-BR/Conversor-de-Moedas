# 💱 Conversor de Moedas e Monitor de Câmbio

> **Desafio Técnico** — Processo Seletivo para Estágio em Desenvolvimento de Sistemas | **Grupo Revemar**

Aplicação utilitária desenvolvida em **.NET 8 (Console)** focada nos fundamentos de conversão de tipos numéricos, formatação de dados regionais (moedas/culturas) e estruturas de controle condicional.

---

## 🎯 Objetivo do Desafio

Desenvolver um sistema em C# que permita ao usuário selecionar uma moeda base (**Real**, **Dólar** ou **Euro**) e um valor de entrada para calcular e exibir de forma formatada os equivalentes nas outras duas moedas, com base em taxas fixas de conversão.

### 📌 Pilares Avaliados
* **Conversão de Tipos:** Manipulação segura do tipo `decimal` para dados financeiros e parsing de dados do usuário via `decimal.TryParse`.
* **Formatação de Strings:** Exibição monetária regionalizada utilizando o especificador de formato `"C"` e `CultureInfo` (`pt-BR`, `en-US`, `de-DE`).
* **Estruturas Condicionais:** Fluxos de validação e tomada de decisão através de declarações `switch` e estruturas `if/else`.

---

## 🛠️ Tecnologias e Ferramentas

* **Linguagem:** C# (.NET 8.0)
* **Tipo de Aplicação:** Console Application (CLI)
* **Namespace / Biblioteca Padrão:** `System.Globalization` para manipulação de culturas e formatação regional.

---

## 📁 Estrutura do Projeto

```text
Revemar.ConversorMoedas/
├── Revemar.ConversorMoedas.sln
├── .gitignore
├── README.md
└── Revemar.ConversorMoedas.Console/
    ├── Program.cs
    └── Revemar.ConversorMoedas.Console.csproj
```

---

## ⚙️ Como Executar a Aplicação

### Pré-requisitos
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) ou superior instalado.

### Passo a Passo

1. **Clonar o repositório:**
   ```bash
   git clone https://github.com/SEU_USUARIO/Conversor-de-Moedas.git
   cd Conversor-de-Moedas
   ```

2. **Restaurar e compilar o projeto:**
   ```bash
   dotnet build
   ```

3. **Executar a aplicação:**
   ```bash
   dotnet run --project Revemar.ConversorMoedas.Console
   ```

---

## 💡 Recursos e Boas Práticas Implementadas

- **Precisão Financeira com `decimal`:** Evita os erros de arredondamento inerentes ao ponto flutuante de `double`/`float`.
- **Tratamento de Exceções e Entradas:** O programa previne erros de execução (*crashes*) ao validar inputs numéricos e seleções inválidas.
- **Suporte Duplo a Separadores Decimais:** Aceita tanto vírgula (`10,50`) quanto ponto (`10.50`) na entrada de dados, adaptando-se às configurações locais do SO.
- **Renderização UTF-8:** Configurado para exibir símbolos monetários (`R$`, `$`, `€`) de forma correta no terminal.
- **Moeda Pivô:** Utiliza o Real (BRL) como base central para realizar a conversão cruzada entre Dólar (USD) e Euro (EUR).

---

## 🖥️ Exemplo de Execução

```text
=== MONITOR E CONVERSOR DE CÂMBIO ===
1 - Real (BRL)
2 - Dólar (USD)
3 - Euro (EUR)

Escolha a moeda de origem (1, 2 ou 3): 2
Digite o valor a ser convertido: 100

----------------------------------
Valor informado: $100.00
----------------------------------
Em Real (BRL): R$ 514,00
Em Euro (EUR): 91,79 €
----------------------------------
```

---

## 👨‍💻 Autor

Desenvolvido por **Herbert Paz Espindola**  
