<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "13231e9951b68efd9df8c56bd5cdb27e",
  "translation_date": "2025-05-29T20:22:03+00:00",
  "source_file": "03-GettingStarted/samples/java/calculator/README.md",
  "language_code": "br"
}
-->
# Basic Calculator MCP Service

Ar servijh-mañ a ginnig operadoù kalkul simpl war-lerc’h Model Context Protocol (MCP) en ur ober gant Spring Boot hag ar transport WebFlux. Emañ bet krouet evel un enklask simpl evit an dud o kregiñ da zeskiñ ar c’hemmoù MCP.

Evit muioc’h a ditouroù, sellit ouzh an [MCP Server Boot Starter](https://docs.spring.io/spring-ai/reference/api/mcp/mcp-server-boot-starter-docs.html) e-barzh an dastumad titouroù.

## Dielfennañ

Ar servij a zispleg:
- Sikour evit SSE (Server-Sent Events)
- Enrollañ emgefreek an ostilhoù dre implij ar notenn `@Tool` eus Spring AI
- Oberadoù kalkul diazez:
  - Ouzhpennañ, digreskañ, liessevel, rannañ
  - Kalkuliñ ar galloud ha gwask karrez
  - Modulus (gwashadenn) hag an talvoud gwellañ
  - Oberenn sikour evit deskrivañ an oberadoù

## Perzhioù

Ar servij kalkul-mañ a ginnig an tuioù da-heul:

1. **Operadoù Arithmetik Diazez**:
   - Ouzhpennañ daou niverenn
   - Digreskañ ur niverenn eus unan all
   - Liessevel daou niverenn
   - Rannañ ur niverenn gant unan all (gwareziñ ouzh rannadenn dre zero)

2. **Operadoù Kevredet**:
   - Kalkuliñ galloud (digeriñ ur bazenn d’ur goumoul)
   - Gwask karrez (gwareziñ ouzh niverenn negativ)
   - Kalkuliñ gwashadenn (modulus)
   - Kalkuliñ talvoud gwellañ (valeur absolue)

3. **Sistem Sikour**:
   - Oberenn sikour enno evit displegañ an holl operadoù a zo

## Implij ar Servij

Ar servij a zispleg an API da-heul dre ar protokol MCP:

- `add(a, b)`: Ouzhpennañ daou niverenn
- `subtract(a, b)`: Digreskañ an eil niverenn eus ar pezh kentañ
- `multiply(a, b)`: Liessevel daou niverenn
- `divide(a, b)`: Rannañ ar pezh kentañ gant an eil (gwareziñ ouzh zero)
- `power(base, exponent)`: Kalkuliñ galloud ur niverenn
- `squareRoot(number)`: Kalkuliñ gwask karrez (gwareziñ ouzh niverenn negativ)
- `modulus(a, b)`: Kalkuliñ gwashadenn
- `absolute(number)`: Kalkuliñ talvoud gwellañ
- `help()`: Kaout titouroù diwar-benn an operadoù a zo

## Klient Amprouiñ

Ur klient amprouiñ simpl zo e-barzh ar pakad `com.microsoft.mcp.sample.client`. Ar klas `SampleCalculatorClient` a zispleg an operadoù a zo d’ar servij kalkul.

## Implij ar LangChain4j Client

Ar raktres a ginnig un enklask LangChain4j e-barzh `com.microsoft.mcp.sample.client.LangChain4jClient` evit diskouez penaos en em staliañ gant ar servij kalkul hag ar modeloù GitHub:

### Goulennadoù

1. **Krouiñ Token GitHub**:
   
Evit implij ar modeloù AI GitHub (evel phi-4), ezhomm eus ur token personel:

a. Mont d'an arventennoù ho kont GitHub: https://github.com/settings/tokens
   
b. Klickit war "Generate new token" → "Generate new token (classic)"
   
c. Roiñ ur anv deskrivadek d'ho token
   
d. Dibabit an doareoù da-heul:
   - `repo` (kontroll hollek eus ar c'hrouadoù prevez)
   - `read:org` (lenn membership ar c'hrouadoù ha ar skipailhoù, lenn raktresoù ar c'hrouadoù)
   - `gist` (krouiñ gists)
   - `user:email` (kaout miret war an emlioù postel ar implijerien)
   
e. Klickit war "Generate token" ha kemerit ho token nevez
   
f. Savit evel un argemm evit an endro:
   
   War Windows:
   ```
      set GITHUB_TOKEN=your-github-token
      ```
   
   War macOS/Linux:
   ```bash
      export GITHUB_TOKEN=your-github-token
      ```

g. Evit ma vefe stabil, ouzhpennañ anezhañ d'ho argemmoù endro dre an arventennoù sistem

2. Ouzhpennañ ar meneg LangChain4j GitHub d'ho raktres (enrollet e-barzh pom.xml):
   ```xml
   <dependency>
       <groupId>dev.langchain4j</groupId>
       <artifactId>langchain4j-github</artifactId>
       <version>${langchain4j.version}</version>
   </dependency>
   ```

3. Gwiriit e vez mont war-raok ar servij kalkul war `localhost:8080`

### Redañ ar LangChain4j Client

Ar pezh-mañ a zispleg:
- Kevreañ gant ar servij MCP kalkul dre ar transport SSE
- Implij LangChain4j evit krouiñ ur bot kelaouiñ o implijout an operadoù kalkul
- Kevreañ gant modeloù AI GitHub (implijet bremañ ar model phi-4)

Ar klient a kas ar c’hinnigioù da-heul evit diskouez ar geflusk:
1. Kalkuliñ ouzhpennañ daou niverenn
2. Klask gwask karrez ur niverenn
3. Kaout titouroù sikour diwar-benn an operadoù kalkul

Renañ an enklask ha sellit ouzh ar c’hontrol evit gwelet penaos ar model AI a implij ar servijoù kalkul evit respont d’ar goulenn.

### Merañ ar Model GitHub

Ar LangChain4j client a zo meret evit implij ar model phi-4 GitHub gant ar savadurioù da-heul:

```java
ChatLanguageModel model = GitHubChatModel.builder()
    .apiKey(System.getenv("GITHUB_TOKEN"))
    .timeout(Duration.ofSeconds(60))
    .modelName("phi-4")
    .logRequests(true)
    .logResponses(true)
    .build();
```

Evit implij modeloù GitHub all, kemmit hepken ar parameter `modelName` d’ur model all (e.g. "claude-3-haiku-20240307", "llama-3-70b-8192", hag all).

## Menegadennoù

Ar raktres ezhomm ar meneg da-heul:

```xml
<!-- For MCP Server -->
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>

<!-- For LangChain4j integration -->
<dependency>
    <groupId>dev.langchain4j</groupId>
    <artifactId>langchain4j-mcp</artifactId>
    <version>${langchain4j.version}</version>
</dependency>

<!-- For GitHub models support -->
<dependency>
    <groupId>dev.langchain4j</groupId>
    <artifactId>langchain4j-github</artifactId>
    <version>${langchain4j.version}</version>
</dependency>
```

## Sevel ar Raktres

Sevit ar raktres gant Maven:
```bash
./mvnw clean install -DskipTests
```

## Redañ ar Servij

### Implij Java

```bash
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

### Implij MCP Inspector

MCP Inspector zo ur benveg talvoudus evit ober gant servijoù MCP. Evit implij anezhañ gant ar servij kalkul-mañ:

1. **Krouiñ ha redañ MCP Inspector** e-barzh ur prenestr termenal nevez:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Mont war-zu ar web UI** dre klick war ar URL a vez diskouezet gant ar benveg (dastumad http://localhost:6274)

3. **Kemmañ ar kevreañ**:
   - Savit ar mod transport da "SSE"
   - Savit ar URL da ar servij SSE a vez o redek: `http://localhost:8080/sse`
   - Klickit war "Connect"

4. **Implij ar c’hinnigoù**:
   - Klickit war "List Tools" evit gwelet an operadoù kalkul a zo
   - Dibabit ur c’hinnig ha klickit war "Run Tool" evit ober an oberenn

![MCP Inspector Screenshot](../../../../../../translated_images/tool.c75a0b2380efcf1a47a8478f54380a36ddcca7943b98f56dabbac8b07e15c3bb.br.png)

### Implij Docker

Ar raktres a ginnig ur Dockerfile evit kenderc’hel ar servij en ur kontener:

1. **Sevel an dresenn Docker**:
   ```bash
   docker build -t calculator-mcp-service .
   ```

2. **Redañ ar kontener Docker**:
   ```bash
   docker run -p 8080:8080 calculator-mcp-service
   ```

Ar pezh-mañ a:
- Sevel ur dresenn Docker e meur a live gant Maven 3.9.9 ha Eclipse Temurin 24 JDK
- Krouiñ ur skeudenn optimizet evit ar kontener
- Diskouez ar servij war port 8080
- Kregiñ ar servij kalkul MCP e-barzh ar kontener

Gallout a rit mont da ar servij war `http://localhost:8080` goude ma vez o redek ar kontener.

## Diwallerezh

### Kudennoù a Vez Aet da Veur War ar Token GitHub

1. **Kudennoù a-bouez gant ar perzhioù token**: Ma kavez fazi 403 Forbidden, gwelit ma vez ar perzhioù token reizh evel ma vez diskouezet e-barzh an dafar goulennet.

2. **Token N’eo Ket Kavet**: Ma kavez fazi "No API key found", gwelit ma vez ar GITHUB_TOKEN e-barzh an argemmoù endro savet mat.

3. **Limitadennoù Aotre GitHub**: Ar API GitHub a zo gant limitadennoù. Ma kavez fazi 429 (rate limit), gortozit ur pennadig a-raok klask en-dro.

4. **Dizober Token**: Ar token GitHub a c’hall dizober. Ma kavez fazi autentikadur goude un amzer, krouit ur token nevez ha hizivit an argemm endro.

Mar bez ezhomm sikour ouzhpenn, sellit ouzh ar [LangChain4j documentation](https://github.com/langchain4j/langchain4j) pe ouzh an [GitHub API documentation](https://docs.github.com/en/rest).

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se a tradução profissional feita por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.