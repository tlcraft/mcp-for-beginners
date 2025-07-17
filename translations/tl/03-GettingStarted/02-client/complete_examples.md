<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T09:13:05+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "tl"
}
-->
# Kumpletong Mga Halimbawa ng MCP Client

Ang direktoryong ito ay naglalaman ng kumpleto at gumaganang mga halimbawa ng MCP clients sa iba't ibang programming languages. Bawat client ay nagpapakita ng buong functionality na ipinaliwanag sa pangunahing tutorial na README.md.

## Mga Available na Client

### 1. Java Client (`client_example_java.java`)
- **Transport**: SSE (Server-Sent Events) sa ibabaw ng HTTP
- **Target na Server**: `http://localhost:8080`
- **Mga Tampok**: 
  - Pagkonekta at ping
  - Paglista ng mga tool
  - Mga operasyon ng calculator (add, subtract, multiply, divide, help)
  - Pag-handle ng error at pagkuha ng resulta

**Para patakbuhin:**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. C# Client (`client_example_csharp.cs`)
- **Transport**: Stdio (Standard Input/Output)
- **Target na Server**: Lokal na .NET MCP server gamit ang dotnet run
- **Mga Tampok**:
  - Awtomatikong pagsisimula ng server gamit ang stdio transport
  - Paglista ng mga tool at resource
  - Mga operasyon ng calculator
  - Pag-parse ng JSON na resulta
  - Komprehensibong pag-handle ng error

**Para patakbuhin:**
```bash
dotnet run
```

### 3. TypeScript Client (`client_example_typescript.ts`)
- **Transport**: Stdio (Standard Input/Output)
- **Target na Server**: Lokal na Node.js MCP server
- **Mga Tampok**:
  - Buong suporta sa MCP protocol
  - Mga operasyon sa tool, resource, at prompt
  - Mga operasyon ng calculator
  - Pagbasa ng resource at pagpapatakbo ng prompt
  - Matibay na pag-handle ng error

**Para patakbuhin:**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Python Client (`client_example_python.py`)
- **Transport**: Stdio (Standard Input/Output)  
- **Target na Server**: Lokal na Python MCP server
- **Mga Tampok**:
  - Async/await na pattern para sa mga operasyon
  - Pagtuklas ng tool at resource
  - Pagsubok ng mga operasyon ng calculator
  - Pagbasa ng nilalaman ng resource
  - Organisasyon gamit ang klase

**Para patakbuhin:**
```bash
python client_example_python.py
```

## Mga Karaniwang Tampok sa Lahat ng Client

Bawat implementasyon ng client ay nagpapakita ng:

1. **Pamamahala ng Koneksyon**
   - Pagkonekta sa MCP server
   - Pag-handle ng mga error sa koneksyon
   - Maayos na paglilinis at pamamahala ng mga resource

2. **Pagtuklas ng Server**
   - Paglista ng mga available na tool
   - Paglista ng mga available na resource (kung sinusuportahan)
   - Paglista ng mga available na prompt (kung sinusuportahan)

3. **Pagtawag sa Tool**
   - Pangunahing mga operasyon ng calculator (add, subtract, multiply, divide)
   - Help command para sa impormasyon ng server
   - Maayos na pagpapasa ng argumento at pag-handle ng resulta

4. **Pag-handle ng Error**
   - Mga error sa koneksyon
   - Mga error sa pagpapatakbo ng tool
   - Maayos na pagkabigo at feedback sa user

5. **Pagproseso ng Resulta**
   - Pagkuha ng text content mula sa mga tugon
   - Pag-format ng output para madaling basahin
   - Pag-handle ng iba't ibang format ng tugon

## Mga Kinakailangan

Bago patakbuhin ang mga client na ito, siguraduhing:

1. **Naka-run ang kaukulang MCP server** (mula sa `../01-first-server/`)
2. **Naka-install ang mga kinakailangang dependencies** para sa napiling wika
3. **Maayos ang koneksyon sa network** (para sa HTTP-based na transport)

## Pangunahing Pagkakaiba ng mga Implementasyon

| Wika       | Transport | Pagsisimula ng Server | Async Model | Pangunahing Library |
|------------|-----------|----------------------|-------------|---------------------|
| Java       | SSE/HTTP  | Panlabas             | Sync        | WebFlux, MCP SDK    |
| C#         | Stdio     | Awtomatik            | Async/Await | .NET MCP SDK        |
| TypeScript | Stdio     | Awtomatik            | Async/Await | Node MCP SDK        |
| Python     | Stdio     | Awtomatik            | AsyncIO     | Python MCP SDK      |

## Mga Susunod na Hakbang

Pagkatapos suriin ang mga halimbawa ng client na ito:

1. **Baguhin ang mga client** para magdagdag ng bagong mga tampok o operasyon
2. **Gumawa ng sarili mong server** at subukan ito gamit ang mga client na ito
3. **Subukan ang iba't ibang transport** (SSE vs. Stdio)
4. **Bumuo ng mas kumplikadong aplikasyon** na nag-iintegrate ng MCP functionality

## Pag-aayos ng Problema

### Mga Karaniwang Isyu

1. **Connection refused**: Siguraduhing tumatakbo ang MCP server sa inaasahang port/path
2. **Module not found**: I-install ang kinakailangang MCP SDK para sa iyong wika
3. **Permission denied**: Suriin ang mga permiso ng file para sa stdio transport
4. **Tool not found**: Tiyaking naipapatupad ng server ang inaasahang mga tool

### Mga Tip sa Pag-debug

1. **I-enable ang verbose logging** sa iyong MCP SDK
2. **Suriin ang mga log ng server** para sa mga error na mensahe
3. **Tiyaking tugma ang mga pangalan at signature ng tool** sa pagitan ng client at server
4. **Subukan muna gamit ang MCP Inspector** para i-validate ang functionality ng server

## Kaugnay na Dokumentasyon

- [Main Client Tutorial](./README.md)
- [MCP Server Examples](../../../../03-GettingStarted/01-first-server)
- [MCP with LLM Integration](../../../../03-GettingStarted/03-llm-client)
- [Official MCP Documentation](https://modelcontextprotocol.io/)

**Paalala**:  
Ang dokumentong ito ay isinalin gamit ang AI translation service na [Co-op Translator](https://github.com/Azure/co-op-translator). Bagamat nagsusumikap kami para sa katumpakan, pakatandaan na ang mga awtomatikong pagsasalin ay maaaring maglaman ng mga pagkakamali o di-tumpak na impormasyon. Ang orihinal na dokumento sa orihinal nitong wika ang dapat ituring na pangunahing sanggunian. Para sa mahahalagang impormasyon, inirerekomenda ang propesyonal na pagsasalin ng tao. Hindi kami mananagot sa anumang hindi pagkakaunawaan o maling interpretasyon na maaaring magmula sa paggamit ng pagsasaling ito.