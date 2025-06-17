<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a91ca54debdfb015649e4786545694b3",
  "translation_date": "2025-06-17T16:12:29+00:00",
  "source_file": "03-GettingStarted/04-vscode/solution/README.md",
  "language_code": "ro"
}
-->
# Rularea exemplului

Aici presupunem că ai deja un cod de server funcțional. Te rugăm să găsești un server din unul dintre capitolele anterioare.

## Configurarea mcp.json

Iată un fișier pe care îl folosești ca referință, [mcp.json](../../../../../03-GettingStarted/04-vscode/solution/mcp.json).

Modifică intrarea pentru server după cum este necesar, indicând calea absolută către serverul tău, inclusiv comanda completă necesară pentru rulare.

În fișierul de exemplu menționat mai sus, intrarea pentru server arată astfel:

```json
"hello-mcp": {
    "command": "node",
    "args": [
        "build/index.js"
    ]
}
```

Aceasta corespunde rulării unei comenzi de genul: `node build/index.js`.

- Change this server entry to fit where your server file is located or to what's needed to startup your server depending on your chosen runtime and server location.

## Consume the features in the server

- Click the `play` icon, once you've added *mcp.json* to *./vscode* folder,

    Observe the tooling icon change to increase the number of available tools. Tooling icon is located right above the chat field in GitHub Copilot.

## Run a tool

- Type a prompt in your chat window that matches the description of your tool. For example to trigger the tool `add` tastează ceva de genul "add 3 to 20".

    Ar trebui să vezi un instrument afișat deasupra casetei de text pentru chat, indicând să selectezi rularea instrumentului, așa cum se vede în această imagine:

    ![VS Code indicând că dorește să ruleze un instrument](../../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.ro.png)

    Selectarea instrumentului ar trebui să producă un rezultat numeric care spune "23" dacă promptul tău a fost așa cum am menționat anterior.

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm responsabilitatea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.