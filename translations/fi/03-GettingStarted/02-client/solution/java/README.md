<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:12:43+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "fi"
}
-->
# MCP Java Client - Laskin Demo

Tämä projekti havainnollistaa, miten luodaan Java-asiakas, joka yhdistyy MCP (Model Context Protocol) -palvelimeen ja kommunikoi sen kanssa. Tässä esimerkissä yhdistämme luvun 01 laskinpalvelimeen ja suoritetaan erilaisia matemaattisia operaatioita.

## Esivaatimukset

Ennen tämän asiakkaan käynnistämistä sinun tulee:

1. **Käynnistää Laskinpalvelin** luvusta 01:
   - Siirry laskinpalvelimen hakemistoon: `03-GettingStarted/01-first-server/solution/java/`
   - Käännä ja käynnistä laskinpalvelin:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - Palvelimen tulisi olla käynnissä osoitteessa `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `SDKClient` on Java-sovellus, joka näyttää miten:
- Yhdistetään MCP-palvelimeen Server-Sent Events (SSE) -kuljetuksella
- Luetellaan palvelimen käytettävissä olevat työkalut
- Kutsutaan erilaisia laskimen toimintoja etänä
- Käsitellään vastaukset ja näytetään tulokset

## Miten se toimii

Asiakas käyttää Spring AI MCP -kehystä seuraavasti:

1. **Yhdistämisen muodostaminen**: Luo WebFlux SSE -asiakaskuljetuksen yhdistääkseen laskinpalvelimeen
2. **Asiakkaan alustaminen**: Määrittää MCP-asiakkaan ja muodostaa yhteyden
3. **Työkalujen löytäminen**: Listaa kaikki käytettävissä olevat laskinoperaatiot
4. **Operaatioiden suorittaminen**: Kutsuu erilaisia matemaattisia funktioita esimerkkidatalla
5. **Tulosten näyttäminen**: Näyttää kunkin laskutoimituksen tulokset

## Projektin rakenne

```
src/
└── main/
    └── java/
        └── com/
            └── microsoft/
                └── mcp/
                    └── sample/
                        └── client/
                            └── SDKClient.java    # Main client implementation
```

## Keskeiset riippuvuudet

Projekti käyttää seuraavia keskeisiä riippuvuuksia:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

Tämä riippuvuus tarjoaa:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - SSE-kuljetus verkkopohjaiseen viestintään
- MCP-protokollan skeemat sekä pyyntö- ja vastaustyypit

## Projektin kääntäminen

Käännä projekti Maven-wrapperilla:

```cmd
.\mvnw clean install
```

## Asiakkaan käynnistäminen

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Huomio**: Varmista, että laskinpalvelin on käynnissä osoitteessa `http://localhost:8080` before executing any of these commands.

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080`
2. **Listaa työkalut** - Näyttää kaikki käytettävissä olevat laskinoperaatiot
3. **Suorita laskutoimitukset**:
   - Yhteenlasku: 5 + 3 = 8
   - Vähennyslasku: 10 - 4 = 6
   - Kertolasku: 6 × 7 = 42
   - Jakolasku: 20 ÷ 4 = 5
   - Potenssi: 2^8 = 256
   - Neliöjuuri: √16 = 4
   - Absoluuttinen arvo: |-5.5| = 5.5
   - Ohje: Näyttää käytettävissä olevat operaatiot

## Odotettu tulos

```
Available Tools = ListToolsResult[tools=[Tool[name=add, description=Add two numbers together, ...], ...]]
Add Result = CallToolResult[content=[TextContent[text="5,00 + 3,00 = 8,00"]], isError=false]
Subtract Result = CallToolResult[content=[TextContent[text="10,00 - 4,00 = 6,00"]], isError=false]
Multiply Result = CallToolResult[content=[TextContent[text="6,00 * 7,00 = 42,00"]], isError=false]
Divide Result = CallToolResult[content=[TextContent[text="20,00 / 4,00 = 5,00"]], isError=false]
Power Result = CallToolResult[content=[TextContent[text="2,00 ^ 8,00 = 256,00"]], isError=false]
Square Root Result = CallToolResult[content=[TextContent[text="√16,00 = 4,00"]], isError=false]
Absolute Result = CallToolResult[content=[TextContent[text="|-5,50| = 5,50"]], isError=false]
Help = CallToolResult[content=[TextContent[text="Basic Calculator MCP Service\n\nAvailable operations:\n1. add(a, b) - Adds two numbers\n2. subtract(a, b) - Subtracts the second number from the first\n..."]], isError=false]
```

**Huomio**: Maven saattaa antaa varoituksia päättyvistä säikeistä - tämä on normaalia reaktiivisissa sovelluksissa eikä tarkoita virhettä.

## Koodin ymmärtäminen

### 1. Kuljetuksen määrittely
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```
Tämä luo SSE (Server-Sent Events) -kuljetuksen, joka yhdistää laskinpalvelimeen.

### 2. Asiakkaan luonti
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```
Luo synkronisen MCP-asiakkaan ja alustaa yhteyden.

### 3. Työkalujen kutsuminen
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```
Kutsuu "add"-työkalua parametreilla a=5.0 ja b=3.0.

## Vianmääritys

### Palvelin ei ole käynnissä
Jos saat yhteysvirheitä, varmista että luvun 01 laskinpalvelin on käynnissä:
```
Error: Connection refused
```
**Ratkaisu**: Käynnistä ensin laskinpalvelin.

### Portti on jo käytössä
Jos portti 8080 on varattu:
```
Error: Address already in use
```
**Ratkaisu**: Lopeta muut porttia 8080 käyttävät sovellukset tai muuta palvelimen porttia.

### Käännösvirheet
Jos kohtaat käännösvirheitä:
```cmd
.\mvnw clean install -DskipTests
```

## Lisätietoja

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**Vastuuvapauslauseke:**  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.