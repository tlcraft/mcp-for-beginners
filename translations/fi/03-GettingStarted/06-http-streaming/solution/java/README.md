<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:48:01+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "fi"
}
-->
# Calculator HTTP Streaming Demo

Tämä projekti esittelee HTTP-streamausta käyttäen Server-Sent Events (SSE) -tekniikkaa Spring Boot WebFluxin kanssa. Se koostuu kahdesta sovelluksesta:

- **Calculator Server**: reaktiivinen web-palvelu, joka suorittaa laskutoimituksia ja lähettää tulokset SSE:n avulla
- **Calculator Client**: asiakassovellus, joka vastaanottaa streamatun datan

## Vaatimukset

- Java 17 tai uudempi
- Maven 3.6 tai uudempi

## Projektin rakenne

```
java/
├── calculator-server/     # Spring Boot server with SSE endpoint
│   ├── src/main/java/com/example/calculatorserver/
│   │   ├── CalculatorServerApplication.java
│   │   └── CalculatorController.java
│   └── pom.xml
├── calculator-client/     # Spring Boot client application
│   ├── src/main/java/com/example/calculatorclient/
│   │   └── CalculatorClientApplication.java
│   └── pom.xml
└── README.md
```

## Miten se toimii

1. **Calculator Server** tarjoaa `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`
   - Kuluttaa streamatun vastauksen
   - Tulostaa jokaisen tapahtuman konsoliin

## Sovellusten käynnistäminen

### Vaihtoehto 1: Mavenin käyttö (suositeltu)

#### 1. Käynnistä Calculator Server

Avaa terminaali ja siirry palvelimen hakemistoon:

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

Palvelin käynnistyy osoitteeseen `http://localhost:8080`

Näet tulosteen, joka näyttää tältä:
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. Käynnistä Calculator Client

Avaa **uusi terminaali** ja siirry asiakkaan hakemistoon:

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

Asiakas yhdistää palvelimeen, suorittaa laskutoimituksen ja näyttää streamatut tulokset.

### Vaihtoehto 2: Java-komentojen suora käyttö

#### 1. Käännä ja käynnistä palvelin:

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. Käännä ja käynnistä asiakas:

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## Palvelimen manuaalinen testaus

Voit testata palvelinta myös selaimella tai curl-komennolla:

### Selaimella:
Vieraile osoitteessa: `http://localhost:8080/calculate?a=10&b=5&op=add`

### curl-komennolla:
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## Odotettu tulos

Kun ajat asiakasta, näet streamatun tulosteen, joka näyttää suunnilleen tältä:

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## Tuetut operaatiot

- `add` - Addition (a + b)
- `sub` - Subtraction (a - b)
- `mul` - Multiplication (a * b)
- `div` - Division (a / b, returns NaN if b = 0)

## API Reference

### GET /calculate

**Parameters:**
- `a` (required): First number (double)
- `b` (required): Second number (double)
- `op` (required): Operation (`add`, `sub`, `mul`, `div`)

**Response:**
- Content-Type: `text/event-stream`
- Palauttaa Server-Sent Events -viestejä laskutoimituksen etenemisestä ja tuloksesta

**Esimerkkipyyntö:**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**Esimerkkivastaus:**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## Vianmääritys

### Yleisiä ongelmia

1. **Portti 8080 on jo käytössä**
   - Lopeta muut sovellukset, jotka käyttävät porttia 8080
   - Tai muuta palvelimen porttia tiedostossa `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` jos palvelin on käynnissä taustaprosessina

## Teknologiat

- **Spring Boot 3.3.1** - Sovelluskehys
- **Spring WebFlux** - Reaktiivinen web-kehys
- **Project Reactor** - Reaktiivisten streamien kirjasto
- **Netty** - Ei-estävä I/O-palvelin
- **Maven** - Rakennustyökalu
- **Java 17+** - Ohjelmointikieli

## Seuraavat askeleet

Kokeile muokata koodia niin, että:

- Lisää lisää matemaattisia operaatioita
- Lisää virheenkäsittely virheellisille operaatioille
- Lisää pyyntöjen ja vastausten lokitus
- Toteuta autentikointi
- Lisää yksikkötestejä

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty tekoälypohjaisella käännöspalvelulla [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä voi esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.