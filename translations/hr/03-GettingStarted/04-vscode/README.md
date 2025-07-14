<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "222e01c3002a33355806d60d558d9429",
  "translation_date": "2025-07-14T09:43:25+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "hr"
}
-->
Razgovarajmo više o tome kako koristimo vizualno sučelje u sljedećim odjeljcima.

## Pristup

Evo kako trebamo pristupiti ovom procesu na visokoj razini:

- Konfigurirati datoteku za pronalazak našeg MCP Servera.
- Pokrenuti/Povezati se s navedenim serverom kako bi prikazao svoje mogućnosti.
- Koristiti te mogućnosti putem GitHub Copilot Chat sučelja.

Odlično, sada kada razumijemo tijek, pokušajmo koristiti MCP Server kroz Visual Studio Code kroz jedan zadatak.

## Zadatak: Korištenje servera

U ovom zadatku konfigurirat ćemo Visual Studio Code da pronađe vaš MCP server kako bi se mogao koristiti iz GitHub Copilot Chat sučelja.

### -0- Pripremni korak, omogućite otkrivanje MCP Servera

Možda ćete trebati omogućiti otkrivanje MCP Servera.

1. Idite na `File -> Preferences -> Settings` u Visual Studio Codeu.

1. Potražite "MCP" i omogućite `chat.mcp.discovery.enabled` u datoteci settings.json.

### -1- Kreirajte konfiguracijsku datoteku

Započnite kreiranjem konfiguracijske datoteke u korijenu vašeg projekta, trebat će vam datoteka nazvana MCP.json koju ćete smjestiti u mapu .vscode. Trebala bi izgledati ovako:

```text
.vscode
|-- mcp.json
```

Sljedeće, pogledajmo kako možemo dodati unos servera.

### -2- Konfigurirajte server

Dodajte sljedeći sadržaj u *mcp.json*:

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

Gore je jednostavan primjer kako pokrenuti server napisan u Node.js, za druge runtime okoline navedite odgovarajuću naredbu za pokretanje servera koristeći `command` i `args`.

### -3- Pokrenite server

Sada kada ste dodali unos, pokrenimo server:

1. Pronađite svoj unos u *mcp.json* i provjerite imate li ikonu "play":

  ![Pokretanje servera u Visual Studio Codeu](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.hr.png)  

1. Kliknite na ikonu "play", trebali biste vidjeti da se ikona alata u GitHub Copilot Chat povećava broj dostupnih alata. Ako kliknete na tu ikonu alata, vidjet ćete popis registriranih alata. Možete označiti/odznačiti svaki alat ovisno želite li da ih GitHub Copilot koristi kao kontekst:

  ![Pokretanje servera u Visual Studio Codeu](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.hr.png)

1. Za pokretanje alata, upišite upit za koji znate da će odgovarati opisu jednog od vaših alata, na primjer upit poput "add 22 to 1":

  ![Pokretanje alata iz GitHub Copilota](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.hr.png)

  Trebali biste vidjeti odgovor koji kaže 23.

## Zadatak

Pokušajte dodati unos servera u svoju *mcp.json* datoteku i provjerite možete li pokrenuti/zaustaviti server. Također provjerite možete li komunicirati s alatima na vašem serveru putem GitHub Copilot Chat sučelja.

## Rješenje

[Rješenje](./solution/README.md)

## Ključne poruke

Ključne poruke iz ovog poglavlja su sljedeće:

- Visual Studio Code je izvrstan klijent koji vam omogućuje korištenje više MCP Servera i njihovih alata.
- GitHub Copilot Chat sučelje je način na koji komunicirate sa serverima.
- Možete tražiti od korisnika unos poput API ključeva koji se mogu proslijediti MCP Serveru prilikom konfiguriranja unosa servera u *mcp.json* datoteci.

## Primjeri

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Dodatni resursi

- [Visual Studio dokumentacija](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Što slijedi

- Sljedeće: [Kreiranje SSE Servera](../05-sse-server/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakve nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.