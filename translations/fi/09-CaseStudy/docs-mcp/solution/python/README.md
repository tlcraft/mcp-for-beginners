<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:41:35+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "fi"
}
-->
# Opintosuunnitelman generaattori Chainlitillä & Microsoft Learn Docs MCP:llä

## Vaatimukset

- Python 3.8 tai uudempi
- pip (Python-pakettien hallinta)
- Internet-yhteys Microsoft Learn Docs MCP -palvelimeen yhdistämistä varten

## Asennus

1. Kloonaa tämä repositorio tai lataa projektin tiedostot.
2. Asenna tarvittavat riippuvuudet:

   ```bash
   pip install -r requirements.txt
   ```

## Käyttö

### Tilanne 1: Yksinkertainen kysely Docs MCP:lle
Komentoriviasiakas, joka yhdistää Docs MCP -palvelimeen, lähettää kyselyn ja tulostaa vastauksen.

1. Suorita skripti:
   ```bash
   python scenario1.py
   ```
2. Kirjoita dokumentaatiokysymyksesi kehotteeseen.

### Tilanne 2: Opintosuunnitelman generaattori (Chainlit-verkkosovellus)
Verkkopohjainen käyttöliittymä (Chainlitillä), jonka avulla käyttäjät voivat luoda henkilökohtaisen, viikko kerrallaan etenevän opintosuunnitelman mille tahansa tekniselle aiheelle.

1. Käynnistä Chainlit-sovellus:
   ```bash
   chainlit run scenario2.py
   ```
2. Avaa paikallinen URL-osoite, joka näkyy terminaalissasi (esim. http://localhost:8000) selaimessasi.
3. Kirjoita chat-ikkunaan opiskeluaiheesi ja haluamasi opiskeluviikkojen määrä (esim. "AI-900 certification, 8 weeks").
4. Sovellus vastaa viikko kerrallaan etenevällä opintosuunnitelmalla, joka sisältää linkkejä asiaankuuluviin Microsoft Learn -dokumentaatioihin.

**Vaaditut ympäristömuuttujat:**

Käyttääksesi tilannetta 2 (Chainlit-verkkosovellus Azure OpenAI:lla), sinun tulee määrittää seuraavat ympäristömuuttujat `.env`-tiedostoon `python`-hakemistossa:

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

Täytä nämä arvot Azure OpenAI -resurssisi tiedoilla ennen sovelluksen käynnistämistä.

> **Tip:** Voit helposti ottaa omat mallit käyttöön [Azure AI Foundryn](https://ai.azure.com/) avulla.

### Tilanne 3: Dokumentaatio suoraan editorissa MCP-palvelimen avulla VS Codessa

Sen sijaan, että vaihtaisit selaimen välilehteä dokumentaation etsimiseksi, voit tuoda Microsoft Learn Docsin suoraan VS Codeen MCP-palvelimen avulla. Tämä mahdollistaa:
- Dokumentaation hakemisen ja lukemisen suoraan VS Codessa ilman, että sinun tarvitsee poistua koodausympäristöstä.
- Dokumentaation viittausten lisäämisen ja linkkien upottamisen suoraan README- tai kurssitiedostoihin.
- GitHub Copilotin ja MCP:n yhteiskäytön sujuvaan, tekoälyavusteiseen dokumentaatiotyöskentelyyn.

**Esimerkkikäyttötapaukset:**
- Lisää nopeasti viittauslinkkejä README-tiedostoon kurssia tai projektidokumentaatiota kirjoittaessasi.
- Käytä Copilotia koodin generointiin ja MCP:tä löytääksesi ja viitataksesi asiaankuuluviin dokumentteihin välittömästi.
- Pysy keskittyneenä editorissa ja tehosta tuottavuuttasi.

> [!IMPORTANT]
> Varmista, että sinulla on voimassa oleva [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) -konfiguraatio työtilassasi (sijainti on `.vscode/mcp.json`).

## Miksi Chainlit tilannetta 2 varten?

Chainlit on moderni avoimen lähdekoodin kehys keskustelupohjaisten web-sovellusten rakentamiseen. Sen avulla on helppo luoda chat-käyttöliittymiä, jotka yhdistävät taustapalveluihin kuten Microsoft Learn Docs MCP -palvelimeen. Tämä projekti käyttää Chainlitia tarjotakseen yksinkertaisen ja interaktiivisen tavan luoda henkilökohtaisia opintosuunnitelmia reaaliajassa. Chainlitin avulla voit nopeasti rakentaa ja ottaa käyttöön chat-pohjaisia työkaluja, jotka parantavat tuottavuutta ja oppimista.

## Mitä tämä tekee

Tämä sovellus antaa käyttäjille mahdollisuuden luoda henkilökohtainen opintosuunnitelma syöttämällä vain aiheen ja keston. Sovellus tulkitsee syötteesi, kysyy Microsoft Learn Docs MCP -palvelimelta asiaankuuluvaa sisältöä ja järjestää tulokset rakenteelliseksi, viikko kerrallaan eteneväksi suunnitelmaksi. Kunkin viikon suositukset näytetään chatissa, mikä helpottaa etenemisen seuraamista. Integraatio varmistaa, että saat aina uusimmat ja relevantit oppimateriaalit.

## Esimerkkikyselyt

Kokeile näitä kyselyjä chat-ikkunassa nähdäksesi, miten sovellus vastaa:

- `AI-900 certification, 8 weeks`
- `Learn Azure Functions, 4 weeks`
- `Azure DevOps, 6 weeks`
- `Data engineering on Azure, 10 weeks`
- `Microsoft security fundamentals, 5 weeks`
- `Power Platform, 7 weeks`
- `Azure AI services, 12 weeks`
- `Cloud architecture, 9 weeks`

Nämä esimerkit havainnollistavat sovelluksen joustavuutta eri oppimistavoitteisiin ja aikatauluihin.

## Lähteet

- [Chainlit Documentation](https://docs.chainlit.io/)
- [MCP Documentation](https://github.com/MicrosoftDocs/mcp)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.