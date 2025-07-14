<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-13T21:36:19+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "fi"
}
-->
# Palvelimen käyttäminen AI Toolkit -laajennuksesta Visual Studio Codeen

Kun rakennat tekoälyagenttia, kyse ei ole pelkästään älykkäiden vastausten tuottamisesta, vaan myös siitä, että agentillasi on kyky toimia. Tässä astuu kuvaan Model Context Protocol (MCP). MCP helpottaa agenttien pääsyä ulkoisiin työkaluihin ja palveluihin yhtenäisellä tavalla. Voit ajatella sitä kuin liittäisit agenttisi työkalupakkiin, jota se *todella* osaa käyttää.

Oletetaan, että yhdistät agentin laskin-MCP-palvelimeesi. Yhtäkkiä agenttisi voi suorittaa matemaattisia laskutoimituksia pelkän kehotteen, kuten ”Paljonko on 47 kertaa 89?”, perusteella – ilman, että sinun tarvitsee kovakoodata logiikkaa tai rakentaa omia rajapintoja.

## Yleiskatsaus

Tässä oppitunnissa käydään läpi, miten yhdistät laskin-MCP-palvelimen agenttiin [AI Toolkit](https://aka.ms/AIToolkit) -laajennuksella Visual Studio Codessa, jolloin agenttisi voi suorittaa matemaattisia operaatioita, kuten yhteenlaskua, vähennystä, kertolaskua ja jakolaskua luonnollisen kielen avulla.

AI Toolkit on tehokas Visual Studio Code -laajennus, joka helpottaa agenttien kehittämistä. AI-insinöörit voivat helposti rakentaa tekoälysovelluksia kehittämällä ja testaamalla generatiivisia malleja paikallisesti tai pilvessä. Laajennus tukee suurinta osaa nykyisistä generatiivisista malleista.

*Huom*: AI Toolkit tukee tällä hetkellä Pythonia ja TypeScriptiä.

## Oppimistavoitteet

Tämän oppitunnin jälkeen osaat:

- Käyttää MCP-palvelinta AI Toolkitin kautta.
- Määrittää agentin asetukset siten, että se löytää ja hyödyntää MCP-palvelimen tarjoamia työkaluja.
- Käyttää MCP-työkaluja luonnollisen kielen avulla.

## Lähestymistapa

Näin etenemme yleisellä tasolla:

- Luo agentti ja määritä sen järjestelmäkehotus.
- Luo MCP-palvelin, jossa on laskintyökalut.
- Yhdistä Agent Builder MCP-palvelimeen.
- Testaa agentin työkalujen kutsumista luonnollisen kielen avulla.

Hienoa, kun ymmärrämme kokonaisuuden, määritetään tekoälyagentti hyödyntämään ulkoisia työkaluja MCP:n kautta ja laajennetaan sen kykyjä!

## Esivaatimukset

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## Harjoitus: Palvelimen käyttäminen

Tässä harjoituksessa rakennat, ajat ja parannat tekoälyagenttia MCP-palvelimen työkaluilla Visual Studio Codessa AI Toolkitin avulla.

### -0- Esivaihe, lisää OpenAI GPT-4o -malli My Models -listaan

Harjoitus hyödyntää **GPT-4o** -mallia. Malli tulee lisätä **My Models** -listaan ennen agentin luomista.

![Kuvakaappaus mallin valintanäkymästä Visual Studio Coden AI Toolkit -laajennuksessa. Otsikkona "Find the right model for your AI Solution" ja alaotsikkona kehotus löytää, testata ja ottaa käyttöön AI-malleja. Alla ”Popular Models” -osiossa kuusi mallikorttia: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast) ja DeepSeek-R1 (Ollama-hosted). Jokaisessa kortissa on vaihtoehdot ”Add” ja ”Try in Playground”.](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.fi.png)

1. Avaa **AI Toolkit** -laajennus **Activity Bar** -palkista.
2. Valitse **Catalog**-osiosta **Models** avataksesi **Model Catalog** -näkymän uudessa editorin välilehdessä.
3. Kirjoita **Model Catalog** -hakupalkkiin **OpenAI GPT-4o**.
4. Klikkaa **+ Add** lisätäksesi mallin **My Models** -listalle. Varmista, että valittu malli on **Hosted by GitHub**.
5. Tarkista **Activity Bar** -palkista, että **OpenAI GPT-4o** näkyy listassa.

### -1- Luo agentti

**Agent (Prompt) Builder** mahdollistaa omien tekoälypohjaisten agenttien luomisen ja räätälöinnin. Tässä osiossa luot uuden agentin ja määrität sille mallin keskustelun moottoriksi.

![Kuvakaappaus "Calculator Agent" -rakentajasta AI Toolkit -laajennuksessa Visual Studio Codessa. Vasemmassa paneelissa valittuna malli "OpenAI GPT-4o (via GitHub)". Järjestelmäkehotus: "You are a professor in university teaching math." Käyttäjäkehotus: "Explain to me the Fourier equation in simple terms." Lisävalintoina painikkeet työkalujen lisäämiseen, MCP Serverin käyttöönottoon ja rakenteellisen tulosteen valintaan. Alhaalla sininen ”Run” -painike. Oikeassa paneelissa "Get Started with Examples" -osiossa kolme esimerkkitoimijaa: Web Developer (MCP Server, Second-Grade Simplifier, Dream Interpreter) lyhyine kuvauksineen.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.fi.png)

1. Avaa **AI Toolkit** -laajennus **Activity Bar** -palkista.
2. Valitse **Tools**-osiosta **Agent (Prompt) Builder** avataksesi sen uudessa editorin välilehdessä.
3. Klikkaa **+ New Agent** -painiketta. Laajennus käynnistää asennusvelhon **Command Palette** -ikkunassa.
4. Anna nimeksi **Calculator Agent** ja paina **Enter**.
5. Valitse **Agent (Prompt) Builder** -näkymässä **Model**-kenttään **OpenAI GPT-4o (via GitHub)** -malli.

### -2- Luo agentille järjestelmäkehotus

Kun agentin runko on luotu, on aika määrittää sen persoonallisuus ja tarkoitus. Tässä osiossa käytät **Generate system prompt** -toimintoa kuvaamaan agentin haluttua käyttäytymistä – tässä tapauksessa laskinagenttia – ja annat mallin kirjoittaa järjestelmäkehotuksen puolestasi.

![Kuvakaappaus "Calculator Agent" -näkymästä AI Toolkitissa Visual Studio Codessa, jossa avoinna modaalinen ikkuna nimeltä "Generate a prompt." Ikkunassa kerrotaan, että kehotepohja voidaan luoda jakamalla perustiedot, ja tekstikentässä on esimerkkikehote: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Alhaalla painikkeet "Close" ja "Generate". Taustalla näkyy osittain agentin asetukset, mukaan lukien valittu malli "OpenAI GPT-4o (via GitHub)" ja kentät system- ja user-promptille.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.fi.png)

1. **Prompts**-osiossa klikkaa **Generate system prompt** -painiketta. Tämä avaa kehoterakentajan, joka hyödyntää tekoälyä järjestelmäkehotuksen luomiseen.
2. Kirjoita **Generate a prompt** -ikkunaan: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. Klikkaa **Generate**. Näytön oikeaan alakulmaan ilmestyy ilmoitus, että järjestelmäkehotus luodaan. Kun luonti on valmis, kehotus näkyy **System prompt** -kentässä **Agent (Prompt) Builder** -näkymässä.
4. Tarkista **System prompt** ja muokkaa tarvittaessa.

### -3- Luo MCP-palvelin

Nyt kun olet määrittänyt agentin järjestelmäkehotuksen – joka ohjaa sen käyttäytymistä ja vastauksia – on aika varustaa agentti käytännön taidoilla. Tässä osiossa luot laskin-MCP-palvelimen, jossa on työkalut yhteenlaskuun, vähennykseen, kertolaskuun ja jakolaskuun. Tämä palvelin mahdollistaa agentin suorittaa reaaliaikaisia matemaattisia laskutoimituksia luonnollisen kielen kehotteiden perusteella.

![Kuvakaappaus Calculator Agent -näkymän alaosasta AI Toolkit -laajennuksessa Visual Studio Codessa. Näkyvissä laajennettavat valikot ”Tools” ja ”Structure output”, sekä alasvetovalikko ”Choose output format” asetettuna ”text”. Oikealla painike ”+ MCP Server” MCP-palvelimen lisäämiseen. Kuvakekuvake näkyy Tools-osiossa.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.fi.png)

AI Toolkit sisältää valmiita malleja, jotka helpottavat oman MCP-palvelimen luomista. Käytämme Python-mallia laskin-MCP-palvelimen luomiseen.

*Huom*: AI Toolkit tukee tällä hetkellä Pythonia ja TypeScriptiä.

1. **Agent (Prompt) Builder** -näkymän **Tools**-osiossa klikkaa **+ MCP Server** -painiketta. Laajennus käynnistää asennusvelhon **Command Palette** -ikkunassa.
2. Valitse **+ Add Server**.
3. Valitse **Create a New MCP Server**.
4. Valitse malliksi **python-weather**.
5. Valitse **Default folder** MCP-palvelinmallin tallennuskohteeksi.
6. Anna palvelimelle nimi: **Calculator**
7. Uusi Visual Studio Code -ikkuna avautuu. Valitse **Yes, I trust the authors**.
8. Avaa terminaali (**Terminal** > **New Terminal**) ja luo virtuaaliympäristö: `python -m venv .venv`
9. Aktivoi virtuaaliympäristö terminaalissa:
    1. Windows: `.venv\Scripts\activate`
    2. macOS/Linux: `source venv/bin/activate`
10. Asenna riippuvuudet terminaalissa: `pip install -e .[dev]`
11. **Explorer**-näkymässä laajenna **src**-hakemisto ja avaa **server.py** editorissa.
12. Korvaa **server.py** -tiedoston sisältö seuraavalla ja tallenna:

    ```python
    """
    Sample MCP Calculator Server implementation in Python.

    
    This module demonstrates how to create a simple MCP server with calculator tools
    that can perform basic arithmetic operations (add, subtract, multiply, divide).
    """
    
    from mcp.server.fastmcp import FastMCP
    
    server = FastMCP("calculator")
    
    @server.tool()
    def add(a: float, b: float) -> float:
        """Add two numbers together and return the result."""
        return a + b
    
    @server.tool()
    def subtract(a: float, b: float) -> float:
        """Subtract b from a and return the result."""
        return a - b
    
    @server.tool()
    def multiply(a: float, b: float) -> float:
        """Multiply two numbers together and return the result."""
        return a * b
    
    @server.tool()
    def divide(a: float, b: float) -> float:
        """
        Divide a by b and return the result.
        
        Raises:
            ValueError: If b is zero
        """
        if b == 0:
            raise ValueError("Cannot divide by zero")
        return a / b
    ```

### -4- Aja agentti laskin-MCP-palvelimen kanssa

Nyt kun agentillasi on työkalut, on aika käyttää niitä! Tässä osiossa lähetät kehotteita agentille testataksesi ja varmistaaksesi, että agentti hyödyntää oikeaa työkalua laskin-MCP-palvelimelta.

![Kuvakaappaus Calculator Agent -näkymästä AI Toolkit -laajennuksessa Visual Studio Codessa. Vasemmassa paneelissa “Tools”-osiossa lisättynä MCP-palvelin nimeltä local-server-calculator_server, jossa neljä työkalua: add, subtract, multiply ja divide. Neljä työkalua on aktiivisena. Alla on suljettu ”Structure output” -osio ja sininen ”Run” -painike. Oikeassa paneelissa ”Model Response” -osiossa agentti kutsuu multiply- ja subtract-työkaluja syötteillä {"a": 3, "b": 25} ja {"a": 75, "b": 20}. Lopullinen ”Tool Response” on 75.0. Alhaalla näkyy ”View Code” -painike.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.fi.png)

Ajetaan laskin-MCP-palvelin paikallisella kehityskoneellasi **Agent Builderin** kautta MCP-asiakkaana.

1. Paina `F5` käynnistääksesi MCP-palvelimen debuggaustilan. **Agent (Prompt) Builder** avautuu uuteen editorin välilehteen. Palvelimen tila näkyy terminaalissa.
2. Kirjoita **User prompt** -kenttään **Agent (Prompt) Builderissa** seuraava kehotus: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
3. Klikkaa **Run**-painiketta luodaksesi agentin vastauksen.
4. Tarkista agentin vastaus. Mallin pitäisi päätellä, että maksoit **55 dollaria**.
5. Tässä mitä tapahtuu:
    - Agentti valitsee **multiply** ja **subtract** -työkalut laskutoimituksen avuksi.
    - Työkaluille annetaan arvot `a` ja `b` vastaavasti.
    - Kunkin työkalun vastaus näkyy **Tool Response** -kentässä.
    - Mallin lopullinen vastaus näkyy **Model Response** -kentässä.
6. Lähetä lisää kehotteita testataksesi agenttia. Voit muokata nykyistä kehotetta klikkaamalla **User prompt** -kenttää ja korvaamalla sen.
7. Kun olet valmis, voit lopettaa palvelimen terminaalissa painamalla **CTRL/CMD+C**.

## Tehtävä

Kokeile lisätä uusi työkaluerä **server.py** -tiedostoon (esim. neliöjuuren laskeminen). Lähetä agentille kehotteita, jotka vaativat uuden tai olemassa olevan työkalun käyttöä. Muista käynnistää palvelin uudelleen, jotta uudet työkalut latautuvat.

## Ratkaisu

[Solution](./solution/README.md)

## Tärkeimmät opit

Tämän luvun tärkeimmät opit ovat:

- AI Toolkit -laajennus on erinomainen asiakas, joka mahdollistaa MCP-palvelimien ja niiden työkalujen käytön.
- MCP-palvelimiin voi lisätä uusia työkaluja, jolloin agentin kyvyt laajenevat muuttuvien tarpeiden mukaan.
- AI Toolkit sisältää malleja (esim. Python MCP -palvelinmallit), jotka helpottavat omien työkalujen luomista.

## Lisäresurssit

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## Mitä seuraavaksi
- Seuraava: [Testing & Debugging](../08-testing/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.