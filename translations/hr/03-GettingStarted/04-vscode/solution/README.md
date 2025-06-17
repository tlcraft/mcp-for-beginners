<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T16:17:20+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "hr"
}
-->
# Pokretanje primjera

Ovdje pretpostavljamo da već imate radni kod servera. Molimo pronađite server iz nekog od ranijih poglavlja.

## Postavljanje mcp.json

Ovo je datoteka koju koristite kao referencu, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Promijenite unos servera prema potrebi kako biste naveli apsolutnu putanju do vašeg servera, uključujući potrebnu punu naredbu za pokretanje.

U primjeru datoteke spomenute gore, unos servera izgleda ovako:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Ovo odgovara pokretanju naredbe poput: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` upišite nešto poput "add 3 to 20".

    Trebali biste vidjeti alat prikazan iznad tekstnog okvira za chat, koji vas poziva da odaberete pokretanje alata, kao na ovoj slici:

    ![VS Code indicating it wanting to run a tool](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.hr.png)

    Odabirom alata trebali biste dobiti numerički rezultat "23" ako je vaš upit bio kao što smo ranije spomenuli.

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za važne informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakve nesporazume ili pogrešna tumačenja proizašla iz korištenja ovog prijevoda.