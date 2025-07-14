<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:41:12+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "da"
}
-->
# Study Plan Generator med Chainlit & Microsoft Learn Docs MCP

## Forudsætninger

- Python 3.8 eller nyere  
- pip (Python pakkehåndtering)  
- Internetadgang for at kunne forbinde til Microsoft Learn Docs MCP-serveren  

## Installation

1. Klon dette repository eller download projektfilerne.  
2. Installer de nødvendige afhængigheder:  

   ```bash
   pip install -r requirements.txt
   ```

## Brug

### Scenario 1: Simpelt forespørgsel til Docs MCP  
En kommandolinjeklient, der forbinder til Docs MCP-serveren, sender en forespørgsel og udskriver resultatet.

1. Kør scriptet:  
   ```bash
   python scenario1.py
   ```  
2. Indtast dit dokumentationsspørgsmål ved prompten.

### Scenario 2: Study Plan Generator (Chainlit Web App)  
En webbaseret grænseflade (ved brug af Chainlit), som giver brugere mulighed for at generere en personlig, uge-for-uge studieplan for ethvert teknisk emne.

1. Start Chainlit-appen:  
   ```bash
   chainlit run scenario2.py
   ```  
2. Åbn den lokale URL, der vises i din terminal (f.eks. http://localhost:8000) i din browser.  
3. Indtast dit studiemne og antal uger, du vil studere (f.eks. "AI-900 certification, 8 uger") i chatvinduet.  
4. Appen svarer med en uge-for-uge studieplan, inklusive links til relevant Microsoft Learn-dokumentation.

**Påkrævede miljøvariabler:**  

For at bruge Scenario 2 (Chainlit webapp med Azure OpenAI) skal du sætte følgende miljøvariabler i en `.env`-fil i `python`-mappen:  

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

Udfyld disse værdier med dine Azure OpenAI-ressourcedetaljer, inden du kører appen.

> **Tip:** Du kan nemt udrulle dine egne modeller ved hjælp af [Azure AI Foundry](https://ai.azure.com/).

### Scenario 3: Docs i editoren med MCP-server i VS Code

I stedet for at skifte browserfaner for at søge dokumentation, kan du hente Microsoft Learn Docs direkte ind i VS Code via MCP-serveren. Det giver dig mulighed for at:  
- Søge og læse dokumentation i VS Code uden at forlade dit kode-miljø.  
- Referere dokumentation og indsætte links direkte i dine README- eller kursusfiler.  
- Bruge GitHub Copilot og MCP sammen for en problemfri, AI-drevet dokumentationsarbejdsgang.

**Eksempler på brug:**  
- Tilføj hurtigt referencelinks til en README, mens du skriver kursus- eller projekt-dokumentation.  
- Brug Copilot til at generere kode og MCP til straks at finde og citere relevant dokumentation.  
- Forbliv fokuseret i din editor og øg produktiviteten.

> [!IMPORTANT]  
> Sørg for, at du har en gyldig [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) konfiguration i dit workspace (placering er `.vscode/mcp.json`).

## Hvorfor Chainlit til Scenario 2?

Chainlit er et moderne open source-framework til at bygge samtalebaserede webapplikationer. Det gør det nemt at skabe chat-baserede brugerflader, der forbinder til backend-tjenester som Microsoft Learn Docs MCP-serveren. Dette projekt bruger Chainlit til at tilbyde en enkel, interaktiv måde at generere personlige studieplaner i realtid. Ved at udnytte Chainlit kan du hurtigt bygge og udrulle chatbaserede værktøjer, der øger produktivitet og læring.

## Hvad denne app gør

Denne app giver brugere mulighed for at oprette en personlig studieplan ved blot at indtaste et emne og en varighed. Appen analyserer din input, forespørger Microsoft Learn Docs MCP-serveren efter relevant indhold og organiserer resultaterne i en struktureret, uge-for-uge plan. Anbefalingerne for hver uge vises i chatten, så det er nemt at følge og holde styr på din fremgang. Integrationen sikrer, at du altid får de nyeste og mest relevante læringsressourcer.

## Eksempelspørgsmål

Prøv disse forespørgsler i chatvinduet for at se, hvordan appen svarer:

- `AI-900 certification, 8 uger`  
- `Learn Azure Functions, 4 uger`  
- `Azure DevOps, 6 uger`  
- `Data engineering on Azure, 10 uger`  
- `Microsoft security fundamentals, 5 uger`  
- `Power Platform, 7 uger`  
- `Azure AI services, 12 uger`  
- `Cloud architecture, 9 uger`

Disse eksempler viser appens fleksibilitet til forskellige læringsmål og tidsrammer.

## Referencer

- [Chainlit Documentation](https://docs.chainlit.io/)  
- [MCP Documentation](https://github.com/MicrosoftDocs/mcp)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.