<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:24:30+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "fi"
}
-->
# Palvelimen käyttö Visual Studio Coden AI Toolkit -laajennuksesta

Kun rakennat tekoälyagenttia, kyse ei ole vain fiksujen vastausten luomisesta; kyse on myös agentin kyvystä toimia. Tässä kohtaa Model Context Protocol (MCP) astuu kuvaan. MCP helpottaa agenttien pääsyä ulkoisiin työkaluihin ja palveluihin johdonmukaisella tavalla. Ajattele sitä kuin liittäisit agenttisi työkalupakkiin, jota se voi *oikeasti* käyttää.

Oletetaan, että yhdistät agentin laskin-MCP-palvelimeen. Yhtäkkiä agenttisi voi suorittaa matemaattisia operaatioita vain vastaanottamalla kehotteen, kuten "Mikä on 47 kertaa 89?"—ei tarvitse kovakoodata logiikkaa tai rakentaa mukautettuja API-rajapintoja.

## Yleiskatsaus

Tämä oppitunti kattaa, kuinka yhdistää laskin-MCP-palvelin agenttiin Visual Studio Coden [AI Toolkit](https://aka.ms/AIToolkit) -laajennuksen avulla, mahdollistaen agentin suorittaa matemaattisia operaatioita, kuten yhteenlasku, vähennyslasku, kertolasku ja jakolasku luonnollisen kielen kautta.

AI Toolkit on tehokas laajennus Visual Studio Codeen, joka virtaviivaistaa agenttien kehittämistä. Tekoälyinsinöörit voivat helposti rakentaa tekoälysovelluksia kehittämällä ja testaamalla generatiivisia tekoälymalleja—paikallisesti tai pilvessä. Laajennus tukee suurinta osaa nykyään saatavilla olevista merkittävistä generatiivisista malleista.

*Huomio*: AI Toolkit tukee tällä hetkellä Pythonia ja TypeScriptiä.

## Oppimistavoitteet

Tämän oppitunnin lopussa osaat:

- Käyttää MCP-palvelinta AI Toolkitin kautta.
- Määrittää agenttikonfiguraation, jotta se voi löytää ja hyödyntää MCP-palvelimen tarjoamia työkaluja.
- Hyödyntää MCP-työkaluja luonnollisen kielen kautta.

## Lähestymistapa

Näin meidän on lähestyttävä tätä yleisellä tasolla:

- Luo agentti ja määritä sen järjestelmäkehotus.
- Luo MCP-palvelin laskintyökaluilla.
- Yhdistä Agent Builder MCP-palvelimeen.
- Testaa agentin työkalukutsua luonnollisen kielen kautta.

Hienoa, nyt kun ymmärrämme kulun, konfiguroidaan tekoälyagentti hyödyntämään ulkoisia työkaluja MCP:n kautta, parantaen sen kyvykkyyksiä!

## Esitiedot

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## Harjoitus: Palvelimen käyttö

Tässä harjoituksessa rakennat, ajat ja parannat tekoälyagenttia MCP-palvelimen työkaluilla Visual Studio Codessa AI Toolkitin avulla.

### -0- Esivaihe, lisää OpenAI GPT-4o -malli Omiin malleihin

Harjoituksessa hyödynnetään **GPT-4o** -mallia. Malli tulisi lisätä **Omiin malleihin** ennen agentin luomista.

1. Avaa **AI Toolkit** -laajennus **Aktiviteettipalkista**.
1. **Luettelo**-osiossa valitse **Mallit** avataksesi **Malliluettelon**. Valitseminen avaa **Malliluettelon** uuteen editorivälilehteen.
1. **Malliluettelon** hakupalkissa syötä **OpenAI GPT-4o**.
1. Klikkaa **+ Lisää** lisätäksesi mallin **Omiin malleihin**. Varmista, että olet valinnut mallin, joka on **Hosted by GitHub**.
1. **Aktiviteettipalkissa** varmista, että **OpenAI GPT-4o** -malli näkyy luettelossa.

### -1- Luo agentti

**Agent (Prompt) Builder** mahdollistaa oman tekoälypohjaisen agentin luomisen ja mukauttamisen. Tässä osiossa luot uuden agentin ja liität mallin, joka ohjaa keskustelua.

1. Avaa **AI Toolkit** -laajennus **Aktiviteettipalkista**.
1. **Työkalut**-osiossa valitse **Agent (Prompt) Builder**. Valitseminen avaa **Agent (Prompt) Builderin** uuteen editorivälilehteen.
1. Klikkaa **+ Uusi rakentaja** -painiketta. Laajennus käynnistää asetusvelhon **Komentopaletti** kautta.
1. Syötä nimi **Calculator Agent** ja paina **Enter**.
1. **Agent (Prompt) Builderissa**, **Malli**-kenttään valitse **OpenAI GPT-4o (via GitHub)** -malli.

### -2- Luo järjestelmäkehotus agentille

Agentin alustamisen jälkeen on aika määritellä sen persoonallisuus ja tarkoitus. Tässä osiossa käytät **Luo järjestelmäkehotus** -ominaisuutta kuvaamaan agentin aiottua toimintaa—tässä tapauksessa laskinagentti—ja annat mallin kirjoittaa järjestelmäkehotuksen puolestasi.

1. **Kehotukset**-osiossa, klikkaa **Luo järjestelmäkehotus** -painiketta. Tämä painike avaa kehotuksenrakentajan, joka hyödyntää tekoälyä luodakseen järjestelmäkehotuksen agentille.
1. **Luo kehotus** -ikkunassa, syötä seuraava: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. Klikkaa **Luo**-painiketta. Ilmoitus ilmestyy oikeaan alakulmaan vahvistaen, että järjestelmäkehotusta luodaan. Kun kehotuksen luominen on valmis, kehotus ilmestyy **Järjestelmäkehotus**-kenttään **Agent (Prompt) Builderissa**.
1. Tarkista **Järjestelmäkehotus** ja muokkaa tarvittaessa.

### -3- Luo MCP-palvelin

Nyt kun olet määritellyt agenttisi järjestelmäkehotuksen—ohjaamassa sen toimintaa ja vastauksia—on aika varustaa agentti käytännön kyvyillä. Tässä osiossa luot laskin-MCP-palvelimen työkaluilla suorittamaan yhteen-, vähennys-, kerto- ja jakolaskuja. Tämä palvelin mahdollistaa agenttisi suorittamaan reaaliaikaisia matemaattisia operaatioita luonnollisen kielen kehotuksiin vastaten.

AI Toolkit on varustettu malleilla helpottamaan oman MCP-palvelimen luomista. Käytämme Python-mallia luodaksemme laskin-MCP-palvelimen.

1. **Työkalut**-osiossa **Agent (Prompt) Builderissa**, klikkaa **+ MCP-palvelin** -painiketta. Laajennus käynnistää asetusvelhon **Komentopaletti** kautta.
1. Valitse **+ Lisää palvelin**.
1. Valitse **Luo uusi MCP-palvelin**.
1. Valitse **python-weather** malliksi.
1. Valitse **Oletuskansio** tallentaaksesi MCP-palvelinmallin.
1. Syötä seuraava nimi palvelimelle: **Calculator**
1. Uusi Visual Studio Code -ikkuna avautuu. Valitse **Kyllä, luotan kirjoittajiin**.
1. Käytä terminaalia (**Terminaali** > **Uusi terminaali**) luodaksesi virtuaaliympäristön: `python -m venv .venv`
1. Käytä terminaalia aktivoidaksesi virtuaaliympäristön:
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. Käytä terminaalia asentaaksesi riippuvuudet: `pip install -e .[dev]`
1. **Aktiviteettipalkin** **Explorer**-näkymässä, laajenna **src**-hakemisto ja valitse **server.py** avataksesi tiedoston editorissa.
1. Korvaa **server.py**-tiedoston koodi seuraavalla ja tallenna:

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

Nyt kun agentillasi on työkaluja, on aika käyttää niitä! Tässä osiossa lähetät kehotuksia agentille testataksesi ja validoidaksesi, hyödyntääkö agentti sopivaa työkalua laskin-MCP-palvelimelta.

Ajetaan laskin-MCP-palvelin paikallisessa kehityskoneessasi **Agent Builderin** kautta MCP-asiakkaana.

1. Paina `F5` käynnistääksesi agentin.
1. Lähetä kehotus, kuten "Ostin 3 tuotetta hintaan $25 kappaleelta, ja käytin sitten $20 alennuksen. Paljonko maksoin?"
    - Huomaa, että **kertolasku**-työkalun parametreille **a** ja **b** arvot ovat asetettuina.
    - Huomaa, että **vähennyslasku**-työkalun parametreille **a** ja **b** arvot ovat asetettuina.
    - Kunkin työkalun vastaus on annettu vastaavassa **Työkalun vastaus**-osiossa.
    - Mallin lopullinen tulos on annettu lopullisessa **Mallin vastaus**-osiossa.
1. Lähetä lisäkehotuksia testataksesi agenttia edelleen. Voit muokata olemassa olevaa kehotusta **Käyttäjän kehotus** -kentässä klikkaamalla kenttään ja korvaamalla olemassa olevan kehotuksen.
1. Kun olet valmis testaamaan agenttia, voit pysäyttää palvelimen **terminaalin** kautta syöttämällä **CTRL/CMD+C** lopettaaksesi.

## Tehtävä

Kokeile lisätä uusi työkalumerkintä **server.py**-tiedostoosi (esim. palauta luvun neliöjuuri). Lähetä lisäkehotuksia, jotka vaatisivat agenttia hyödyntämään uutta työkalua (tai olemassa olevia työkaluja). Muista käynnistää palvelin uudelleen ladataksesi vasta lisätyt työkalut.

## Ratkaisu

[Ratkaisu](./solution/README.md)

## Keskeiset Opit

Tämän luvun keskeiset opit ovat seuraavat:

- AI Toolkit -laajennus on erinomainen asiakas, jonka avulla voit käyttää MCP-palvelimia ja niiden työkaluja.
- Voit lisätä uusia työkaluja MCP-palvelimiin, laajentaen agentin kykyjä vastaamaan kehittyviin vaatimuksiin.
- AI Toolkit sisältää malleja (esim. Python MCP-palvelinmallit) mukautettujen työkalujen luomisen yksinkertaistamiseksi.

## Lisäresurssit

- [AI Toolkit -dokumentaatio](https://aka.ms/AIToolkit/doc)

## Mitä Seuraavaksi

Seuraavaksi: [Luku 4 Käytännön Toteutus](/04-PracticalImplementation/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälyn käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomaa, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulisi pitää auktoriteettina. Tärkeää tietoa varten suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa mahdollisista väärinkäsityksistä tai virhetulkinnoista, jotka johtuvat tämän käännöksen käytöstä.