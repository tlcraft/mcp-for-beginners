<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac2459c0d5cc823922e3d9240a95028c",
  "translation_date": "2025-06-11T13:29:25+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/java/README.md",
  "language_code": "fi"
}
-->
# Calculator LLM Client

Java-sovellus, joka näyttää, miten LangChain4j:ta käytetään yhdistämään MCP (Model Context Protocol) -laskinpalveluun GitHub Models -integraation kanssa.

## Esivaatimukset

- Java 21 tai uudempi
- Maven 3.6+ (tai käytä mukana tulevaa Maven-wrapperia)
- GitHub-tili, jolla on pääsy GitHub Models -palveluun
- MCP-laskinpalvelu käynnissä osoitteessa `http://localhost:8080`

## GitHub-tokenin hankkiminen

Tämä sovellus käyttää GitHub Modelsia, joka vaatii GitHubin henkilökohtaisen käyttöoikeustunnuksen. Noudata näitä ohjeita saadaksesi tokenin:

### 1. Siirry GitHub Modelsiin
1. Mene osoitteeseen [GitHub Models](https://github.com/marketplace/models)
2. Kirjaudu sisään GitHub-tililläsi
3. Pyydä pääsy GitHub Modelsiin, jos et ole vielä tehnyt sitä

### 2. Luo henkilökohtainen käyttöoikeustunnus
1. Mene kohtaan [GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)](https://github.com/settings/tokens)
2. Klikkaa "Generate new token" → "Generate new token (classic)"
3. Anna tokenille kuvaava nimi (esim. "MCP Calculator Client")
4. Aseta vanhentumisaika tarpeen mukaan
5. Valitse seuraavat oikeudet:
   - `repo` (jos käytät yksityisiä repositorioita)
   - `user:email`
6. Klikkaa "Generate token"
7. **Tärkeää**: Kopioi token heti, sillä et näe sitä enää myöhemmin!

### 3. Aseta ympäristömuuttuja

#### Windows (Komentokehote):
```cmd
set GITHUB_TOKEN=your_github_token_here
```

#### Windows (PowerShell):
```powershell
$env:GITHUB_TOKEN="your_github_token_here"
```

#### macOS/Linux:
```bash
export GITHUB_TOKEN=your_github_token_here
```

## Asennus ja käyttöönotto

1. **Kloonaa tai siirry projektin hakemistoon**

2. **Asenna riippuvuudet**:
   ```cmd
   mvnw clean install
   ```
   Tai jos Maven on asennettu järjestelmään:
   ```cmd
   mvn clean install
   ```

3. **Aseta ympäristömuuttuja** (katso "GitHub-tokenin hankkiminen" yllä)

4. **Käynnistä MCP-laskinpalvelu**:
   Varmista, että luvun 1 MCP-laskinpalvelu on käynnissä osoitteessa `http://localhost:8080/sse`. Palvelun tulee olla käynnissä ennen asiakkaan käynnistämistä.

## Sovelluksen käynnistäminen

```cmd
mvnw clean package
java -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Mitä sovellus tekee

Sovellus näyttää kolme pääasiallista vuorovaikutusta laskinpalvelun kanssa:

1. **Yhteenlasku**: Laskee lukujen 24.5 ja 17.3 summan
2. **Neliöjuuri**: Laskee luvun 144 neliöjuuren
3. **Ohje**: Näyttää käytettävissä olevat laskinfunktiot

## Odotettu tulos

Onnistuneesti suoritettaessa näet tulosteen, joka näyttää suunnilleen tältä:

```
The sum of 24.5 and 17.3 is 41.8.
The square root of 144 is 12.
The calculator service provides the following functions: add, subtract, multiply, divide, sqrt, power...
```

## Vianetsintä

### Yleiset ongelmat

1. **"GITHUB_TOKEN environment variable not set"**
   - Varmista, että olet asettanut `GITHUB_TOKEN`-ympäristömuuttujan oikein

### Virheenkorjaus

Debug-lokin aktivoimiseksi lisää seuraava JVM-argumentti sovellusta käynnistäessäsi:
```cmd
java -Dlogging.level.dev.langchain4j=DEBUG -jar target\calculator-llm-client-0.0.1-SNAPSHOT.jar
```

## Konfigurointi

Sovellus on konfiguroitu seuraavasti:
- Käyttää GitHub Modelseja `gpt-4.1-nano` model
- Connect to MCP service at `http://localhost:8080/sse`
- Käyttää 60 sekunnin aikakatkaisua pyyntöihin
- Ottaa käyttöön pyyntöjen ja vastausten lokituksen virheenkorjausta varten

## Riippuvuudet

Projektissa käytetyt keskeiset riippuvuudet:
- **LangChain4j**: AI-integraatioon ja työkalujen hallintaan
- **LangChain4j MCP**: Model Context Protocolin tukeen
- **LangChain4j GitHub Models**: GitHub Models -integraatioon
- **Spring Boot**: Sovelluskehykseen ja riippuvuuksien injektointiin

## Lisenssi

Tämä projekti on lisensoitu Apache License 2.0 -lisenssillä - katso lisätiedot [LICENSE](../../../../../../03-GettingStarted/03-llm-client/solution/java/LICENSE) -tiedostosta.

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää auktoritatiivisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkintojen seurauksista.