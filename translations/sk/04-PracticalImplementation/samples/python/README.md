<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "706b9b075dc484b73a053e6e9c709b4b",
  "translation_date": "2025-05-25T13:33:09+00:00",
  "source_file": "04-PracticalImplementation/samples/python/README.md",
  "language_code": "sk"
}
-->
# Model Context Protocol (MCP) Python implementácia

Tento repozitár obsahuje Python implementáciu Model Context Protocolu (MCP), ktorá ukazuje, ako vytvoriť serverovú aj klientskú aplikáciu komunikujúcu podľa štandardu MCP.

## Prehľad

Implementácia MCP pozostáva z dvoch hlavných častí:

1. **MCP Server (`server.py`)** – Server, ktorý sprístupňuje:
   - **Nástroje**: Funkcie, ktoré je možné volať na diaľku
   - **Zdroje**: Dáta, ktoré je možné získať
   - **Výzvy**: Šablóny na generovanie výziev pre jazykové modely

2. **MCP Klient (`client.py`)** – Klientská aplikácia, ktorá sa pripája k serveru a využíva jeho funkcie

## Funkcie

Táto implementácia ukazuje niekoľko kľúčových vlastností MCP:

### Nástroje
- `completion` – Generuje textové dokončenia z AI modelov (simulované)
- `add` – Jednoduchá kalkulačka, ktorá sčíta dve čísla

### Zdroje
- `models://` – Vracia informácie o dostupných AI modeloch
- `greeting://{name}` – Vracia personalizované privítanie pre dané meno

### Výzvy
- `review_code` – Generuje výzvu na kontrolu kódu

## Inštalácia

Na použitie tejto MCP implementácie nainštalujte potrebné balíky:

```powershell
pip install mcp-server mcp-client
```

## Spustenie servera a klienta

### Spustenie servera

Server spustite v jednom terminálovom okne:

```powershell
python server.py
```

Server je možné spustiť aj v režime vývoja pomocou MCP CLI:

```powershell
mcp dev server.py
```

Alebo ho nainštalovať do Claude Desktop (ak je dostupný):

```powershell
mcp install server.py
```

### Spustenie klienta

Klienta spustite v inom terminálovom okne:

```powershell
python client.py
```

Týmto sa klient pripojí k serveru a predvedie všetky dostupné funkcie.

### Použitie klienta

Klient (`client.py`) demonštruje všetky schopnosti MCP:

```powershell
python client.py
```

Pripojí sa k serveru a otestuje všetky funkcie vrátane nástrojov, zdrojov a výziev. Výstup zobrazí:

1. Výsledok kalkulačky (5 + 7 = 12)
2. Odpoveď dokončovacieho nástroja na otázku „What is the meaning of life?“
3. Zoznam dostupných AI modelov
4. Personalizované privítanie pre „MCP Explorer“
5. Šablónu výzvy na kontrolu kódu

## Detaily implementácie

Server je implementovaný pomocou API `FastMCP`, ktoré poskytuje vysokú úroveň abstrakcií pre definovanie MCP služieb. Tu je zjednodušený príklad definície nástrojov:

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

Klient používa knižnicu MCP client na pripojenie a volanie servera:

```python
async with stdio_client(server_params) as (reader, writer):
    async with ClientSession(reader, writer) as session:
        await session.initialize()
        result = await session.call_tool("add", arguments={"a": 5, "b": 7})
```

## Viac informácií

Pre viac informácií o MCP navštívte: https://modelcontextprotocol.io/

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, vezmite prosím na vedomie, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.