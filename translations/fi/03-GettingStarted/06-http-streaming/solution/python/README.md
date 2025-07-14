<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4c4da5949611d91b06d8a5d450aae8d6",
  "translation_date": "2025-07-13T21:20:39+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/python/README.md",
  "language_code": "fi"
}
-->
# Tämän esimerkin suorittaminen

Tässä ohjeessa kerrotaan, miten ajetaan klassinen HTTP-streamauspalvelin ja -asiakas sekä MCP-streamauspalvelin ja -asiakas Pythonilla.

### Yleiskatsaus

- Määrität MCP-palvelimen, joka lähettää etenemisilmoituksia asiakkaalle prosessoidessaan kohteita.
- Asiakas näyttää jokaisen ilmoituksen reaaliajassa.
- Tämä opas kattaa vaatimukset, asennuksen, ajon ja vianmäärityksen.

### Vaatimukset

- Python 3.9 tai uudempi
- `mcp`-Python-paketti (asennus komennolla `pip install mcp`)

### Asennus ja käyttöönotto

1. Kloonaa repositorio tai lataa ratkaisun tiedostot.

   ```pwsh
   git clone https://github.com/microsoft/mcp-for-beginners
   ```

1. **Luo ja aktivoi virtuaaliympäristö (suositeltavaa):**

   ```pwsh
   python -m venv venv
   .\venv\Scripts\Activate.ps1  # On Windows
   # or
   source venv/bin/activate      # On Linux/macOS
   ```

1. **Asenna tarvittavat riippuvuudet:**

   ```pwsh
   pip install "mcp[cli]"
   ```

### Tiedostot

- **Palvelin:** [server.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/server.py)
- **Asiakas:** [client.py](../../../../../../03-GettingStarted/06-http-streaming/solution/python/client.py)

### Klassisen HTTP-streamauspalvelimen ajaminen

1. Siirry ratkaisun hakemistoon:

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```

2. Käynnistä klassinen HTTP-streamauspalvelin:

   ```pwsh
   python server.py
   ```

3. Palvelin käynnistyy ja näyttää:

   ```
   Starting FastAPI server for classic HTTP streaming...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### Klassisen HTTP-streamausasiakkaan ajaminen

1. Avaa uusi terminaali (aktivoi sama virtuaaliympäristö ja hakemisto):

   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py
   ```

2. Näet striimattuja viestejä tulostettuna peräkkäin:

   ```text
   Running classic HTTP streaming client...
   Connecting to http://localhost:8000/stream with message: hello
   --- Streaming Progress ---
   Processing file 1/3...
   Processing file 2/3...
   Processing file 3/3...
   Here's the file content: hello
   --- Stream Ended ---
   ```

### MCP-streamauspalvelimen ajaminen

1. Siirry ratkaisun hakemistoon:
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   ```
2. Käynnistä MCP-palvelin käyttäen streamable-http-siirtoa:
   ```pwsh
   python server.py mcp
   ```
3. Palvelin käynnistyy ja näyttää:
   ```
   Starting MCP server with streamable-http transport...
   INFO:     Uvicorn running on http://127.0.0.1:8000 (Press CTRL+C to quit)
   ```

### MCP-streamausasiakkaan ajaminen

1. Avaa uusi terminaali (aktivoi sama virtuaaliympäristö ja hakemisto):
   ```pwsh
   cd 03-GettingStarted/06-http-streaming/solution
   python client.py mcp
   ```
2. Näet ilmoitukset tulostettuna reaaliajassa, kun palvelin käsittelee kutakin kohdetta:
   ```
   Running MCP client...
   Starting client...
   Session ID before init: None
   Session ID after init: a30ab7fca9c84f5fa8f5c54fe56c9612
   Session initialized, ready to call tools.
   Received message: root=LoggingMessageNotification(...)
   NOTIFICATION: root=LoggingMessageNotification(...)
   ...
   Tool result: meta=None content=[TextContent(type='text', text='Processed files: file_1.txt, file_2.txt, file_3.txt | Message: hello from client')]
   ```

### Keskeiset toteutusvaiheet

1. **Luo MCP-palvelin käyttäen FastMCP:ta.**
2. **Määrittele työkalu, joka käsittelee listan ja lähettää ilmoituksia `ctx.info()` tai `ctx.log()` avulla.**
3. **Aja palvelin asetuksella `transport="streamable-http"`.**
4. **Toteuta asiakas, jolla on viestinkäsittelijä ilmoitusten näyttämiseen saapuessaan.**

### Koodin läpikäynti
- Palvelin käyttää asynkronisia funktioita ja MCP-kontekstia etenemispäivitysten lähettämiseen.
- Asiakas toteuttaa asynkronisen viestinkäsittelijän ilmoitusten ja lopputuloksen tulostamiseen.

### Vinkkejä ja vianmääritystä

- Käytä `async/await` ei-estävissä toiminnoissa.
- Käsittele aina poikkeukset sekä palvelimella että asiakkaalla luotettavuuden varmistamiseksi.
- Testaa useilla asiakkailla nähdäksesi reaaliaikaiset päivitykset.
- Jos kohtaat virheitä, tarkista Python-versiosi ja varmista, että kaikki riippuvuudet on asennettu.

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.