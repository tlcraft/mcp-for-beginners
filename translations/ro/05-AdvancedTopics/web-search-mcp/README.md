<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-06-11T16:23:58+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "ro"
}
-->
# Lecția: Construirea unui Server MCP pentru Căutare Web

Acest capitol arată cum să construiești un agent AI real care se integrează cu API-uri externe, gestionează tipuri diverse de date, tratează erorile și coordonează mai multe unelte — toate într-un format pregătit pentru producție. Vei vedea:

- **Integrarea cu API-uri externe care necesită autentificare**
- **Gestionarea tipurilor diverse de date de la multiple endpoint-uri**
- **Strategii robuste de tratare a erorilor și logare**
- **Orchestrarea mai multor unelte într-un singur server**

La final, vei avea experiență practică cu modele și bune practici esențiale pentru aplicații avansate AI și bazate pe LLM.

## Introducere

În această lecție, vei învăța cum să construiești un server și un client MCP avansat care extind capabilitățile LLM cu date web în timp real folosind SerpAPI. Aceasta este o abilitate esențială pentru dezvoltarea agenților AI dinamici care pot accesa informații actualizate de pe web.

## Obiectivele de Învățare

La finalul acestei lecții, vei putea să:

- Integrezi API-uri externe (ca SerpAPI) în siguranță într-un server MCP
- Implementezi mai multe unelte pentru căutare web, știri, produse și Q&A
- Parsezi și formatezi date structurate pentru consumul LLM
- Gestionezi erorile și limitele de rată ale API-urilor eficient
- Construiești și testezi atât clienți MCP automatizați, cât și interactivi

## Server MCP pentru Căutare Web

Această secțiune prezintă arhitectura și funcționalitățile Serverului MCP pentru Căutare Web. Vei vedea cum FastMCP și SerpAPI sunt folosite împreună pentru a extinde capabilitățile LLM cu date web în timp real.

### Prezentare generală

Această implementare include patru unelte care demonstrează capacitatea MCP de a gestiona sarcini diverse, bazate pe API-uri externe, în mod sigur și eficient:

- **general_search**: Pentru rezultate generale pe web
- **news_search**: Pentru titluri recente din știri
- **product_search**: Pentru date de comerț electronic
- **qna**: Pentru fragmente de întrebări și răspunsuri

### Funcționalități
- **Exemple de cod**: Include blocuri de cod specifice pentru Python (și ușor de extins la alte limbaje) folosind secțiuni pliabile pentru claritate

<details>  
<summary>Python</summary>  

```python
# Example usage of the general_search tool
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "open source LLMs"})
            print(result)
```
</details>

Înainte de a rula clientul, este util să înțelegi ce face serverul. Fișierul [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) file implements the MCP server, exposing tools for web, news, product search, and Q&A by integrating with SerpAPI. It handles incoming requests, manages API calls, parses responses, and returns structured results to the client.

You can review the full implementation in [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Iată un exemplu scurt despre cum serverul definește și înregistrează o unealtă:

<details>  
<summary>Python Server</summary> 

```python
# server.py (excerpt)
from mcp.server import MCPServer, Tool

async def general_search(query: str):
    # ...implementation...

server = MCPServer()
server.add_tool(Tool("general_search", general_search))

if __name__ == "__main__":
    server.run()
```
</details>

- **Integrarea API-urilor Externe**: Demonstrează gestionarea sigură a cheilor API și a cererilor externe
- **Parsing-ul Datelor Structurate**: Arată cum se transformă răspunsurile API în formate prietenoase pentru LLM
- **Gestionarea Erorilor**: Tratare robustă a erorilor cu logare corespunzătoare
- **Client Interactiv**: Include atât teste automate, cât și un mod interactiv pentru testare
- **Managementul Contextului**: Folosește MCP Context pentru logare și urmărirea cererilor

## Cerințe Prealabile

Înainte să începi, asigură-te că mediul tău este configurat corect urmând acești pași. Astfel, toate dependențele vor fi instalate și cheile tale API configurate corespunzător pentru dezvoltare și testare fără probleme.

- Python 3.8 sau mai nou
- Cheie API SerpAPI (Înscrie-te la [SerpAPI](https://serpapi.com/) - există un plan gratuit)

## Instalare

Pentru a începe, urmează acești pași pentru configurarea mediului:

1. Instalează dependențele folosind uv (recomandat) sau pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Creează un fișier `.env` în rădăcina proiectului cu cheia ta SerpAPI:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Utilizare

Serverul MCP pentru Căutare Web este componenta principală care expune unelte pentru căutare web, știri, produse și Q&A prin integrarea cu SerpAPI. El gestionează cererile primite, apelează API-urile, parsează răspunsurile și returnează rezultate structurate către client.

Poți consulta implementarea completă în [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Pornirea Serverului

Pentru a porni serverul MCP, folosește următoarea comandă:

```bash
python server.py
```

Serverul va funcționa ca un server MCP bazat pe stdio, la care clientul se poate conecta direct.

### Moduri Client

Clientul (`client.py`) supports two modes for interacting with the MCP server:

- **Normal mode**: Runs automated tests that exercise all the tools and verify their responses. This is useful for quickly checking that the server and tools are working as expected.
- **Interactive mode**: Starts a menu-driven interface where you can manually select and call tools, enter custom queries, and see results in real time. This is ideal for exploring the server's capabilities and experimenting with different inputs.

You can review the full implementation in [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Rularea Clientului

Pentru a rula testele automate (acesta va porni automat serverul):

```bash
python client.py
```

Sau în modul interactiv:

```bash
python client.py --interactive
```

### Testare cu Metode Diferite

Există mai multe moduri de a testa și interacționa cu uneltele oferite de server, în funcție de nevoile și fluxul tău de lucru.

#### Scrierea Scripturilor Personalizate de Test folosind MCP Python SDK
Poți să-ți construiești propriile scripturi de test folosind MCP Python SDK:

<details>
<summary>Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def test_custom_query():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            # Call tools with your custom parameters
            result = await session.call_tool("general_search", 
                                           arguments={"query": "your custom query"})
            # Process the result
```
</details>

În acest context, un „script de test” înseamnă un program Python personalizat pe care îl scrii pentru a acționa ca un client pentru serverul MCP. În loc să fie un test formal de unitate, acest script îți permite să te conectezi programatic la server, să apelezi oricare dintre uneltele sale cu parametri aleși de tine și să inspectezi rezultatele. Această abordare este utilă pentru:
- Prototiparea și experimentarea cu apelurile uneltelor
- Validarea modului în care serverul răspunde la diverse intrări
- Automatizarea apelurilor repetate ale uneltelor
- Construirea propriilor fluxuri de lucru sau integrări peste serverul MCP

Poți folosi scripturile de test pentru a încerca rapid interogări noi, a depana comportamentul uneltelor sau chiar ca punct de plecare pentru automatizări mai avansate. Mai jos este un exemplu despre cum să folosești MCP Python SDK pentru a crea un astfel de script:

## Descrierea Uneltelor

Poți folosi următoarele unelte oferite de server pentru a efectua diferite tipuri de căutări și interogări. Fiecare unealtă este descrisă mai jos cu parametrii săi și un exemplu de utilizare.

Această secțiune oferă detalii despre fiecare unealtă disponibilă și parametrii lor.

### general_search

Efectuează o căutare generală pe web și returnează rezultate formatate.

**Cum să apelezi această unealtă:**

Poți apela `general_search` din propriul script folosind MCP Python SDK sau interactiv folosind Inspectorul sau modul interactiv al clientului. Iată un exemplu de cod folosind SDK:

<details>
<summary>Exemplu Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_general_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("general_search", arguments={"query": "latest AI trends"})
            print(result)
```
</details>

Alternativ, în modul interactiv, selectează `general_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Interogarea de căutare

**Exemplu de Cerere:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Caută articole recente de știri legate de o interogare.

**Cum să apelezi această unealtă:**

Poți apela `news_search` din propriul script folosind MCP Python SDK sau interactiv folosind Inspectorul sau modul interactiv al clientului. Iată un exemplu de cod folosind SDK:

<details>
<summary>Exemplu Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_news_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("news_search", arguments={"query": "AI policy updates"})
            print(result)
```
</details>

Alternativ, în modul interactiv, selectează `news_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Interogarea de căutare

**Exemplu de Cerere:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Caută produse care corespund unei interogări.

**Cum să apelezi această unealtă:**

Poți apela `product_search` din propriul script folosind MCP Python SDK sau interactiv folosind Inspectorul sau modul interactiv al clientului. Iată un exemplu de cod folosind SDK:

<details>
<summary>Exemplu Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_product_search():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("product_search", arguments={"query": "best AI gadgets 2025"})
            print(result)
```
</details>

Alternativ, în modul interactiv, selectează `product_search` from the menu and enter your query when prompted.

**Parameters:**
- `query` (string): Interogarea de căutare pentru produse

**Exemplu de Cerere:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Oferă răspunsuri directe la întrebări din motoarele de căutare.

**Cum să apelezi această unealtă:**

Poți apela `qna` din propriul script folosind MCP Python SDK sau interactiv folosind Inspectorul sau modul interactiv al clientului. Iată un exemplu de cod folosind SDK:

<details>
<summary>Exemplu Python</summary>

```python
from mcp import ClientSession, StdioServerParameters
from mcp.client.stdio import stdio_client

async def run_qna():
    server_params = StdioServerParameters(
        command="python",
        args=["server.py"],
    )
    async with stdio_client(server_params) as (reader, writer):
        async with ClientSession(reader, writer) as session:
            await session.initialize()
            result = await session.call_tool("qna", arguments={"question": "what is artificial intelligence"})
            print(result)
```
</details>

Alternativ, în modul interactiv, selectează `qna` from the menu and enter your question when prompted.

**Parameters:**
- `question` (string): Întrebarea pentru care vrei un răspuns

**Exemplu de Cerere:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Detalii de Cod

Această secțiune oferă fragmente de cod și referințe pentru implementările serverului și clientului.

<details>
<summary>Python</summary>

Vezi [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) and [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) pentru detalii complete ale implementării.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Concepte Avansate în Această Lecție

Înainte să începi să construiești, iată câteva concepte avansate importante care vor apărea pe tot parcursul acestui capitol. Înțelegerea lor te va ajuta să urmărești mai ușor, chiar dacă sunt noi pentru tine:

- **Orchestrarea mai multor unelte**: Aceasta înseamnă rularea simultană a mai multor unelte diferite (ca căutare web, știri, produse și Q&A) într-un singur server MCP. Permite serverului să gestioneze o varietate de sarcini, nu doar una singură.
- **Gestionarea limitelor de rată API**: Multe API-uri externe (ca SerpAPI) limitează câte cereri poți face într-un interval de timp. Un cod bun verifică aceste limite și le gestionează elegant, astfel încât aplicația ta să nu se oprească dacă atingi o limită.
- **Parsing-ul datelor structurate**: Răspunsurile API sunt adesea complexe și ierarhizate. Acest concept se referă la transformarea acestor răspunsuri în formate curate, ușor de folosit, prietenoase pentru LLM-uri sau alte programe.
- **Recuperarea după erori**: Uneori apar probleme — poate rețeaua cade sau API-ul nu răspunde cum te aștepți. Recuperarea după erori înseamnă că codul tău poate gestiona aceste probleme și tot oferă feedback util, în loc să se blocheze.
- **Validarea parametrilor**: Este despre verificarea faptului că toate intrările către uneltele tale sunt corecte și sigure pentru utilizare. Include setarea valorilor implicite și asigurarea tipurilor corecte, ceea ce ajută la prevenirea erorilor și confuziilor.

Această secțiune te va ajuta să identifici și să rezolvi problemele comune pe care le-ai putea întâlni lucrând cu Serverul MCP pentru Căutare Web. Dacă întâmpini erori sau comportamente neașteptate, această secțiune de depanare oferă soluții pentru cele mai frecvente probleme. Consultă aceste sfaturi înainte de a cere ajutor suplimentar — adesea rezolvă rapid problemele.

## Depanare

Lucrând cu Serverul MCP pentru Căutare Web, s-ar putea să întâmpini uneori probleme — este normal când dezvolți cu API-uri externe și unelte noi. Această secțiune oferă soluții practice pentru cele mai frecvente probleme, ca să te poți întoarce rapid la lucru. Dacă întâmpini o eroare, începe de aici: sfaturile de mai jos abordează problemele pe care cei mai mulți utilizatori le întâmpină și deseori pot rezolva problema fără ajutor suplimentar.

### Probleme Comune

Mai jos sunt câteva dintre cele mai frecvente probleme întâlnite de utilizatori, împreună cu explicații clare și pași pentru rezolvare:

1. **Lipsa SERPAPI_KEY în fișierul .env**
   - Dacă vezi eroarea `SERPAPI_KEY environment variable not found`, it means your application can't find the API key needed to access SerpAPI. To fix this, create a file named `.env` in your project root (if it doesn't already exist) and add a line like `SERPAPI_KEY=your_serpapi_key_here`. Make sure to replace `your_serpapi_key_here` with your actual key from the SerpAPI website.

2. **Module not found errors**
   - Errors such as `ModuleNotFoundError: No module named 'httpx'` indicate that a required Python package is missing. This usually happens if you haven't installed all the dependencies. To resolve this, run `pip install -r requirements.txt` in your terminal to install everything your project needs.

3. **Connection issues**
   - If you get an error like `Error during client execution`, it often means the client can't connect to the server, or the server isn't running as expected. Double-check that both the client and server are compatible versions, and that `server.py` is present and running in the correct directory. Restarting both the server and client can also help.

4. **SerpAPI errors**
   - Seeing `Search API returned error status: 401` means your SerpAPI key is missing, incorrect, or expired. Go to your SerpAPI dashboard, verify your key, and update your ``, creează fișierul `.env` dacă este necesar. Dacă cheia ta este corectă, dar încă vezi această eroare, verifică dacă ai depășit cota din planul gratuit.

### Modul Debug

Implicit, aplicația înregistrează doar informațiile importante. Dacă vrei să vezi mai multe detalii despre ce se întâmplă (de exemplu, pentru a diagnostica probleme dificile), poți activa modul DEBUG. Acesta îți va arăta mult mai multe despre fiecare pas pe care îl face aplicația.

**Exemplu: Ieșire Normală**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

**Exemplu: Ieșire DEBUG**
```plaintext
2025-06-01 10:15:23,456 - __main__ - INFO - Calling general_search with params: {'query': 'open source LLMs'}
2025-06-01 10:15:23,457 - httpx - DEBUG - HTTP Request: GET https://serpapi.com/search ...
2025-06-01 10:15:23,458 - httpx - DEBUG - HTTP Response: 200 OK ...
2025-06-01 10:15:24,123 - __main__ - INFO - Successfully called general_search

GENERAL_SEARCH RESULTS:
... (search results here) ...
```

Observă cum modul DEBUG include linii suplimentare despre cererile HTTP, răspunsuri și alte detalii interne. Acest lucru poate fi foarte util pentru depanare.

Pentru a activa modul DEBUG, setează nivelul de logare la DEBUG în partea de sus a fișierului `client.py` or `server.py`:

<details>
<summary>Python</summary>

```python
# At the top of your client.py or server.py
import logging
logging.basicConfig(
    level=logging.DEBUG,  # Change from INFO to DEBUG
    format="%(asctime)s - %(name)s - %(levelname)s - %(message)s"
)
```
</details>

---

## Ce urmează

- [5.10 Real Time Streaming](../mcp-realtimestreaming/README.md)

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere automată AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un traducător uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.