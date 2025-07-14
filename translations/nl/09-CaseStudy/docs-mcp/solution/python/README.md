<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:41:49+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "nl"
}
-->
# Studieplangenerator met Chainlit & Microsoft Learn Docs MCP

## Vereisten

- Python 3.8 of hoger  
- pip (Python pakketbeheerder)  
- Internettoegang om verbinding te maken met de Microsoft Learn Docs MCP-server  

## Installatie

1. Clone deze repository of download de projectbestanden.  
2. Installeer de benodigde dependencies:  

   ```bash
   pip install -r requirements.txt
   ```

## Gebruik

### Scenario 1: Eenvoudige Vraag aan Docs MCP  
Een commandoregelclient die verbinding maakt met de Docs MCP-server, een vraag verstuurt en het resultaat afdrukt.

1. Voer het script uit:  
   ```bash
   python scenario1.py
   ```  
2. Voer je documentatievraag in bij de prompt.

### Scenario 2: Studieplangenerator (Chainlit Web App)  
Een webinterface (met Chainlit) waarmee gebruikers een gepersonaliseerd studieplan per week kunnen genereren voor elk technisch onderwerp.

1. Start de Chainlit-app:  
   ```bash
   chainlit run scenario2.py
   ```  
2. Open de lokale URL die in je terminal wordt weergegeven (bijv. http://localhost:8000) in je browser.  
3. Voer in het chatvenster je studiethema en het aantal weken in dat je wilt studeren (bijv. "AI-900 certificering, 8 weken").  
4. De app geeft een week-tot-week studieplan terug, inclusief links naar relevante Microsoft Learn-documentatie.

**Vereiste Omgevingsvariabelen:**  

Om Scenario 2 (de Chainlit webapp met Azure OpenAI) te gebruiken, moet je de volgende omgevingsvariabelen instellen in een `.env`-bestand in de `python`-map:  

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

Vul deze waarden in met je Azure OpenAI resourcegegevens voordat je de app start.

> **Tip:** Je kunt eenvoudig je eigen modellen implementeren met [Azure AI Foundry](https://ai.azure.com/).

### Scenario 3: In-Editor Docs met MCP Server in VS Code  

In plaats van van browser-tabblad te wisselen om documentatie te zoeken, kun je Microsoft Learn Docs direct in VS Code gebruiken via de MCP-server. Dit stelt je in staat om:  
- Documentatie te zoeken en lezen binnen VS Code zonder je programmeeromgeving te verlaten.  
- Documentatie te refereren en links direct in je README of cursusbestanden in te voegen.  
- GitHub Copilot en MCP samen te gebruiken voor een naadloze, AI-gestuurde documentatieworkflow.

**Voorbeelden van gebruik:**  
- Snel referentielinks toevoegen aan een README tijdens het schrijven van cursus- of projectdocumentatie.  
- Copilot gebruiken om code te genereren en MCP om direct relevante documentatie te vinden en te citeren.  
- Gefocust blijven in je editor en je productiviteit verhogen.

> [!IMPORTANT]  
> Zorg dat je een geldige [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) configuratie hebt in je werkruimte (locatie is `.vscode/mcp.json`).

## Waarom Chainlit voor Scenario 2?

Chainlit is een modern open-source framework voor het bouwen van conversatiegerichte webapplicaties. Het maakt het eenvoudig om chat-gebaseerde gebruikersinterfaces te creëren die verbinding maken met backendservices zoals de Microsoft Learn Docs MCP-server. Dit project gebruikt Chainlit om op een eenvoudige, interactieve manier gepersonaliseerde studieplannen in realtime te genereren. Met Chainlit kun je snel chattools bouwen en uitrollen die productiviteit en leren verbeteren.

## Wat Dit Doet

Deze app stelt gebruikers in staat om een gepersonaliseerd studieplan te maken door simpelweg een onderwerp en duur in te voeren. De app analyseert je invoer, vraagt relevante inhoud op bij de Microsoft Learn Docs MCP-server en organiseert de resultaten in een gestructureerd, week-tot-week plan. De aanbevelingen per week worden in de chat weergegeven, zodat je gemakkelijk je voortgang kunt volgen. De integratie zorgt ervoor dat je altijd de nieuwste en meest relevante leermaterialen krijgt.

## Voorbeeldvragen

Probeer deze vragen in het chatvenster om te zien hoe de app reageert:

- `AI-900 certificering, 8 weken`  
- `Leer Azure Functions, 4 weken`  
- `Azure DevOps, 6 weken`  
- `Data engineering op Azure, 10 weken`  
- `Microsoft security fundamentals, 5 weken`  
- `Power Platform, 7 weken`  
- `Azure AI services, 12 weken`  
- `Cloud architectuur, 9 weken`

Deze voorbeelden laten zien hoe flexibel de app is voor verschillende leerdoelen en tijdsperiodes.

## Referenties

- [Chainlit Documentatie](https://docs.chainlit.io/)  
- [MCP Documentatie](https://github.com/MicrosoftDocs/mcp)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.