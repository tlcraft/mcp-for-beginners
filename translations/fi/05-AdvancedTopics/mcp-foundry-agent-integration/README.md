<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:16:59+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "fi"
}
-->
# Model Context Protocol (MCP) -integrointi Azure AI Foundryn kanssa

Tässä oppaassa näytetään, miten Model Context Protocol (MCP) -palvelimet integroidaan Azure AI Foundryn agenttien kanssa, mahdollistaen tehokkaan työkalujen orkestroinnin ja yritystason tekoälytoiminnot.

## Johdanto

Model Context Protocol (MCP) on avoin standardi, joka mahdollistaa tekoälysovellusten turvallisen yhteyden ulkoisiin tietolähteisiin ja työkaluihin. Kun MCP yhdistetään Azure AI Foundryyn, agentit voivat käyttää ja olla vuorovaikutuksessa eri ulkoisten palveluiden, rajapintojen ja tietolähteiden kanssa yhtenäisellä tavalla.

Tämä integraatio yhdistää MCP:n työkaluekosysteemin joustavuuden Azure AI Foundryn vankkaan agenttikehykseen tarjoten yritystason tekoälyratkaisuja laajalla räätälöitävyydellä.

**Note:** Jos haluat käyttää MCP:tä Azure AI Foundry Agent Service -palvelussa, tällä hetkellä tuetut alueet ovat: westus, westus2, uaenorth, southindia ja switzerlandnorth

## Oppimistavoitteet

Oppaan lopussa osaat:

- Ymmärtää Model Context Protocolin ja sen hyödyt
- Määrittää MCP-palvelimet Azure AI Foundryn agenttien käyttöön
- Luoda ja konfiguroida agentteja MCP-työkalujen integraatiolla
- Toteuttaa käytännön esimerkkejä oikeilla MCP-palvelimilla
- Käsitellä työkalujen vastauksia ja lähdeviitteitä agenttikeskusteluissa

## Vaatimukset

Ennen aloittamista varmista, että sinulla on:

- Azure-tilaus, jossa on AI Foundryn käyttöoikeus
- Python 3.10+ 
- Azure CLI asennettuna ja konfiguroituna
- Tarvittavat oikeudet AI-resurssien luomiseen

## Mikä on Model Context Protocol (MCP)?

Model Context Protocol on standardoitu tapa tekoälysovelluksille yhdistää ulkoisiin tietolähteisiin ja työkaluihin. Keskeisiä etuja ovat:

- **Standardoitu integraatio**: Johdonmukainen käyttöliittymä eri työkaluille ja palveluille
- **Turvallisuus**: Turvalliset tunnistautumis- ja valtuutusmekanismit
- **Joustavuus**: Tuki erilaisille tietolähteille, rajapinnoille ja räätälöidyille työkaluille
- **Laajennettavuus**: Helppo lisätä uusia toimintoja ja integraatioita

## MCP:n käyttöönotto Azure AI Foundryn kanssa

### 1. Ympäristön konfigurointi

Aloita määrittämällä ympäristömuuttujat ja riippuvuudet:

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
        instructions="Olet avulias avustaja. Käytä annettuja työkaluja vastataksesi kysymyksiin. Muista aina mainita lähteet.",
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
    print(f"Agentti luotu, agentin ID: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # Tunniste MCP-palvelimelle
    "server_url": "https://api.example.com/mcp", # MCP-palvelimen päätepiste
    "require_approval": "never"                 # Hyväksyntäkäytäntö: tällä hetkellä tuettu vain "never" 
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
        # Luo agentti MCP-työkaluilla
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="Olet avulias avustaja, joka on erikoistunut Microsoftin dokumentaatioon. Käytä Microsoft Learn MCP -palvelinta etsiäksesi tarkkaa ja ajantasaista tietoa. Muista aina mainita lähteet.",
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
        print(f"Agentti luotu, agentin ID: {agent.id}")    
        
        # Luo keskusteluketju
        thread = project_client.agents.threads.create()
        print(f"Keskusteluketju luotu, ketjun ID: {thread.id}")

        # Lähetä viesti
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content="Mikä on .NET MAUI? Miten se vertautuu Xamarin.Formsiin?",
        )
        print(f"Viesti luotu, viestin ID: {message.id}")

        # Käynnistä agentti
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # Tarkista suoritus
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"Suorituksen tila: {run.status}")

        # Tarkastele suorituksen vaiheita ja työkalukutsuja
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"Suoritusvaihe: {step.id}, tila: {step.status}, tyyppi: {step.type}")
            if step.type == "tool_calls":
                print("Työkalukutsun tiedot:")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # Näytä keskustelu
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
  

## Yleisiä ongelmia ja ratkaisuja

### 1. Yhteysongelmat
- Varmista, että MCP-palvelimen URL on saavutettavissa
- Tarkista tunnistautumistiedot
- Varmista verkkoyhteys

### 2. Työkalukutsujen epäonnistumiset
- Tarkista työkalujen argumentit ja muotoilu
- Selvitä palvelinkohtaiset vaatimukset
- Toteuta asianmukainen virheenkäsittely

### 3. Suorituskykyongelmat
- Optimoi työkalukutsujen tiheys
- Käytä välimuistia tarpeen mukaan
- Seuraa palvelimen vasteaikoja

## Seuraavat askeleet

MCP-integraation parantamiseksi:

1. **Tutustu omiin MCP-palvelimiin**: Rakenna omia MCP-palvelimia yksityisille tietolähteille
2. **Ota käyttöön edistynyt turvallisuus**: Lisää OAuth2- tai räätälöityjä tunnistautumismekanismeja
3. **Seuranta ja analytiikka**: Toteuta lokitus ja valvonta työkalujen käytölle
4. **Skaalaa ratkaisusi**: Harkitse kuormantasauksen ja hajautettujen MCP-palvelinarkkitehtuurien käyttöönottoa

## Lisäresurssit

- [Azure AI Foundryn dokumentaatio](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol -esimerkit](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundryn agenttien yleiskatsaus](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP-määritys](https://spec.modelcontextprotocol.io/)

## Tuki

Lisätukea ja kysymyksiä varten:
- Tutustu [Azure AI Foundryn dokumentaatioon](https://learn.microsoft.com/azure/ai-foundry/)
- Tarkista [MCP-yhteisön resurssit](https://modelcontextprotocol.io/)

## Mitä seuraavaksi

- [6. Yhteisön panokset](../../06-CommunityContributions/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Pyrimme tarkkuuteen, mutta huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäiskielellä on virallinen lähde. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinymmärryksistä tai tulkinnoista.