<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-13T23:59:37+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "hu"
}
-->
# Model Context Protocol (MCP) integráció az Azure AI Foundry-val

Ez az útmutató bemutatja, hogyan lehet integrálni a Model Context Protocol (MCP) szervereket az Azure AI Foundry ügynökeivel, lehetővé téve a hatékony eszközök összehangolását és vállalati szintű AI képességeket.

## Bevezetés

A Model Context Protocol (MCP) egy nyílt szabvány, amely lehetővé teszi az AI alkalmazások számára, hogy biztonságosan csatlakozzanak külső adatforrásokhoz és eszközökhöz. Az Azure AI Foundry-val való integráció során az MCP lehetővé teszi az ügynökök számára, hogy szabványos módon hozzáférjenek és kommunikáljanak különféle külső szolgáltatásokkal, API-kkal és adatforrásokkal.

Ez az integráció ötvözi az MCP eszközök ökoszisztémájának rugalmasságát az Azure AI Foundry robusztus ügynök keretrendszerével, így vállalati szintű AI megoldásokat kínál széleskörű testreszabási lehetőségekkel.

**Megjegyzés:** Ha az MCP-t az Azure AI Foundry Agent Service-ben szeretnéd használni, jelenleg csak a következő régiók támogatottak: westus, westus2, uaenorth, southindia és switzerlandnorth

## Tanulási célok

Az útmutató végére képes leszel:

- Megérteni a Model Context Protocol működését és előnyeit
- Beállítani MCP szervereket az Azure AI Foundry ügynökeivel való használathoz
- Ügynököket létrehozni és konfigurálni MCP eszköz integrációval
- Gyakorlati példákat megvalósítani valós MCP szerverek használatával
- Kezelni az eszközválaszokat és hivatkozásokat az ügynöki beszélgetések során

## Előfeltételek

A kezdés előtt győződj meg róla, hogy rendelkezel:

- Azure előfizetéssel, amelyhez hozzáférsz az AI Foundry-hoz
- Python 3.10+ verzióval
- Telepített és konfigurált Azure CLI-vel
- Megfelelő jogosultságokkal AI erőforrások létrehozásához

## Mi az a Model Context Protocol (MCP)?

A Model Context Protocol egy szabványosított módja annak, hogy az AI alkalmazások külső adatforrásokhoz és eszközökhöz csatlakozzanak. Fő előnyei:

- **Szabványosított integráció**: Egységes felület különböző eszközök és szolgáltatások között
- **Biztonság**: Biztonságos hitelesítési és engedélyezési mechanizmusok
- **Rugalmasság**: Támogatja a különféle adatforrásokat, API-kat és egyedi eszközöket
- **Bővíthetőség**: Könnyen hozzáadhatók új funkciók és integrációk

## MCP beállítása az Azure AI Foundry-val

### 1. Környezet konfigurálása

Először állítsd be a környezeti változókat és a függőségeket:

```python
import os
import time
import json
from azure.ai.agents.models import MessageTextContent, ListSortOrder
from azure.ai.projects import AIProjectClient
from azure.identity import DefaultAzureCredential


### 1. Initialize the AI Project Client

```python
project_client = AIProjectClient(
    endpoint="https://your-project-endpoint.services.ai.azure.com/api/projects/your-project",
    credential=DefaultAzureCredential(),
)
```

### 2. Create an Agent with MCP Tools

Configure an agent with MCP server integration:

```python
with project_client:
    agent = project_client.agents.create_agent(
        model="gpt-4.1-nano", 
        name="mcp_agent", 
        instructions="Segítőkész asszisztens vagy. Használd a rendelkezésre álló eszközöket a kérdések megválaszolásához. Mindig tüntesd fel a forrásaidat.",
        tools=[
            {
                "type": "mcp",
                "server_label": "microsoft_docs",
                "server_url": "https://learn.microsoft.com/api/mcp",
                "require_approval": "never"
            }
        ],
        tool_resources=None
    )
    print(f"Ügynök létrehozva, ügynök azonosító: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # Az MCP szerver azonosítója
    "server_url": "https://api.example.com/mcp", # MCP szerver végpontja
    "require_approval": "never"                 # Jóváhagyási szabályzat: jelenleg csak a "never" támogatott
}
```

## Complete Example: Using Microsoft Learn MCP Server

Here's a complete example that demonstrates creating an agent with MCP integration and processing a conversation:

```python
import time
import json
import os
from azure.ai.agents.models import MessageTextContent, ListSortOrder
from azure.ai.projects import AIProjectClient
from azure.identity import DefaultAzureCredential

def create_mcp_agent_example():

    project_client = AIProjectClient(
        endpoint="https://your-endpoint.services.ai.azure.com/api/projects/your-project",
        credential=DefaultAzureCredential(),
    )

    with project_client:
        # Ügynök létrehozása MCP eszközökkel
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="Segítőkész asszisztens vagy, aki a Microsoft dokumentációra specializálódott. Használd a Microsoft Learn MCP szervert, hogy pontos és naprakész információkat keress. Mindig tüntesd fel a forrásaidat.",
            tools=[
                {
                    "type": "mcp",
                    "server_label": "mslearn",
                    "server_url": "https://learn.microsoft.com/api/mcp",
                    "require_approval": "never"
                }
            ],
            tool_resources=None
        )
        print(f"Ügynök létrehozva, ügynök azonosító: {agent.id}")    
        
        # Beszélgetési szál létrehozása
        thread = project_client.agents.threads.create()
        print(f"Szál létrehozva, szál azonosító: {thread.id}")

        # Üzenet küldése
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="Mi az a .NET MAUI? Hogyan viszonyul a Xamarin.Forms-hoz?",
        )
        print(f"Üzenet létrehozva, üzenet azonosító: {message.id}")

        # Ügynök futtatása
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Várakozás a befejezésre
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Futás állapota: {run.status}")

        # Futás lépéseinek és eszközhívásoknak vizsgálata
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Futás lépés: {step.id}, állapot: {step.status}, típus: {step.type}")
            if step.type == "tool_calls":
                print("Eszköz hívás részletei:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Beszélgetés megjelenítése
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()


## Gyakori problémák elhárítása

### 1. Kapcsolódási problémák
- Ellenőrizd, hogy az MCP szerver URL elérhető-e
- Nézd meg a hitelesítési adatokat
- Biztosítsd a hálózati kapcsolatot

### 2. Eszköz hívás hibák
- Vizsgáld meg az eszköz argumentumait és formátumát
- Ellenőrizd a szerver specifikus követelményeket
- Valósíts meg megfelelő hibakezelést

### 3. Teljesítmény problémák
- Optimalizáld az eszköz hívások gyakoriságát
- Használj gyorsítótárazást, ahol indokolt
- Figyeld a szerver válaszidejét

## Következő lépések

Az MCP integráció további fejlesztéséhez:

1. **Saját MCP szerverek felfedezése**: Építs saját MCP szervereket zárt adatforrásokhoz
2. **Fejlett biztonság megvalósítása**: Adj hozzá OAuth2 vagy egyedi hitelesítési mechanizmusokat
3. **Monitorozás és elemzés**: Valósíts meg naplózást és monitorozást az eszközhasználathoz
4. **Megoldás skálázása**: Gondolkodj terheléselosztásban és elosztott MCP szerver architektúrákban

## További források

- [Azure AI Foundry dokumentáció](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol példák](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry ügynökök áttekintése](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP specifikáció](https://spec.modelcontextprotocol.io/)

## Támogatás

További támogatásért és kérdések esetén:
- Tekintsd át az [Azure AI Foundry dokumentációt](https://learn.microsoft.com/azure/ai-foundry/)
- Nézd meg az [MCP közösségi forrásokat](https://modelcontextprotocol.io/)

## Mi következik

- [6. Közösségi hozzájárulások](../../06-CommunityContributions/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.