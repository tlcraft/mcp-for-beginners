<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:42:34+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "fi"
}
-->
# Palvelimen käyttäminen AI Toolkit -laajennuksesta Visual Studio Codessa

Kun rakennat tekoälyagenttia, kyse ei ole pelkästään älykkäiden vastausten tuottamisesta, vaan myös siitä, että agentillasi on kyky toimia. Tässä tulee kuvaan Model Context Protocol (MCP). MCP helpottaa agenttien pääsyä ulkoisiin työkaluihin ja palveluihin johdonmukaisella tavalla. Voit ajatella sitä kuin liittäisit agenttisi oikeaan työkalupakkiin, jota se voi *todella* käyttää.

Oletetaan, että yhdistät agentin laskin-MCP-palvelimeesi. Yhtäkkiä agenttisi voi suorittaa matemaattisia laskutoimituksia pelkän kehotteen, kuten "Paljonko on 47 kertaa 89?" avulla — ilman, että sinun tarvitsee kovakoodata logiikkaa tai rakentaa omia rajapintoja.

## Yleiskatsaus

Tässä oppitunnissa opit, miten liität laskin-MCP-palvelimen agenttiin [AI Toolkit](https://aka.ms/AIToolkit) -laajennuksen avulla Visual Studio Codessa, jolloin agenttisi voi suorittaa laskutoimituksia, kuten yhteen-, vähennys-, kerto- ja jakolaskuja luonnollisella kielellä.

AI Toolkit on tehokas Visual Studio Code -laajennus, joka sujuvoittaa agenttien kehitystä. AI-insinöörit voivat helposti rakentaa tekoälysovelluksia kehittämällä ja testaamalla generatiivisia tekoälymalleja paikallisesti tai pilvessä. Laajennus tukee suurinta osaa nykyisistä generatiivisista malleista.

*Huom*: AI Toolkit tukee tällä hetkellä Pythonia ja TypeScriptiä.

## Oppimistavoitteet

Oppitunnin lopuksi osaat:

- Käyttää MCP-palvelinta AI Toolkitin kautta.
- Määrittää agentin asetukset siten, että se löytää ja hyödyntää MCP-palvelimen tarjoamia työkaluja.
- Käyttää MCP-työkaluja luonnollisen kielen avulla.

## Lähestymistapa

Näin etenemme pääpiirteittäin:

- Luo agentti ja määritä sen järjestelmäkehotus.
- Luo MCP-palvelin laskintyökaluilla.
- Yhdistä Agent Builder MCP-palvelimeen.
- Testaa agentin työkalujen kutsumista luonnollisella kielellä.

Hienoa, nyt kun ymmärrämme kokonaisuuden, määritetään tekoälyagentti käyttämään ulkoisia työkaluja MCP:n kautta ja laajennetaan sen kykyjä!

## Vaatimukset

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## Harjoitus: Palvelimen käyttäminen

Tässä harjoituksessa rakennat, ajat ja kehität tekoälyagenttia, joka hyödyntää MCP-palvelimen työkaluja Visual Studio Codessa AI Toolkitin avulla.

### -0- Esivalmistelu: Lisää OpenAI GPT-4o -malli My Models -listaan

Harjoitus käyttää **GPT-4o** -mallia. Malli tulee lisätä **My Models** -listalle ennen agentin luomista.

![Kuva AI Toolkit -laajennuksen mallivalikosta Visual Studio Codessa. Otsikko: "Find the right model for your AI Solution", alaotsikko kehottaa löytämään, testaamaan ja ottamaan käyttöön tekoälymalleja. Suosittujen mallien joukossa kuusi korttia: DeepSeek-R1 (GitHub-isännöity), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - pieni, nopea) ja DeepSeek-R1 (Ollama-isännöity). Jokaisessa kortissa on vaihtoehdot "Add" ja "Try in Playground".](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.fi.png)

1. Avaa **AI Toolkit** -laajennus **Activity Bar**sta.
1. Valitse **Catalog**-osiosta **Models** avataksesi **Model Catalog** -välilehden.
1. Kirjoita **Model Catalog**in hakupalkkiin **OpenAI GPT-4o**.
1. Klikkaa **+ Add** lisätäksesi mallin **My Models** -listalle. Varmista, että valitsemasi malli on **Hosted by GitHub**.
1. Tarkista **Activity Bar**sta, että **OpenAI GPT-4o** näkyy listassa.

### -1- Luo agentti

**Agent (Prompt) Builder** antaa sinun luoda ja räätälöidä omia tekoälyagentteja. Tässä osiossa luot uuden agentin ja määrität sille mallin, joka ohjaa keskustelua.

![Kuva "Calculator Agent" -rakentajasta AI Toolkit -laajennuksessa Visual Studio Codessa. Vasemmalla valittuna malli "OpenAI GPT-4o (via GitHub)." Järjestelmäkehotus: "Olet yliopiston matematiikan professori," käyttäjäkehotus: "Selitä Fourier-yhtälö yksinkertaisesti." Lisävalintoina työkalujen lisääminen, MCP Serverin aktivointi ja rakenteellisen tulosteen valinta. Alhaalla sininen "Run"-painike. Oikealla "Get Started with Examples" -osio, jossa kolme esimerkkisovellusta: Web Developer (MCP Server, Second-Grade Simplifier, Dream Interpreter) lyhyine kuvauksineen.](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.fi.png)

1. Avaa **AI Toolkit** -laajennus **Activity Bar**sta.
1. Valitse **Tools**-osiosta **Agent (Prompt) Builder** avataksesi sen uuteen editorivälilehteen.
1. Klikkaa **+ New Agent** -painiketta. Laajennus avaa asennusvelhon **Command Palette**n kautta.
1. Anna agentille nimi **Calculator Agent** ja paina **Enter**.
1. **Agent (Prompt) Builder**issa valitse **Model**-kenttään **OpenAI GPT-4o (via GitHub)** -malli.

### -2- Luo järjestelmäkehotus agentille

Agentin rungon luomisen jälkeen on aika määritellä sen persoona ja tarkoitus. Tässä osiossa käytät **Generate system prompt** -toimintoa kuvaamaan agentin toivottua käyttäytymistä — tässä tapauksessa laskinagenttia — ja mallin kirjoittavan järjestelmäkehotuksen puolestasi.

![Kuva "Calculator Agent" -näkymästä AI Toolkitissa, jossa auki on "Generate a prompt" -ikkuna. Ikkunassa kerrotaan, että kehotepohjan voi luoda jakamalla perustiedot. Tekstikentässä esimerkki: "Olet avulias ja tehokas matematiikan assistentti. Kun sinulle annetaan peruslaskutoimituksia sisältävä ongelma, vastaat oikealla tuloksella." Ikkunan alalaidassa painikkeet "Close" ja "Generate". Taustalla agentin asetukset, valittuna malli "OpenAI GPT-4o (via GitHub)" ja kentät järjestelmä- ja käyttäjäkehotukselle.](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.fi.png)

1. **Prompts**-osiossa klikkaa **Generate system prompt** -painiketta. Tämä avaa kehoterakentajan, joka hyödyntää tekoälyä järjestelmäkehotuksen luomiseen agentille.
1. **Generate a prompt** -ikkunassa syötä seuraava: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Klikkaa **Generate**. Näytön oikeaan alakulmaan ilmestyy ilmoitus, että järjestelmäkehotus luodaan. Kun luonti on valmis, kehotus ilmestyy **System prompt** -kenttään **Agent (Prompt) Builder**issa.
1. Tarkista **System prompt** ja muokkaa tarvittaessa.

### -3- Luo MCP-palvelin

Nyt kun olet määrittänyt agentin järjestelmäkehotuksen — joka ohjaa sen käyttäytymistä ja vastauksia — on aika varustaa agentti käytännön taidoilla. Tässä osiossa luot laskin-MCP-palvelimen, jossa on työkalut yhteen-, vähennys-, kerto- ja jakolaskuihin. Tämä palvelin mahdollistaa agentin suorittaa reaaliaikaisia laskutoimituksia luonnollisen kielen kehotteiden perusteella.

![Kuva Calculator Agentin alaosasta AI Toolkit -laajennuksessa Visual Studio Codessa. Näkyvissä laajennettavat valikot “Tools” ja “Structure output” sekä alasvetovalikko “Choose output format” asetettuna “text.” Oikealla "+ MCP Server" -painike MCP-palvelimen lisäämiseen. Kuvakekuvake yllä Tools-osiossa.](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.fi.png)

AI Toolkit sisältää malleja, jotka helpottavat oman MCP-palvelimen luontia. Käytämme Python-mallia laskin-MCP-palvelimen luomiseen.

*Huom*: AI Toolkit tukee tällä hetkellä Pythonia ja TypeScriptiä.

1. **Agent (Prompt) Builder**in **Tools**-osiossa klikkaa **+ MCP Server** -painiketta. Laajennus avaa asennusvelhon **Command Palette**n kautta.
1. Valitse **+ Add Server**.
1. Valitse **Create a New MCP Server**.
1. Valitse malliksi **python-weather**.
1. Valitse **Default folder** MCP-palvelinmallin tallennuskohteeksi.
1. Anna palvelimelle nimi: **Calculator**
1. Uusi Visual Studio Code -ikkuna avautuu. Valitse **Yes, I trust the authors**.
1. Luo virtuaaliympäristö terminaalissa (**Terminal** > **New Terminal**): `python -m venv .venv`
1. Aktivoi virtuaaliympäristö terminaalissa:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Asenna riippuvuudet terminaalissa: `pip install -e .[dev]`
1. **Explorer**-näkymässä **Activity Bar**ssa laajenna **src**-hakemisto ja avaa **server.py** editorissa.
1. Korvaa **server.py**-tiedoston sisältö seuraavalla ja tallenna:

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

Nyt kun agentillasi on työkalut, on aika käyttää niitä! Tässä osiossa lähetät agentille kehotteita testataksesi ja varmistaaksesi, että agentti käyttää oikeaa työkalua laskin-MCP-palvelimelta.

![Kuva Calculator Agent -näkymästä AI Toolkit -laajennuksessa Visual Studio Codessa. Vasemmalla "Tools"-osiosta on lisätty MCP-palvelin nimeltä local-server-calculator_server, jossa näkyy neljä työkalua: add, subtract, multiply ja divide. Neljä työkalua on aktiivisena. Alla on supistettu “Structure output” -osio ja sininen “Run” -painike. Oikealla "Model Response" -osiossa agentti kutsuu multiply- ja subtract-työkaluja syötteillä {"a": 3, "b": 25} ja {"a": 75, "b": 20}. Lopullinen "Tool Response" on 75.0. Alhaalla näkyy “View Code” -painike.](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.fi.png)

Ajetaan laskin-MCP-palvelin paikallisella kehityskoneellasi **Agent Builder**in kautta MCP-asiakkaana.

1. Paina `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `Ostin 3 tuotetta, joiden hinta oli 25 dollaria kappale, ja käytin 20 dollarin alennuksen. Paljonko maksoin yhteensä?`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` arvot annetaan **subtract**-työkalulle.
    - Jokaisen työkalun vastaus näkyy omassa **Tool Response** -kentässään.
    - Mallin lopullinen vastaus näkyy **Model Response** -kentässä.
1. Lähetä lisäkehotteita testataksesi agenttia lisää. Voit muokata nykyistä kehotetta **User prompt** -kentässä klikkaamalla kenttää ja korvaamalla sen.
1. Kun olet valmis testaamaan, voit pysäyttää palvelimen terminaalissa painamalla **CTRL/CMD+C**.

## Tehtävä

Kokeile lisätä uusi työkalu **server.py** -tiedostoon (esim. palauttaa luvun neliöjuuren). Lähetä agentille lisäkehotteita, jotka vaativat uuden työkalusi (tai olemassa olevien työkalujen) käyttöä. Muista käynnistää palvelin uudelleen, jotta uudet työkalut latautuvat.

## Ratkaisu

[Solution](./solution/README.md)

## Tärkeimmät opit

Tämän luvun tärkeimmät opit ovat:

- AI Toolkit -laajennus on erinomainen asiakas, joka mahdollistaa MCP-palvelinten ja niiden työkalujen käytön.
- MCP-palvelimiin voi lisätä uusia työkaluja, mikä laajentaa agentin kykyjä vastaamaan muuttuviin tarpeisiin.
- AI Toolkit sisältää malleja (esim. Python MCP-palvelinmallit), jotka helpottavat omien työkalujen luomista.

## Lisäresurssit

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## Seuraavaksi

Seuraava: [Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, otathan huomioon, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäinen asiakirja sen alkuperäiskielellä tulee pitää auktoritatiivisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai tulkinnoista.