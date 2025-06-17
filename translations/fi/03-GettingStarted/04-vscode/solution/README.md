<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T15:55:38+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "fi"
}
-->
# Näytteen suorittaminen

Tässä oletetaan, että sinulla on jo toimiva palvelinkoodi. Etsi palvelin jostain aiemmista luvuista.

## mcp.json-tiedoston asettaminen

Tässä on tiedosto, jota voit käyttää viitteenä, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Muuta palvelinmerkintä tarpeen mukaan osoittamaan palvelimesi absoluuttinen polku sekä tarvittava täydellinen komento sen suorittamiseen.

Esimerkkitiedostossa mainittu palvelinmerkintä näyttää tältä:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Tämä vastaa komentoa, joka suoritetaan näin: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` kirjoita jotain kuten "add 3 to 20".

    Näet työkalun näkyvän keskustelukentän yläpuolella, joka pyytää sinua valitsemaan työkalun suorittamisen, kuten tässä kuvassa:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.fi.png)

    Työkalun valitseminen tuottaa numeerisen tuloksen, joka on "23", jos kehotteesi oli kuten aiemmin mainitsimme.

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty tekoälypohjaisella käännöspalvelulla [Co-op Translator](https://github.com/Azure/co-op-translator). Vaikka pyrimme tarkkuuteen, huomioithan, että automaattikäännöksissä saattaa esiintyä virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäiskielellä tulee pitää virallisena lähteenä. Tärkeissä asioissa suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä aiheutuvista väärinymmärryksistä tai virhetulkinnoista.