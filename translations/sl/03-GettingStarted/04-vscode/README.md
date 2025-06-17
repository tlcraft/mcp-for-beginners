<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0eb9557780cd0a2551cdb8a16c886b51",
  "translation_date": "2025-06-17T16:18:50+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "sl"
}
-->
Pogovorimo se še o tem, kako uporabljamo vizualni vmesnik v naslednjih razdelkih.

## Pristop

Tako moramo pristopiti k temu na visoki ravni:

- Konfigurirati datoteko, da najde naš MCP Server.
- Zagnati/povezati se na omenjeni strežnik, da nam prikaže svoje zmogljivosti.
- Uporabiti omenjene zmogljivosti prek vmesnika GitHub Copilot Chat.

Super, zdaj ko razumemo potek, poskusimo uporabiti MCP Server prek Visual Studio Code v vaji.

## Vaja: Uporaba strežnika

V tej vaji bomo konfigurirali Visual Studio Code, da najde vaš MCP strežnik, da ga bo mogoče uporabljati prek vmesnika GitHub Copilot Chat.

### -0- Predhodni korak, omogoči odkrivanje MCP strežnikov

Morda boste morali omogočiti odkrivanje MCP strežnikov.

1. Pojdite na `File -> Preferences -> Settings` in Visual Studio Code.

1. Search for "MCP" and enable `chat.mcp.discovery.enabled` v datoteki settings.json.

### -1- Ustvari konfiguracijsko datoteko

Začnite z ustvarjanjem konfiguracijske datoteke v korenski mapi vašega projekta, potrebovali boste datoteko z imenom MCP.json, ki jo postavite v mapo .vscode. Izgledati mora tako:

```text
.vscode
|-- mcp.json
```

Nato si poglejmo, kako lahko dodamo zapis o strežniku.

### -2- Konfiguriraj strežnik

Dodajte naslednjo vsebino v *mcp.json*:

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

Zgoraj je preprost primer, kako zagnati strežnik, napisan v Node.js, za druge runtime okolje pa navedite ustrezen ukaz za zagon strežnika z uporabo `command` and `args`.

### -3- Zaženi strežnik

Zdaj, ko ste dodali zapis, zaženimo strežnik:

1. Poiščite svoj zapis v *mcp.json* in se prepričajte, da najdete ikono "play":

  ![Zagon strežnika v Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.sl.png)  

1. Kliknite ikono "play", ikona orodij v GitHub Copilot Chat bi morala prikazati povečano število razpoložljivih orodij. Če kliknete to ikono orodij, boste videli seznam registriranih orodij. Vsako orodje lahko označite ali odznačite glede na to, ali želite, da jih GitHub Copilot uporablja kot kontekst:

  ![Orodja v Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.sl.png)

1. Za zagon orodja vnesite ukaz, za katerega veste, da bo ustrezal opisu enega izmed vaših orodij, na primer ukaz "add 22 to 1":

  ![Zagon orodja iz GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.sl.png)

  Odziv bi moral biti 23.

## Naloga

Poskusite dodati zapis o strežniku v svojo datoteko *mcp.json* in se prepričajte, da lahko strežnik zaženete in ustavite. Prav tako preverite, ali lahko komunicirate z orodji na strežniku prek vmesnika GitHub Copilot Chat.

## Rešitev

[Rešitev](./solution/README.md)

## Ključne ugotovitve

Ključne ugotovitve iz tega poglavja so:

- Visual Studio Code je odličen odjemalec, ki vam omogoča uporabo več MCP strežnikov in njihovih orodij.
- Vmesnik GitHub Copilot Chat je način, kako komunicirate s strežniki.
- Uporabniku lahko zahtevate vnose, kot so API ključi, ki jih lahko posredujete MCP strežniku pri konfiguriranju zapisa strežnika v datoteki *mcp.json*.

## Primeri

- [Java kalkulator](../samples/java/calculator/README.md)
- [.Net kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulator](../samples/javascript/README.md)
- [TypeScript kalkulator](../samples/typescript/README.md)
- [Python kalkulator](../../../../03-GettingStarted/samples/python)

## Dodatni viri

- [Visual Studio dokumentacija](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Kaj sledi

- Naslednje: [Ustvarjanje SSE strežnika](/03-GettingStarted/05-sse-server/README.md)

**Opozorilo**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvorno jeziku velja za avtoritativni vir. Za kritične informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne prevzemamo odgovornosti.