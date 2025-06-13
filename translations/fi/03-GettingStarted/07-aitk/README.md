<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-13T02:22:52+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "fi"
}
-->
# Palvelimen käyttäminen AI Toolkit -laajennuksesta Visual Studio Codessa

Kun rakennat tekoälyagenttia, kyse ei ole pelkästään älykkäiden vastausten tuottamisesta, vaan myös agentin kyvystä toimia. Tässä astuu kuvaan Model Context Protocol (MCP). MCP helpottaa agenttien pääsyä ulkoisiin työkaluihin ja palveluihin johdonmukaisella tavalla. Voit ajatella sitä kuin liittäisit agenttisi työkalupakkiin, jota se *todella* osaa käyttää.

Oletetaan, että yhdistät agentin laskin-MCP-palvelimeesi. Yhtäkkiä agenttisi voi suorittaa matemaattisia laskutoimituksia pelkän kehotteen, kuten ”Paljonko on 47 kertaa 89?” perusteella—ilman että sinun tarvitsee kovakoodata logiikkaa tai rakentaa omia rajapintoja.

## Yleiskatsaus

Tässä oppitunnissa käydään läpi, miten yhdistää laskin-MCP-palvelin agenttiin AI Toolkit -laajennuksen avulla Visual Studio Codessa, jolloin agentti pystyy suorittamaan matemaattisia operaatioita, kuten yhteen- ja vähennyslaskua, kertolaskua ja jakolaskua luonnollisen kielen avulla.

AI Toolkit on tehokas Visual Studio Code -laajennus, joka sujuvoittaa agenttien kehitystä. AI-insinöörit voivat helposti rakentaa tekoälysovelluksia kehittämällä ja testaamalla generatiivisia malleja—paikallisesti tai pilvessä. Laajennus tukee suurinta osaa tämänhetkisistä suosituista generatiivisista malleista.

*Huom*: AI Toolkit tukee tällä hetkellä Pythonia ja TypeScriptiä.

## Oppimistavoitteet

Tämän oppitunnin jälkeen osaat:

- Käyttää MCP-palvelinta AI Toolkitin kautta.
- Määrittää agentin asetukset niin, että se löytää ja käyttää MCP-palvelimen tarjoamia työkaluja.
- Hyödyntää MCP-työkaluja luonnollisen kielen avulla.

## Lähestymistapa

Näin etenemme pääpiirteittäin:

- Luo agentti ja määritä sen järjestelmäkehotus.
- Luo MCP-palvelin, jossa on laskintyökalut.
- Yhdistä Agent Builder MCP-palvelimeen.
- Testaa agentin työkalujen kutsuminen luonnollisella kielellä.

Hienoa, nyt kun ymmärrämme kokonaisuuden, määritetään tekoälyagentti käyttämään ulkoisia työkaluja MCP:n kautta ja näin laajennetaan sen kyvykkyyksiä!

## Esivaatimukset

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## Harjoitus: Palvelimen käyttäminen

Tässä harjoituksessa rakennat, ajat ja parannat tekoälyagenttia, joka hyödyntää MCP-palvelimen työkaluja Visual Studio Codessa AI Toolkitin avulla.

### -0- Esivaihe: Lisää OpenAI GPT-4o -malli My Models -kansioon

Harjoitus käyttää **GPT-4o** -mallia. Malli tulee lisätä **My Models** -kansioon ennen agentin luontia.

![Kuva AI Toolkitin mallivalintanäkymästä Visual Studio Codessa. Otsikkona "Find the right model for your AI Solution" ja alaotsikkona kehotus löytää, testata ja ottaa käyttöön malleja. Näytöllä kuusi mallikorttia: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), ja DeepSeek-R1 (Ollama-hosted). Jokaisessa kortissa vaihtoehdot "Add" ja "Try in Playground".](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.fi.png)

1. Avaa **AI Toolkit** -laajennus **Activity Bar**sta.
1. Valitse **Catalog**-osiosta **Models** avataksesi **Model Catalog** -näkymän uudessa editorin välilehdessä.
1. Kirjoita **Model Catalog** -hakupalkkiin **OpenAI GPT-4o**.
1. Klikkaa **+ Add** lisätäksesi mallin **My Models** -listalle. Varmista, että valitsemasi malli on **Hosted by GitHub**.
1. Tarkista **Activity Bar**sta, että **OpenAI GPT-4o** näkyy listassa.

### -1- Luo agentti

**Agent (Prompt) Builder** -työkalulla voit luoda ja muokata omia tekoälyagenttejasi. Tässä osassa luot uuden agentin ja valitset mallin, joka ohjaa keskustelua.

![Kuva "Calculator Agent" -rakentajasta AI Toolkit -laajennuksessa Visual Studio Codessa. Vasemmalla paneelissa valittuna malli "OpenAI GPT-4o (via GitHub)." Järjestelmäkehotus: "You are a professor in university teaching math," käyttäjäkehotus: "Explain to me the Fourier equation in simple terms." Lisäasetuksina painikkeet työkalujen lisäämiseen, MCP Serverin aktivointiin ja rakenteellisen tulosteen valintaan. Alhaalla sininen "Run"-painike. Oikealla paneelissa kolme esimerkkiaihetta: Web Developer (MCP Server, Second-Grade Simplifier, Dream Interpreter) lyhyillä kuvauksilla.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.fi.png)

1. Avaa **AI Toolkit** -laajennus **Activity Bar**sta.
1. Valitse **Tools**-osiosta **Agent (Prompt) Builder**. Tämä avaa uuden editorivälilehden.
1. Klikkaa **+ New Agent** -painiketta. Laajennus avaa asennusvelhon **Command Paletten** kautta.
1. Anna nimeksi **Calculator Agent** ja paina **Enter**.
1. **Agent (Prompt) Builderissa** valitse **Model**-kenttään **OpenAI GPT-4o (via GitHub)**.

### -2- Luo agentille järjestelmäkehotus

Kun agentin runko on luotu, on aika määritellä sen persoona ja tarkoitus. Tässä osassa käytät **Generate system prompt** -toimintoa, jolla kuvaat agentin käyttäytymistä—tässä tapauksessa laskinagenttia—ja saat mallin kirjoittamaan järjestelmäkehotuksen puolestasi.

![Kuva "Calculator Agent" -näkymästä AI Toolkitissa, jossa näkyy auki "Generate a prompt" -ikkuna. Ikkunassa kerrotaan, että kehotepohja voidaan luoda antamalla perusasiat, mukana tekstikenttä esimerkkikehotuksella: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Ikkunan alareunassa painikkeet "Close" ja "Generate". Taustalla agentin asetukset, valittuna malli "OpenAI GPT-4o (via GitHub)" ja kentät system- ja user-promptille.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.fi.png)

1. **Prompts**-osiossa klikkaa **Generate system prompt** -painiketta. Tämä avaa kehotteenrakentajan, joka hyödyntää tekoälyä järjestelmäkehotuksen luomiseen.
1. Kirjoita **Generate a prompt** -ikkunaan seuraava: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Klikkaa **Generate**. Näytön oikeaan alakulmaan ilmestyy ilmoitus, kun kehotteen luonti käynnistyy. Valmis kehotus ilmestyy **System prompt** -kenttään.
1. Tarkista **System prompt** ja muokkaa tarvittaessa.

### -3- Luo MCP-palvelin

Nyt kun olet määrittänyt agentin järjestelmäkehotuksen, joka ohjaa sen toimintaa ja vastauksia, on aika varustaa agentti käytännön taidoilla. Tässä osassa luot laskin-MCP-palvelimen, joka sisältää työkalut yhteen-, vähennys-, kerto- ja jakolaskujen suorittamiseen. Tämä palvelin mahdollistaa agentin suorittaa reaaliaikaisia matemaattisia operaatioita luonnollisen kielen kehotteiden perusteella.

![Kuva Calculator Agent -näkymän alaosasta AI Toolkitissa. Näkyvissä laajennettavat valikot “Tools” ja “Structure output”, pudotusvalikko “Choose output format” asetettuna “text”. Oikealla painike “+ MCP Server” MCP-palvelimen lisäämiseen. Kuvakepaikka ylhäällä Tools-osiossa.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.fi.png)

AI Toolkitissa on valmiita malleja, jotka helpottavat oman MCP-palvelimen luontia. Käytämme Python-mallia laskin-MCP-palvelimen luomiseen.

*Huom*: AI Toolkit tukee tällä hetkellä Pythonia ja TypeScriptiä.

1. **Agent (Prompt) Builderin** **Tools**-osiossa klikkaa **+ MCP Server** -painiketta. Laajennus avaa asennusvelhon **Command Paletten** kautta.
1. Valitse **+ Add Server**.
1. Valitse **Create a New MCP Server**.
1. Valitse **python-weather** -mallipohja.
1. Valitse **Default folder** MCP-palvelimen mallipohjan tallennuspaikaksi.
1. Anna palvelimen nimeksi **Calculator**.
1. Uusi Visual Studio Code -ikkuna avautuu. Valitse **Yes, I trust the authors**.
1. Avaa terminaali (**Terminal** > **New Terminal**) ja luo virtuaaliympäristö: `python -m venv .venv`
1. Aktivoi virtuaaliympäristö terminaalissa:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Asenna riippuvuudet terminaalissa: `pip install -e .[dev]`
1. **Explorer**-näkymässä **Activity Bar**ssa laajenna **src**-hakemisto ja avaa **server.py** editorissa.
1. Korvaa **server.py** -tiedoston sisältö seuraavalla ja tallenna:

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

### -4- Aja agentti laskin-MCP-palvelimella

Nyt kun agentilla on työkalut, on aika käyttää niitä! Tässä osassa lähetät kehotteita agentille testataksesi ja varmistaaksesi, että agentti hyödyntää oikeaa työkalua laskin-MCP-palvelimelta.

![Kuva Calculator Agent -näkymästä AI Toolkitissa. Vasemmalla “Tools”-osiossa MCP-palvelin nimeltä local-server-calculator_server, jossa neljä työkalua: add, subtract, multiply ja divide. Neljän työkalun aktiivisuus näkyy tunnisteena. Alhaalla supistettu “Structure output” -osio ja sininen “Run”-painike. Oikealla “Model Response” -paneelissa agentti kutsuu multiply- ja subtract-työkaluja syötteillä {"a": 3, "b": 25} ja {"a": 75, "b": 20}. Lopullinen “Tool Response” on 75.0. Alhaalla painike “View Code”.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.fi.png)

Ajetaan laskin-MCP-palvelin paikallisella kehityskoneellasi **Agent Builderin** kautta MCP-asiakkaana.

1. Paina `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Ostin 3 tuotetta, joiden hinta oli 25 dollaria kappaleelta, ja käytin 20 dollarin alennuksen. Paljonko maksoin yhteensä?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` arvot annetaan **subtract**-työkalulle.
    - Jokaisen työkalun vastaus näkyy **Tool Response** -kentässä.
    - Mallin lopullinen vastaus näkyy **Model Response** -kentässä.
1. Lähetä lisää kehotteita testataksesi agenttia laajemmin. Voit muokata olemassa olevaa kehotetta **User prompt** -kentässä klikkaamalla ja korvaamalla teksti.
1. Kun olet valmis, voit lopettaa palvelimen terminaalissa painamalla **CTRL/CMD+C**.

## Tehtävä

Yritä lisätä uusi työkalu **server.py** -tiedostoon (esim. laske luvun neliöjuuri). Lähetä agentille kehotteita, jotka vaativat uuden työkalun (tai olemassa olevien työkalujen) käyttöä. Muista käynnistää palvelin uudelleen, jotta uudet työkalut latautuvat.

## Ratkaisu

[Ratkaisu](./solution/README.md)

## Keskeiset opit

Tämän luvun tärkeimmät opit:

- AI Toolkit -laajennus on erinomainen asiakas MCP-palvelimien ja niiden työkalujen hyödyntämiseen.
- MCP-palvelimiin voi lisätä uusia työkaluja, jolloin agentin kyvykkyydet laajenevat muuttuviin tarpeisiin.
- AI Toolkit sisältää mallipohjia (esim. Python MCP -palvelinmallit), jotka helpottavat omien työkalujen luomista.

## Lisäresurssit

- [AI Toolkit -dokumentaatio](https://aka.ms/AIToolkit/doc)

## Mitä seuraavaksi
- Seuraava: [Testing & Debugging](/03-GettingStarted/08-testing/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty tekoälypohjaisella käännöspalvelulla [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattiset käännökset saattavat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeiden tietojen osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tästä käännöksestä aiheutuvista väärinymmärryksistä tai tulkinnoista.