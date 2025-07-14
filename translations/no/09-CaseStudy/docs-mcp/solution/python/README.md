<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:41:23+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "no"
}
-->
# Studieplan-generator med Chainlit & Microsoft Learn Docs MCP

## Forutsetninger

- Python 3.8 eller nyere
- pip (Python-pakkebehandler)
- Internett-tilgang for å koble til Microsoft Learn Docs MCP-serveren

## Installasjon

1. Klon dette depotet eller last ned prosjektfilene.
2. Installer de nødvendige avhengighetene:

   ```bash
   pip install -r requirements.txt
   ```

## Bruk

### Scenario 1: Enkel forespørsel til Docs MCP
En kommandolinjeklient som kobler til Docs MCP-serveren, sender en forespørsel og skriver ut resultatet.

1. Kjør skriptet:
   ```bash
   python scenario1.py
   ```
2. Skriv inn dokumentasjonsspørsmålet ditt når du blir bedt om det.

### Scenario 2: Studieplan-generator (Chainlit Web-app)
Et nettbasert grensesnitt (ved bruk av Chainlit) som lar brukere generere en personlig, uke-for-uke studieplan for ethvert teknisk emne.

1. Start Chainlit-appen:
   ```bash
   chainlit run scenario2.py
   ```
2. Åpne den lokale URL-en som vises i terminalen (f.eks. http://localhost:8000) i nettleseren din.
3. Skriv inn studietemaet ditt og antall uker du ønsker å studere i chattevinduet (f.eks. "AI-900 certification, 8 weeks").
4. Appen svarer med en uke-for-uke studieplan, inkludert lenker til relevant Microsoft Learn-dokumentasjon.

**Nødvendige miljøvariabler:**

For å bruke Scenario 2 (Chainlit web-app med Azure OpenAI), må du sette følgende miljøvariabler i en `.env`-fil i `python`-mappen:

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

Fyll inn disse verdiene med detaljene for din Azure OpenAI-ressurs før du kjører appen.

> **Tip:** Du kan enkelt distribuere dine egne modeller ved å bruke [Azure AI Foundry](https://ai.azure.com/).

### Scenario 3: Dokumentasjon i editor med MCP-server i VS Code

I stedet for å bytte nettleserfaner for å søke i dokumentasjon, kan du hente Microsoft Learn Docs direkte inn i VS Code ved hjelp av MCP-serveren. Dette gjør at du kan:
- Søke og lese dokumentasjon inne i VS Code uten å forlate kode-miljøet.
- Referere til dokumentasjon og sette inn lenker direkte i README- eller kursfiler.
- Bruke GitHub Copilot og MCP sammen for en sømløs, AI-drevet dokumentasjonsflyt.

**Eksempler på brukstilfeller:**
- Legg raskt til referanselenker i en README mens du skriver kurs- eller prosjektdokumentasjon.
- Bruk Copilot til å generere kode og MCP til å finne og sitere relevante dokumenter umiddelbart.
- Hold fokus i editoren og øk produktiviteten.

> [!IMPORTANT]
> Sørg for at du har en gyldig [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json)-konfigurasjon i arbeidsområdet ditt (plassering er `.vscode/mcp.json`).

## Hvorfor Chainlit for Scenario 2?

Chainlit er et moderne, åpen kildekode-rammeverk for å bygge samtalebaserte webapplikasjoner. Det gjør det enkelt å lage chattebaserte brukergrensesnitt som kobler til backend-tjenester som Microsoft Learn Docs MCP-serveren. Dette prosjektet bruker Chainlit for å tilby en enkel, interaktiv måte å generere personlige studieplaner i sanntid. Ved å bruke Chainlit kan du raskt bygge og distribuere chattebaserte verktøy som øker produktivitet og læring.

## Hva dette gjør

Denne appen lar brukere lage en personlig studieplan ved å bare skrive inn et emne og en varighet. Appen tolker inndataene dine, spør Microsoft Learn Docs MCP-serveren om relevant innhold, og organiserer resultatene i en strukturert, uke-for-uke plan. Anbefalingene for hver uke vises i chatten, noe som gjør det enkelt å følge og holde oversikt over fremgangen. Integrasjonen sikrer at du alltid får de nyeste og mest relevante læringsressursene.

## Eksempelspørringer

Prøv disse spørringene i chattevinduet for å se hvordan appen svarer:

- `AI-900 certification, 8 weeks`
- `Learn Azure Functions, 4 weeks`
- `Azure DevOps, 6 weeks`
- `Data engineering on Azure, 10 weeks`
- `Microsoft security fundamentals, 5 weeks`
- `Power Platform, 7 weeks`
- `Azure AI services, 12 weeks`
- `Cloud architecture, 9 weeks`

Disse eksemplene viser appens fleksibilitet for ulike læringsmål og tidsrammer.

## Referanser

- [Chainlit Documentation](https://docs.chainlit.io/)
- [MCP Documentation](https://github.com/MicrosoftDocs/mcp)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.