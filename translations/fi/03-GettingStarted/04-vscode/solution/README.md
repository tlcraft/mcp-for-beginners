<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "96e08a8c1049dab757deb64cce4ea1e8",
  "translation_date": "2025-05-17T11:22:01+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "fi"
}
-->
# Näytteen suorittaminen

Tässä oletamme, että sinulla on jo toimiva palvelinkoodi. Etsi palvelin jostakin aiemmista luvuista.

## Aseta mcp.json

Tässä on tiedosto, jota käytät viitteenä, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Muuta palvelinmerkintää tarpeen mukaan osoittamaan palvelimesi absoluuttinen polku sisältäen tarvittavan täyden komennon suorittamiseen.

Yllä viitatun esimerkkitiedoston palvelinmerkintä näyttää tältä:

```json
"hello-mcp": {
    "command": "cmd",
    "args": [
        "/c", "node", "<absolute path>\\build\\index.js"
    ]
}
```

Tämä vastaa komennon suorittamista näin: `cmd /c node <absoluuttinen polku>\\build\index.js`. 

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder, 

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` tyyliin "lisää 3 lukuun 20".

    Sinun pitäisi nähdä työkalu esitettynä chat-tekstikentän yläpuolella, joka osoittaa, että sinun tulee valita työkalun suorittaminen kuten tässä kuvassa:

    ![VS Code osoittamassa haluavansa suorittaa työkalun](../../../../../translated_images/vscode-agent.7f56a5ce3cef334adfe737514a7e8ac9384fa4161dd4df14bd3ddc9cd1a154f4.fi.png)

    Työkalun valitseminen pitäisi tuottaa numeerisen tuloksen, joka sanoo "23", jos kehotuksesi oli kuten aiemmin mainitsimme.

**Vastuuvapauslauseke**:  
Tämä asiakirja on käännetty käyttämällä tekoälypohjaista käännöspalvelua [Co-op Translator](https://github.com/Azure/co-op-translator). Pyrimme tarkkuuteen, mutta huomioithan, että automaattiset käännökset voivat sisältää virheitä tai epätarkkuuksia. Alkuperäistä asiakirjaa sen alkuperäisellä kielellä tulisi pitää auktoritatiivisena lähteenä. Kriittisen tiedon osalta suositellaan ammattimaista ihmiskäännöstä. Emme ole vastuussa tämän käännöksen käytöstä johtuvista väärinkäsityksistä tai virhetulkinnoista.