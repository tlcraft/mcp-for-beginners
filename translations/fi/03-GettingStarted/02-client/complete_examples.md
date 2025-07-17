<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "affcf199a44f60283a289dcb69dc144e",
  "translation_date": "2025-07-17T09:11:18+00:00",
  "source_file": "03-GettingStarted/02-client/complete_examples.md",
  "language_code": "fi"
}
-->
# Täydelliset MCP-asiakasohjelmaesimerkit

Tämä hakemisto sisältää täydellisiä, toimivia esimerkkejä MCP-asiakasohjelmista eri ohjelmointikielillä. Jokainen asiakasohjelma esittelee kaikki pää-README.md-oppaassa kuvatut toiminnot.

## Saatavilla olevat asiakasohjelmat

### 1. Java-asiakas (`client_example_java.java`)
- **Kuljetus**: SSE (Server-Sent Events) HTTP:n yli
- **Kohdepalvelin**: `http://localhost:8080`
- **Ominaisuudet**: 
  - Yhteyden muodostus ja ping
  - Työkalujen listaus
  - Laskinoperaatiot (yhteenlasku, vähennys, kertolasku, jakolasku, ohje)
  - Virheenkäsittely ja tulosten poiminta

**Suorita:**
```bash
# Ensure your MCP server is running on localhost:8080
javac client_example_java.java
java client_example_java
```

### 2. C#-asiakas (`client_example_csharp.cs`)
- **Kuljetus**: Stdio (standardisyöte/-tulo)
- **Kohdepalvelin**: Paikallinen .NET MCP -palvelin dotnet run -komennolla
- **Ominaisuudet**:
  - Palvelimen automaattinen käynnistys stdio-kuljetuksen kautta
  - Työkalujen ja resurssien listaus
  - Laskinoperaatiot
  - JSON-tulosten jäsentäminen
  - Laaja virheenkäsittely

**Suorita:**
```bash
dotnet run
```

### 3. TypeScript-asiakas (`client_example_typescript.ts`)
- **Kuljetus**: Stdio (standardisyöte/-tulo)
- **Kohdepalvelin**: Paikallinen Node.js MCP -palvelin
- **Ominaisuudet**:
  - Täysi MCP-protokollan tuki
  - Työkalujen, resurssien ja kehotteiden käsittely
  - Laskinoperaatiot
  - Resurssien lukeminen ja kehotteiden suoritus
  - Vankka virheenkäsittely

**Suorita:**
```bash
# First compile TypeScript (if needed)
npm run build

# Then run the client
npm run client
# or
node client_example_typescript.js
```

### 4. Python-asiakas (`client_example_python.py`)
- **Kuljetus**: Stdio (standardisyöte/-tulo)  
- **Kohdepalvelin**: Paikallinen Python MCP -palvelin
- **Ominaisuudet**:
  - Async/await-malli operaatioihin
  - Työkalujen ja resurssien löytäminen
  - Laskinoperaatioiden testaus
  - Resurssien sisällön lukeminen
  - Luokkapohjainen rakenne

**Suorita:**
```bash
python client_example_python.py
```

## Yleiset ominaisuudet kaikissa asiakasohjelmissa

Jokainen asiakasohjelma toteuttaa:

1. **Yhteyden hallinta**
   - Yhteyden muodostaminen MCP-palvelimeen
   - Yhteysvirheiden käsittely
   - Asianmukainen siivous ja resurssien hallinta

2. **Palvelimen löytäminen**
   - Saatavilla olevien työkalujen listaus
   - Saatavilla olevien resurssien listaus (missä tuettu)
   - Saatavilla olevien kehotteiden listaus (missä tuettu)

3. **Työkalujen kutsuminen**
   - Peruslaskinoperaatiot (yhteenlasku, vähennys, kertolasku, jakolasku)
   - Ohjekomento palvelintiedolle
   - Oikea argumenttien välitys ja tulosten käsittely

4. **Virheenkäsittely**
   - Yhteysvirheet
   - Työkalujen suoritusvirheet
   - Hallittu epäonnistuminen ja käyttäjäpalautteen antaminen

5. **Tulosten käsittely**
   - Tekstisisällön poiminta vastauksista
   - Tulosteen muotoilu luettavaksi
   - Eri vastausformaatteihin sopeutuminen

## Esivaatimukset

Ennen näiden asiakasohjelmien suorittamista varmista, että:

1. **Vastaava MCP-palvelin on käynnissä** (kansiosta `../01-first-server/`)
2. **Tarvittavat riippuvuudet on asennettu** valitsemallesi kielelle
3. **Verkkoyhteys toimii oikein** (HTTP-pohjaisille kuljetuksille)

## Toteutusten keskeiset erot

| Kieli      | Kuljetus | Palvelimen käynnistys | Async-malli | Keskeiset kirjastot |
|------------|----------|----------------------|-------------|---------------------|
| Java       | SSE/HTTP | Ulkoinen             | Synkroninen | WebFlux, MCP SDK    |
| C#         | Stdio    | Automaattinen        | Async/Await | .NET MCP SDK        |
| TypeScript | Stdio    | Automaattinen        | Async/Await | Node MCP SDK        |
| Python     | Stdio    | Automaattinen        | AsyncIO     | Python MCP SDK      |

## Seuraavat askeleet

Tutustuttuasi näihin asiakasohjelmaesimerkkeihin:

1. **Muokkaa asiakkaita** lisätäksesi uusia ominaisuuksia tai toimintoja
2. **Luo oma palvelimesi** ja testaa sitä näillä asiakasohjelmilla
3. **Kokeile eri kuljetuksia** (SSE vs. Stdio)
4. **Rakenna monimutkaisempi sovellus**, joka integroi MCP-toiminnallisuuden

## Vianetsintä

### Yleiset ongelmat

1. **Yhteys evätty**: Varmista, että MCP-palvelin on käynnissä odotetulla portilla/polulla
2. **Moduulia ei löydy**: Asenna tarvittava MCP SDK valitsemallesi kielelle
3. **Lupa evätty**: Tarkista tiedostojen käyttöoikeudet stdio-kuljetukselle
4. **Työkalua ei löydy**: Varmista, että palvelin tukee odotettuja työkaluja

### Vianetsintävinkit

1. **Ota käyttöön yksityiskohtainen lokitus** MCP SDK:ssasi
2. **Tarkista palvelimen lokit** virheilmoitusten varalta
3. **Varmista työkalujen nimet ja allekirjoitukset** vastaavat asiakasohjelmassa ja palvelimella
4. **Testaa ensin MCP Inspectorilla** palvelimen toimivuuden varmistamiseksi

## Liittyvä dokumentaatio

- [Pääasiakasopas](./README.md)
- [MCP-palvelinesimerkit](../../../../03-GettingStarted/01-first-server)
- [MCP LLM-integraatiolla](../../../../03-GettingStarted/03-llm-client)
- [Virallinen MCP-dokumentaatio](https://modelcontextprotocol.io/)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.