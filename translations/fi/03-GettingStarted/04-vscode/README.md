<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0eb9557780cd0a2551cdb8a16c886b51",
  "translation_date": "2025-06-17T15:55:26+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "fi"
}
-->
Puhutaan lisää siitä, miten käytämme visuaalista käyttöliittymää seuraavissa osioissa.

## Lähestymistapa

Näin meidän tulee lähestyä asiaa yleisellä tasolla:

- Määritä tiedosto, josta löydämme MCP-palvelimemme.
- Käynnistä/yhdistä kyseiseen palvelimeen, jotta se voi listata kykynsä.
- Käytä näitä kykyjä GitHub Copilot Chat -käyttöliittymän kautta.

Hienoa, nyt kun ymmärrämme prosessin, kokeillaan MCP-palvelimen käyttöä Visual Studio Code -sovelluksen kautta harjoituksen avulla.

## Harjoitus: Palvelimen käyttäminen

Tässä harjoituksessa määritämme Visual Studio Code -sovelluksen löytämään MCP-palvelimesi, jotta sitä voidaan käyttää GitHub Copilot Chat -käyttöliittymässä.

### -0- Esivaihe, ota MCP-palvelimien haku käyttöön

Saatat joutua ottamaan MCP-palvelimien haun käyttöön.

1. Mene kohtaan `File -> Preferences -> Settings` in Visual Studio Code.

1. Search for "MCP" and enable `chat.mcp.discovery.enabled` settings.json-tiedostossa.

### -1- Luo konfiguraatiotiedosto

Aloita luomalla konfiguraatiotiedosto projektisi juureen. Tarvitset tiedoston nimeltä MCP.json, joka sijoitetaan .vscode-kansioon. Sen tulisi näyttää tältä:

```text
.vscode
|-- mcp.json
```

Seuraavaksi katsotaan, miten palvelinmerkintä lisätään.

### -2- Määritä palvelin

Lisää seuraava sisältö tiedostoon *mcp.json*:

```json
{
    "inputs": [],
    "servers": {
       "hello-mcp": {
           "command": "node",
           "args": [
               "build/index.js"
           ]
       }
    }
}
```

Yllä on yksinkertainen esimerkki siitä, miten Node.js:llä kirjoitettu palvelin käynnistetään. Muissa ajoympäristöissä ilmoita oikea käynnistyskomento `command` and `args`-kenttään.

### -3- Käynnistä palvelin

Nyt kun olet lisännyt merkinnän, käynnistetään palvelin:

1. Etsi merkintäsi *mcp.json*-tiedostosta ja varmista, että löydät "play"-kuvakkeen:

  ![Palvelimen käynnistäminen Visual Studio Codessa](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.fi.png)  

1. Klikkaa "play"-kuvaketta, jolloin GitHub Copilot Chatin työkalukuvake näyttää käytettävissä olevien työkalujen määrän kasvavan. Jos klikkaat tätä työkalukuvaketta, näet rekisteröityjen työkalujen listan. Voit valita tai poistaa valinnan kunkin työkalun kohdalta sen mukaan, haluatko GitHub Copilotin käyttävän niitä kontekstina:

  ![Palvelimen käynnistäminen Visual Studio Codessa](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.fi.png)

1. Käyttääksesi työkalua, kirjoita kehotus, jonka tiedät vastaavan jonkin työkalusi kuvausta, esimerkiksi kehotus "add 22 to 1":

  ![Työkalun käyttäminen GitHub Copilotista](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.fi.png)

  Sinun pitäisi nähdä vastaus, joka on 23.

## Tehtävä

Kokeile lisätä palvelinmerkintä *mcp.json*-tiedostoosi ja varmista, että voit käynnistää ja pysäyttää palvelimen. Varmista myös, että voit kommunikoida palvelimesi työkalujen kanssa GitHub Copilot Chat -käyttöliittymän kautta.

## Ratkaisu

[Ratkaisu](./solution/README.md)

## Keskeiset opit

Tämän luvun keskeiset opit ovat seuraavat:

- Visual Studio Code on erinomainen asiakasohjelma, jonka avulla voit käyttää useita MCP-palvelimia ja niiden työkaluja.
- GitHub Copilot Chat -käyttöliittymä on tapa, jolla kommunikoit palvelimien kanssa.
- Voit pyytää käyttäjältä syötteitä, kuten API-avaimia, jotka voidaan välittää MCP-palvelimelle, kun määrität palvelinmerkinnän *mcp.json*-tiedostossa.

## Esimerkit

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Lisäresurssit

- [Visual Studio -dokumentaatio](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Mitä seuraavaksi

- Seuraavaksi: [SSE-palvelimen luominen](/03-GettingStarted/05-sse-server/README.md)

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty tekoälypohjaisella käännöspalvelulla [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä tiedoissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkinnoista.