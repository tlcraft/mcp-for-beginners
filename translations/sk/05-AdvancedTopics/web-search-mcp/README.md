<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7a11a5dcf2f9fdf6392f5a4545cf005e",
  "translation_date": "2025-07-14T03:46:23+00:00",
  "source_file": "05-AdvancedTopics/web-search-mcp/README.md",
  "language_code": "sk"
}
-->
# Lekcia: Vytvorenie Web Search MCP Servera

Táto kapitola ukazuje, ako vytvoriť reálneho AI agenta, ktorý sa integruje s externými API, spracováva rôzne typy dát, zvláda chyby a koordinuje viacero nástrojov – to všetko v produkčnej kvalite. Uvidíte:

- **Integráciu s externými API vyžadujúcimi autentifikáciu**
- **Spracovanie rôznych typov dát z viacerých zdrojov**
- **Robustné riešenie chýb a stratégie logovania**
- **Koordináciu viacerých nástrojov v jednom serveri**

Na konci budete mať praktické skúsenosti s vzormi a osvedčenými postupmi, ktoré sú nevyhnutné pre pokročilé AI a aplikácie poháňané LLM.

## Úvod

V tejto lekcii sa naučíte, ako vytvoriť pokročilý MCP server a klienta, ktorý rozširuje schopnosti LLM o dáta z webu v reálnom čase pomocou SerpAPI. Toto je kľúčová zručnosť pre vývoj dynamických AI agentov, ktorí dokážu pristupovať k aktuálnym informáciám z webu.

## Ciele učenia

Na konci tejto lekcie budete vedieť:

- Bezpečne integrovať externé API (ako SerpAPI) do MCP servera
- Implementovať viacero nástrojov pre vyhľadávanie na webe, v správach, produktoch a Q&A
- Parsovať a formátovať štruktúrované dáta pre potreby LLM
- Efektívne riešiť chyby a spravovať limity API
- Vytvárať a testovať automatizovaných aj interaktívnych MCP klientov

## Web Search MCP Server

Táto časť predstavuje architektúru a funkcie Web Search MCP Servera. Uvidíte, ako sa FastMCP a SerpAPI používajú spoločne na rozšírenie schopností LLM o dáta z webu v reálnom čase.

### Prehľad

Táto implementácia obsahuje štyri nástroje, ktoré demonštrujú schopnosť MCP bezpečne a efektívne spracovávať rôznorodé úlohy založené na externých API:

- **general_search**: Pre široké výsledky z webu
- **news_search**: Pre najnovšie správy
- **product_search**: Pre dáta z e-commerce
- **qna**: Pre otázky a odpovede

### Funkcie
- **Príklady kódu**: Obsahuje jazykovo špecifické bloky kódu pre Python (a ľahko rozšíriteľné na iné jazyky) s rozbaľovacími sekciami pre prehľadnosť

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

Pred spustením klienta je užitočné pochopiť, čo server robí. Súbor [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) implementuje MCP server, ktorý sprístupňuje nástroje pre webové, spravodajské, produktové vyhľadávanie a Q&A integráciou so SerpAPI. Spracováva prichádzajúce požiadavky, riadi volania API, parsuje odpovede a vracia štruktúrované výsledky klientovi.

Celú implementáciu si môžete pozrieť v [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

Tu je krátky príklad, ako server definuje a registruje nástroj:

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

- **Integrácia externého API**: Ukazuje bezpečné spracovanie API kľúčov a externých požiadaviek
- **Parsovanie štruktúrovaných dát**: Ukazuje, ako transformovať odpovede API do formátov vhodných pre LLM
- **Riešenie chýb**: Robustné spracovanie chýb s adekvátnym logovaním
- **Interaktívny klient**: Obsahuje automatizované testy aj interaktívny režim na testovanie
- **Správa kontextu**: Využíva MCP Context pre logovanie a sledovanie požiadaviek

## Predpoklady

Pred začatím sa uistite, že máte správne nastavené prostredie podľa týchto krokov. Zabezpečí to, že všetky závislosti budú nainštalované a vaše API kľúče správne nakonfigurované pre bezproblémový vývoj a testovanie.

- Python 3.8 alebo novší
- SerpAPI API kľúč (Zaregistrujte sa na [SerpAPI](https://serpapi.com/) – dostupný je aj bezplatný plán)

## Inštalácia

Na začiatok postupujte podľa týchto krokov na nastavenie prostredia:

1. Nainštalujte závislosti pomocou uv (odporúčané) alebo pip:

```bash
# Using uv (recommended)
uv pip install -r requirements.txt

# Using pip
pip install -r requirements.txt
```

2. Vytvorte `.env` súbor v koreňovom adresári projektu s vaším SerpAPI kľúčom:

```
SERPAPI_KEY=your_serpapi_key_here
```

## Použitie

Web Search MCP Server je jadrom, ktoré sprístupňuje nástroje pre webové, spravodajské, produktové vyhľadávanie a Q&A integráciou so SerpAPI. Spracováva prichádzajúce požiadavky, riadi volania API, parsuje odpovede a vracia štruktúrované výsledky klientovi.

Celú implementáciu si môžete pozrieť v [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py).

### Spustenie servera

Na spustenie MCP servera použite nasledujúci príkaz:

```bash
python server.py
```

Server bude bežať ako MCP server založený na stdio, ku ktorému sa klient môže pripojiť priamo.

### Režimy klienta

Klient (`client.py`) podporuje dva režimy interakcie s MCP serverom:

- **Normálny režim**: Spúšťa automatizované testy, ktoré otestujú všetky nástroje a overia ich odpovede. Je to užitočné na rýchlu kontrolu, či server a nástroje fungujú správne.
- **Interaktívny režim**: Spustí menu, kde môžete manuálne vyberať a volať nástroje, zadávať vlastné dotazy a vidieť výsledky v reálnom čase. Ideálne na skúmanie možností servera a experimentovanie s rôznymi vstupmi.

Celú implementáciu si môžete pozrieť v [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py).

### Spustenie klienta

Na spustenie automatizovaných testov (tým sa automaticky spustí aj server):

```bash
python client.py
```

Alebo spustite interaktívny režim:

```bash
python client.py --interactive
```

### Testovanie rôznymi spôsobmi

Existuje niekoľko spôsobov, ako testovať a interagovať s nástrojmi poskytovanými serverom, podľa vašich potrieb a pracovného postupu.

#### Písanie vlastných testovacích skriptov s MCP Python SDK
Môžete si tiež vytvoriť vlastné testovacie skripty pomocou MCP Python SDK:

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

V tomto kontexte "testovací skript" znamená vlastný Python program, ktorý napíšete ako klienta pre MCP server. Namiesto formálneho jednotkového testu vám tento skript umožní programovo sa pripojiť k serveru, volať jeho nástroje s parametrami podľa vášho výberu a skúmať výsledky. Tento prístup je užitočný pre:
- Prototypovanie a experimentovanie s volaniami nástrojov
- Overovanie, ako server reaguje na rôzne vstupy
- Automatizáciu opakovaných volaní nástrojov
- Vytváranie vlastných pracovných tokov alebo integrácií nad MCP serverom

Testovacie skripty môžete použiť na rýchle vyskúšanie nových dotazov, ladenie správania nástrojov alebo ako východiskový bod pre pokročilejšiu automatizáciu. Nižšie je príklad použitia MCP Python SDK na vytvorenie takéhoto skriptu:

## Popisy nástrojov

Môžete použiť nasledujúce nástroje poskytované serverom na vykonávanie rôznych typov vyhľadávania a dotazov. Každý nástroj je popísaný nižšie spolu s jeho parametrami a príkladmi použitia.

Táto časť poskytuje podrobnosti o každom dostupnom nástroji a ich parametroch.

### general_search

Vykonáva všeobecné webové vyhľadávanie a vracia naformátované výsledky.

**Ako volať tento nástroj:**

`general_search` môžete volať zo svojho skriptu pomocou MCP Python SDK alebo interaktívne cez Inspector či interaktívny režim klienta. Tu je príklad kódu s použitím SDK:

<details>
<summary>Python príklad</summary>

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

Alternatívne, v interaktívnom režime vyberte `general_search` z menu a zadajte svoj dotaz, keď budete vyzvaní.

**Parametre:**
- `query` (string): Vyhľadávací dotaz

**Príklad požiadavky:**

```json
{
  "query": "latest AI trends"
}
```

### news_search

Vyhľadáva najnovšie spravodajské články súvisiace s dotazom.

**Ako volať tento nástroj:**

`news_search` môžete volať zo svojho skriptu pomocou MCP Python SDK alebo interaktívne cez Inspector či interaktívny režim klienta. Tu je príklad kódu s použitím SDK:

<details>
<summary>Python príklad</summary>

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

Alternatívne, v interaktívnom režime vyberte `news_search` z menu a zadajte svoj dotaz, keď budete vyzvaní.

**Parametre:**
- `query` (string): Vyhľadávací dotaz

**Príklad požiadavky:**

```json
{
  "query": "AI policy updates"
}
```

### product_search

Vyhľadáva produkty zodpovedajúce dotazu.

**Ako volať tento nástroj:**

`product_search` môžete volať zo svojho skriptu pomocou MCP Python SDK alebo interaktívne cez Inspector či interaktívny režim klienta. Tu je príklad kódu s použitím SDK:

<details>
<summary>Python príklad</summary>

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

Alternatívne, v interaktívnom režime vyberte `product_search` z menu a zadajte svoj dotaz, keď budete vyzvaní.

**Parametre:**
- `query` (string): Vyhľadávací dotaz na produkt

**Príklad požiadavky:**

```json
{
  "query": "best AI gadgets 2025"
}
```

### qna

Získava priame odpovede na otázky z vyhľadávačov.

**Ako volať tento nástroj:**

`qna` môžete volať zo svojho skriptu pomocou MCP Python SDK alebo interaktívne cez Inspector či interaktívny režim klienta. Tu je príklad kódu s použitím SDK:

<details>
<summary>Python príklad</summary>

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

Alternatívne, v interaktívnom režime vyberte `qna` z menu a zadajte svoju otázku, keď budete vyzvaní.

**Parametre:**
- `question` (string): Otázka, na ktorú chcete nájsť odpoveď

**Príklad požiadavky:**

```json
{
  "question": "what is artificial intelligence"
}
```

## Podrobnosti kódu

Táto časť poskytuje úryvky kódu a odkazy na implementácie servera a klienta.

<details>
<summary>Python</summary>

Pozrite si [`server.py`](../../../../05-AdvancedTopics/web-search-mcp/server.py) a [`client.py`](../../../../05-AdvancedTopics/web-search-mcp/client.py) pre kompletné detaily implementácie.

```python
# Example snippet from server.py:
import os
import httpx
# ...existing code...
```
</details>

## Pokročilé koncepty v tejto lekcii

Pred začatím vývoja si prejdeme niektoré dôležité pokročilé koncepty, ktoré sa v tejto kapitole objavia. Ich pochopenie vám pomôže lepšie sledovať obsah, aj keď s nimi ešte nemáte skúsenosti:

- **Koordinácia viacerých nástrojov**: Znamená to spúšťanie viacerých rôznych nástrojov (ako webové vyhľadávanie, správy, produkty a Q&A) v jednom MCP serveri. Umožňuje to serveru spracovávať rôzne úlohy, nie len jednu.
- **Riešenie limitov API**: Mnohé externé API (ako SerpAPI) obmedzujú počet požiadaviek za určitý čas. Dobrý kód tieto limity kontroluje a spracováva ich tak, aby aplikácia nepadla, keď limit dosiahnete.
- **Parsovanie štruktúrovaných dát**: Odpovede API sú často zložité a vnorené. Tento koncept znamená premeniť tieto odpovede na čisté, ľahko použiteľné formáty vhodné pre LLM alebo iné programy.
- **Obnova po chybe**: Niekedy sa niečo pokazí – napríklad sieť zlyhá alebo API nevráti očakávané dáta. Obnova po chybe znamená, že váš kód dokáže tieto problémy zvládnuť a stále poskytnúť užitočnú spätnú väzbu namiesto pádu.
- **Validácia parametrov**: Znamená to kontrolu, či všetky vstupy do vašich nástrojov sú správne a bezpečné na použitie. Zahŕňa nastavenie predvolených hodnôt a overenie typov, čo pomáha predchádzať chybám a nejasnostiam.

Táto časť vám pomôže diagnostikovať a vyriešiť bežné problémy, na ktoré môžete naraziť pri práci s Web Search MCP Serverom. Ak narazíte na chyby alebo neočakávané správanie, táto sekcia poskytuje riešenia najčastejších problémov. Prezrite si tieto tipy predtým, než požiadate o ďalšiu pomoc – často rýchlo vyriešia problém.

## Riešenie problémov

Pri práci s Web Search MCP Serverom sa občas môžu vyskytnúť problémy – je to bežné pri vývoji s externými API a novými nástrojmi. Táto sekcia poskytuje praktické riešenia najčastejších problémov, aby ste sa mohli rýchlo vrátiť k práci. Ak narazíte na chybu, začnite tu: nižšie uvedené tipy riešia problémy, s ktorými sa stretáva väčšina používateľov, a často vyriešia váš problém bez potreby ďalšej pomoci.

### Bežné problémy

Nižšie sú uvedené niektoré z najčastejších problémov, s ktorými sa používatelia stretávajú, spolu s jasnými vysvetleniami a krokmi na ich vyriešenie:

1. **Chýbajúci SERPAPI_KEY v .env súbore**
   - Ak sa zobrazí chyba `SERPAPI_KEY environment variable not found`, znamená to, že vaša aplikácia nemôže nájsť API kľúč potrebný na prístup k SerpAPI. Na opravu vytvorte v koreňovom adresári projektu súbor `.env` (ak ešte neexistuje) a pridajte riadok `SERPAPI_KEY=your_serpapi_key_here`. Nezabudnite nahradiť `your_serpapi_key_here` vaším skutočným kľúčom zo stránky SerpAPI.

2. **Chyby typu Module not found**
   - Chyby ako `ModuleNotFoundError: No module named 'httpx'` znamenajú, že chýba potrebný Python balík. Zvyčajne sa to stane, ak ste nenainštalovali všetky závislosti. Na vyriešenie spustite v termináli `pip install -r requirements.txt`, aby ste nainštalovali všetko, čo projekt potrebuje.

3. **Problémy s pripojením**
   - Ak sa zobrazí chyba ako `Error during client execution`, často to znamená, že klient sa nemôže pripojiť k serveru alebo server nebeží správne. Skontrolujte, či sú klient a server kompatibilné verzie a či je súbor `server.py` prítomný a spustený v správnom adresári. Pomôže aj reštartovanie servera aj klienta.

4. **Chyby SerpAPI**
   - Chyba `Search API returned error status: 401` znamená, že váš SerpAPI kľúč chýba, je nesprávny alebo expirovaný. Prejdite do svojho SerpAPI dashboardu, overte kľúč a podľa potreby aktualizujte `.env` súbor. Ak je kľúč správny, ale chyba pretrváva, skontrolujte, či vám nevypršal bezplatný limit.

### Režim ladenia (Debug Mode)

Štandardne aplikácia loguje len dôležité informácie. Ak chcete vidieť viac detailov o tom, čo sa deje (napríklad na diagnostiku zložitých problémov), môžete zapnúť režim DEBUG. Ten vám ukáže oveľa viac o každom kroku, ktorý aplikácia vykonáva.

**Príklad:

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

## Čo ďalej

- [5.10 Streamovanie v reálnom čase](../mcp-realtimestreaming/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.