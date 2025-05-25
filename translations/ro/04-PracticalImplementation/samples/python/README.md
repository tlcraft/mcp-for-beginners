<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:33:19+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "ro"
}
-->
# Model Context Protocol (MCP) Implementare Python

Acest depozit conține o implementare Python a Model Context Protocol (MCP), demonstrând cum să creezi atât o aplicație server, cât și una client care comunică folosind standardul MCP.

## Prezentare generală

Implementarea MCP constă în două componente principale:

1. **MCP Server (`server.py`)** - Un server care oferă:
   - **Tools**: Funcții ce pot fi apelate de la distanță
   - **Resources**: Date ce pot fi obținute
   - **Prompts**: Șabloane pentru generarea prompturilor pentru modelele lingvistice

2. **MCP Client (`client.py`)** - O aplicație client care se conectează la server și utilizează funcționalitățile acestuia

## Funcționalități

Această implementare demonstrează câteva caracteristici cheie MCP:

### Tools
- `completion` - Generează completări de text de la modele AI (simulat)
- `add` - Calculator simplu care adună două numere

### Resources
- `models://` - Returnează informații despre modelele AI disponibile
- `greeting://{name}` - Returnează un mesaj personalizat pentru un nume dat

### Prompts
- `review_code` - Generează un prompt pentru revizuirea codului

## Instalare

Pentru a folosi această implementare MCP, instalează pachetele necesare:

```powershell
pip install mcp-server mcp-client
```

## Pornirea Serverului și Clientului

### Pornirea Serverului

Rulează serverul într-o fereastră de terminal:

```powershell
python server.py
```

Serverul poate fi rulat și în modul dezvoltare folosind MCP CLI:

```powershell
mcp dev server.py
```

Sau instalat în Claude Desktop (dacă este disponibil):

```powershell
mcp install server.py
```

### Pornirea Clientului

Rulează clientul într-o altă fereastră de terminal:

```powershell
python client.py
```

Aceasta va stabili conexiunea cu serverul și va demonstra toate funcționalitățile disponibile.

### Utilizarea Clientului

Clientul (`client.py`) demonstrează toate capabilitățile MCP:

```powershell
python client.py
```

Aceasta va conecta clientul la server și va folosi toate funcțiile, inclusiv tools, resources și prompts. Rezultatul va afișa:

1. Rezultatul calculatorului (5 + 7 = 12)
2. Răspunsul generatorului de completări la întrebarea „Care este sensul vieții?”
3. Lista modelelor AI disponibile
4. Mesaj personalizat pentru „MCP Explorer”
5. Șablonul promptului pentru revizuirea codului

## Detalii de implementare

Serverul este implementat folosind API-ul `FastMCP`, care oferă abstracții de nivel înalt pentru definirea serviciilor MCP. Iată un exemplu simplificat despre cum sunt definite tools:

```python
@mcp.tool()
def add(a: int, b: int) -> int:
    """Add two numbers together
    
    Args:
        a: First number
        b: Second number
    
    Returns:
        The sum of the two numbers
    """
    logger.info(f"Adding {a} and {b}")
    return a + b
```

Clientul folosește biblioteca client MCP pentru a se conecta și a apela serverul:

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## Aflați mai multe

Pentru mai multe informații despre MCP, vizitați: https://modelcontextprotocol.io/

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere automată AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original, în limba sa nativă, trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un traducător uman. Nu ne asumăm responsabilitatea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.