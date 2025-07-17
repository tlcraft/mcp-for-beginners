<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T13:35:42+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "cs"
}
-->
# Kompletní příklady MCP klientů

Tento adresář obsahuje kompletní, funkční příklady MCP klientů v různých programovacích jazycích. Každý klient demonstruje plnou funkcionalitu popsanou v hlavním tutoriálu README.md.

## Dostupní klienti

### 1. Java klient (`client_example_java.java`)
- **Transport**: SSE (Server-Sent Events) přes HTTP
- **Cílový server**: `http://localhost:8080`
- **Funkce**: 
  - Navázání spojení a ping
  - Výpis nástrojů
  - Operace kalkulačky (sčítání, odčítání, násobení, dělení, pomoc)
  - Zpracování chyb a extrakce výsledků

**Pro spuštění:**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. C# klient (`client_example_csharp.cs`)
- **Transport**: Stdio (Standardní vstup/výstup)
- **Cílový server**: Lokální .NET MCP server přes dotnet run
- **Funkce**:
  - Automatické spuštění serveru přes stdio transport
  - Výpis nástrojů a zdrojů
  - Operace kalkulačky
  - Parsování výsledků ve formátu JSON
  - Komplexní zpracování chyb

**Pro spuštění:**
```bash
dotnet run
```

### 3. TypeScript klient (`client_example_typescript.ts`)
- **Transport**: Stdio (Standardní vstup/výstup)
- **Cílový server**: Lokální Node.js MCP server
- **Funkce**:
  - Plná podpora MCP protokolu
  - Operace s nástroji, zdroji a promptami
  - Operace kalkulačky
  - Čtení zdrojů a spouštění promptů
  - Robustní zpracování chyb

**Pro spuštění:**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Python klient (`client_example_python.py`)
- **Transport**: Stdio (Standardní vstup/výstup)  
- **Cílový server**: Lokální Python MCP server
- **Funkce**:
  - Použití async/await pro operace
  - Objevování nástrojů a zdrojů
  - Testování operací kalkulačky
  - Čtení obsahu zdrojů
  - Organizace založená na třídách

**Pro spuštění:**
```bash
python client_example_python.py
```

## Společné vlastnosti všech klientů

Každá implementace klienta demonstruje:

1. **Správa spojení**
   - Navázání spojení s MCP serverem
   - Zpracování chyb při připojení
   - Správné ukončení a správa zdrojů

2. **Objevování serveru**
   - Výpis dostupných nástrojů
   - Výpis dostupných zdrojů (kde je podporováno)
   - Výpis dostupných promptů (kde je podporováno)

3. **Volání nástrojů**
   - Základní operace kalkulačky (sčítání, odčítání, násobení, dělení)
   - Příkaz help pro informace o serveru
   - Správné předávání argumentů a zpracování výsledků

4. **Zpracování chyb**
   - Chyby připojení
   - Chyby při vykonávání nástrojů
   - Elegantní selhání a zpětná vazba uživateli

5. **Zpracování výsledků**
   - Extrakce textového obsahu z odpovědí
   - Formátování výstupu pro lepší čitelnost
   - Zpracování různých formátů odpovědí

## Požadavky

Před spuštěním těchto klientů se ujistěte, že máte:

1. **Spuštěný odpovídající MCP server** (z `../01-first-server/`)
2. **Nainstalované potřebné závislosti** pro váš vybraný jazyk
3. **Správné síťové připojení** (pro HTTP transporty)

## Hlavní rozdíly mezi implementacemi

| Jazyk      | Transport | Spuštění serveru | Asynchronní model | Klíčové knihovny |
|------------|-----------|------------------|-------------------|------------------|
| Java       | SSE/HTTP  | Externí          | Synchronní        | WebFlux, MCP SDK |
| C#         | Stdio     | Automatické      | Async/Await       | .NET MCP SDK     |
| TypeScript | Stdio     | Automatické      | Async/Await       | Node MCP SDK     |
| Python     | Stdio     | Automatické      | AsyncIO           | Python MCP SDK   |

## Další kroky

Po prozkoumání těchto příkladů klientů:

1. **Upravte klienty** a přidejte nové funkce nebo operace
2. **Vytvořte si vlastní server** a otestujte ho s těmito klienty
3. **Experimentujte s různými transporty** (SSE vs. Stdio)
4. **Postavte složitější aplikaci**, která integruje MCP funkcionalitu

## Řešení problémů

### Běžné problémy

1. **Připojení odmítnuto**: Ujistěte se, že MCP server běží na očekávaném portu/cestě
2. **Modul nenalezen**: Nainstalujte požadovaný MCP SDK pro váš jazyk
3. **Přístup odepřen**: Zkontrolujte oprávnění souborů pro stdio transport
4. **Nástroj nenalezen**: Ověřte, že server implementuje očekávané nástroje

### Tipy pro ladění

1. **Zapněte podrobné logování** ve vašem MCP SDK
2. **Zkontrolujte logy serveru** pro chybové zprávy
3. **Ověřte názvy a podpisy nástrojů**, aby odpovídaly mezi klientem a serverem
4. **Nejprve otestujte s MCP Inspector** pro ověření funkčnosti serveru

## Související dokumentace

- [Hlavní tutoriál klienta](./README.md)
- [Příklady MCP serverů](../../../../03-GettingStarted/01-first-server)
- [MCP s integrací LLM](../../../../03-GettingStarted/03-llm-client)
- [Oficiální dokumentace MCP](https://modelcontextprotocol.io/)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.