<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8ea28e5e566edd5969337fd0b191ba3f",
  "translation_date": "2025-07-17T12:11:45+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "hr"
}
-->
# Korištenje servera iz GitHub Copilot Agent moda

Visual Studio Code i GitHub Copilot mogu djelovati kao klijent i koristiti MCP Server. Pitate se zašto bismo to željeli? Pa, to znači da se sve značajke MCP Servera sada mogu koristiti unutar vašeg IDE-a. Zamislite da dodate, na primjer, GitHubov MCP server, što bi omogućilo upravljanje GitHubom putem upita umjesto tipkanja specifičnih naredbi u terminalu. Ili zamislite bilo što što bi moglo poboljšati vaše iskustvo kao developera, a sve to kontrolirano prirodnim jezikom. Sad već vidite prednost, zar ne?

## Pregled

Ova lekcija objašnjava kako koristiti Visual Studio Code i GitHub Copilot Agent mod kao klijenta za vaš MCP Server.

## Ciljevi učenja

Na kraju ove lekcije moći ćete:

- Koristiti MCP Server putem Visual Studio Codea.
- Pokretati funkcionalnosti poput alata putem GitHub Copilota.
- Konfigurirati Visual Studio Code da pronađe i upravlja vašim MCP Serverom.

## Korištenje

MCP server možete kontrolirati na dva načina:

- Kroz korisničko sučelje, što ćete vidjeti kasnije u ovom poglavlju.
- Kroz terminal, moguće je upravljati stvarima iz terminala koristeći `code` izvršnu datoteku:

  Za dodavanje MCP servera u vaš korisnički profil, koristite naredbu --add-mcp i pružite JSON konfiguraciju servera u obliku {\"name\":\"server-name\",\"command\":...}.

  ```
  code --add-mcp "{\"name\":\"my-server\",\"command\": \"uvx\",\"args\": [\"mcp-server-fetch\"]}"
  ```

### Snimke zaslona

![Vođena konfiguracija MCP servera u Visual Studio Codeu](../../../../translated_images/chat-mode-agent.729a22473f822216dd1e723aaee1f7d4a2ede571ee0948037a2d9357a63b9d0b.hr.png)  
![Odabir alata po agent sesiji](../../../../translated_images/agent-mode-select-tools.522c7ba5df0848f8f0d1e439c2e96159431bc620cb39ccf3f5dc611412fd0006.hr.png)  
![Jednostavno otklanjanje pogrešaka tijekom razvoja MCP-a](../../../../translated_images/mcp-list-servers.fce89eefe3f30032bed8952e110ab9d82fadf043fcfa071f7d40cf93fb1ea9e9.hr.png)

U sljedećim odjeljcima detaljnije ćemo objasniti kako koristiti vizualno sučelje.

## Pristup

Evo kako trebamo pristupiti ovom procesu na visokoj razini:

- Konfigurirati datoteku za pronalazak našeg MCP Servera.
- Pokrenuti se/povezati s navedenim serverom kako bi se prikazale njegove mogućnosti.
- Koristiti te mogućnosti putem GitHub Copilot Chat sučelja.

Odlično, sada kad razumijemo tijek, pokušajmo koristiti MCP Server kroz Visual Studio Code kroz jedan zadatak.

## Vježba: Korištenje servera

U ovoj vježbi konfigurirat ćemo Visual Studio Code da pronađe vaš MCP server kako bi se mogao koristiti iz GitHub Copilot Chat sučelja.

### -0- Pripremni korak, omogućite otkrivanje MCP Servera

Možda ćete trebati omogućiti otkrivanje MCP Servera.

1. Idite na `File -> Preferences -> Settings` u Visual Studio Codeu.

1. Potražite "MCP" i omogućite `chat.mcp.discovery.enabled` u datoteci settings.json.

### -1- Kreirajte konfiguracijsku datoteku

Započnite kreiranjem konfiguracijske datoteke u korijenu vašeg projekta, trebat će vam datoteka nazvana MCP.json koju treba smjestiti u mapu .vscode. Trebala bi izgledati ovako:

```text
.vscode
|-- mcp.json
```

Sljedeće, pogledajmo kako dodati unos servera.

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

Gore je jednostavan primjer kako pokrenuti server napisan u Node.js, za druge runtimeove navedite odgovarajuću naredbu za pokretanje servera koristeći `command` i `args`.

### -3- Pokrenite server

Sada kada ste dodali unos, pokrenimo server:

1. Pronađite svoj unos u *mcp.json* i provjerite imate li ikonu "play":

  ![Pokretanje servera u Visual Studio Codeu](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.hr.png)  

1. Kliknite na ikonu "play", trebali biste vidjeti da se ikona alata u GitHub Copilot Chatu povećava broj dostupnih alata. Ako kliknete na tu ikonu alata, vidjet ćete popis registriranih alata. Možete označiti ili odznačiti svaki alat ovisno želite li da ih GitHub Copilot koristi kao kontekst:

  ![Pokretanje servera u Visual Studio Codeu](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.hr.png)

1. Za pokretanje alata, upišite upit za koji znate da odgovara opisu nekog od vaših alata, na primjer upit poput "add 22 to 1":

  ![Pokretanje alata iz GitHub Copilota](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.hr.png)

  Trebali biste vidjeti odgovor 23.

## Zadatak

Pokušajte dodati unos servera u svoju *mcp.json* datoteku i provjerite možete li pokrenuti/zaustaviti server. Također provjerite možete li komunicirati s alatima na vašem serveru putem GitHub Copilot Chat sučelja.

## Rješenje

[Rješenje](./solution/README.md)

## Ključne spoznaje

Glavne spoznaje iz ovog poglavlja su:

- Visual Studio Code je izvrstan klijent koji vam omogućuje korištenje više MCP Servera i njihovih alata.
- GitHub Copilot Chat sučelje je način na koji komunicirate sa serverima.
- Možete tražiti od korisnika unos poput API ključeva koji se mogu proslijediti MCP Serveru prilikom konfiguracije unosa servera u *mcp.json* datoteci.

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
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.