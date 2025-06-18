<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0bc7bd48f55f1565f1d95ccb2c16f728",
  "translation_date": "2025-06-18T07:53:57+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/README.md",
  "language_code": "hr"
}
-->
# Primjer

Prethodni primjer pokazuje kako koristiti lokalni .NET projekt s tipom `stdio`. I kako pokrenuti server lokalno u kontejneru. Ovo je dobro rješenje u mnogim situacijama. Međutim, može biti korisno imati server koji radi na udaljenom mjestu, poput okruženja u oblaku. Tu dolazi do izražaja tip `http`.

Gledajući rješenje u mapi `04-PracticalImplementation`, može izgledati puno složenije nego prethodno. No u stvarnosti nije tako. Ako pažljivo pogledate projekt `src/Calculator`, vidjet ćete da je većinom isti kod kao u prethodnom primjeru. Jedina razlika je što koristimo drugu biblioteku `ModelContextProtocol.AspNetCore` za upravljanje HTTP zahtjevima. Također mijenjamo metodu `IsPrime` u privatnu, samo da pokažemo da u kodu možete imati privatne metode. Ostatak koda je isti kao prije.

Ostali projekti dolaze iz [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/get-started/aspire-overview). Imati .NET Aspire u rješenju poboljšava iskustvo programera tijekom razvoja i testiranja te pomaže u nadzoru. Nije obavezno za pokretanje servera, ali je dobra praksa imati ga u rješenju.

## Pokrenite server lokalno

1. U VS Code (s C# DevKit ekstenzijom) navigirajte do direktorija `04-PracticalImplementation/samples/csharp`.
1. Pokrenite sljedeću naredbu za pokretanje servera:

   ```bash
    dotnet watch run --project ./src/AppHost
   ```

1. Kada se u web pregledniku otvori .NET Aspire nadzorna ploča, zabilježite URL `http`. Trebao bi biti nešto poput `http://localhost:5058/`.

   ![.NET Aspire Dashboard](../../../../../translated_images/dotnet-aspire-dashboard.0a7095710e9301e90df2efd867e1b675b3b9bc2ccd7feb1ebddc0751522bc37c.hr.png)

## Testirajte Streamable HTTP s MCP Inspectorom

Ako imate Node.js verziju 22.7.5 ili noviju, možete koristiti MCP Inspector za testiranje vašeg servera.

Pokrenite server i u terminalu izvršite sljedeću naredbu:

```bash
npx @modelcontextprotocol/inspector http://localhost:5058
```

![MCP Inspector](../../../../../translated_images/mcp-inspector.c223422b9b494fb4a518a3b3911b3e708e6a5715069470f9163ee2ee8d5f1ba9.hr.png)

- Odaberite `Streamable HTTP` as the Transport type.
- In the Url field, enter the URL of the server noted earlier, and append `/mcp`. Trebao bi biti `http` (ne `https`) something like `http://localhost:5058/mcp`.
- select the Connect button.

A nice thing about the Inspector is that it provide a nice visibility on what is happening.

- Try listing the available tools
- Try some of them, it should works just like before.

## Test MCP Server with GitHub Copilot Chat in VS Code

To use the Streamable HTTP transport with GitHub Copilot Chat, change the configuration of the `calc-mcp` server kreiran ranije da izgleda ovako:

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "http://localhost:5058/mcp"
    }
  }
}
```

Izvršite nekoliko testova:

- Zatražite "3 prosta broja nakon 6780". Primijetite kako Copilot koristi nove alate `NextFivePrimeNumbers` i vraća samo prva 3 prosta broja.
- Zatražite "7 prostih brojeva nakon 111", da vidite što se događa.
- Zatražite "John ima 24 lizalice i želi ih podijeliti svojoj 3 djece. Koliko lizalica dobiva svako dijete?", da vidite što se događa.

## Postavite server na Azure

Postavimo server na Azure kako bi ga više ljudi moglo koristiti.

U terminalu, navigirajte do mape `04-PracticalImplementation/samples/csharp` i pokrenite sljedeću naredbu:

```bash
azd up
```

Nakon što se postavljanje završi, trebali biste vidjeti poruku poput ove:

![Azd deployment success](../../../../../translated_images/azd-deployment-success.bd42940493f1b834a5ce6251a6f88966546009b350df59d0cc4a8caabe94a4f1.hr.png)

Preuzmite URL i koristite ga u MCP Inspectoru i GitHub Copilot Chatu.

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "https://calc-mcp.gentleriver-3977fbcf.australiaeast.azurecontainerapps.io/mcp"
    }
  }
}
```

## Što slijedi?

Isprobavamo različite vrste transporta i alate za testiranje. Također postavljamo vaš MCP server na Azure. Ali što ako naš server treba pristup privatnim resursima? Na primjer, bazi podataka ili privatnom API-ju? U sljedećem poglavlju vidjet ćemo kako možemo poboljšati sigurnost našeg servera.

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge prevođenja [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.